﻿using UnityEngine;

namespace CoverShooter
{
    /// <summary>
    /// Possible states for the civilian AI to take.
    /// </summary>
    public enum CivilianState
    {
        none,
        walkAround,
        follow,
        flee,
        call
    }

    [RequireComponent(typeof(Actor))]
    [RequireComponent(typeof(CharacterMotor))]
    public class CivilianBrain : BaseBrain
    {
        #region Properties

        /// <summary>
        /// Is the AI currently alarmed.
        /// </summary>
        public bool IsAlerted
        {
            get
            {
                return _state != CivilianState.none &&
                       _state != CivilianState.walkAround;
            }
        }

        /// <summary>
        /// Is the AI currently scared.
        /// </summary>
        public bool IsScared
        {
            get
            {
                return _state == CivilianState.flee;
            }
        }

        /// <summary>
        /// AI state the brain is at.
        /// </summary>
        public CivilianState State
        {
            get { return _state; }
        }

        #endregion

        #region Public fields

        /// <summary>
        /// The civilian is only alarmed by enemies with weapons in hands.
        /// </summary>
        [Tooltip("The civilian is only alarmed by enemies with weapons in hands.")]
        public bool OnlyAlarmedByWeapons = true;

        #endregion

        #region Private fields

        private CivilianState _previousState;
        private CivilianState _state;
        private CivilianState _futureSetState;
        private float _stateTime;

        private bool _wasAlerted;
        private bool _wasAlarmed;
        private bool _wasThreatArmed;

        #endregion

        #region Commands

        /// <summary>
        /// Told by a component to become scared.
        /// </summary>
        public void ToBecomeScared()
        {
            setState(CivilianState.flee);
        }

        /// <summary>
        /// Told by a component to enter a phone call state.
        /// </summary>
        public void ToMakeCall()
        {
            setState(CivilianState.call);
        }

        #endregion

        #region Events

        /// <summary>
        /// Registers a successfull call.
        /// </summary>
        public void OnCallMade()
        {
            if (_state == CivilianState.call)
                setState(_previousState);
        }

        /// <summary>
        /// Registers damage done by a weapon.
        /// </summary>
        public void OnHit(Hit hit)
        {
            if (hit.Attacker != null)
            {
                var threat = hit.Attacker.GetComponent<Actor>();

                if (threat != null && threat.Side != Actor.Side)
                {
                    if (Threat == threat && CanSeeTheThreat)
                        SetThreat(threat, threat.transform.position, threat.Cover);
                    else
                        SetUnseenThreat(true, threat, threat.transform.position, threat.Cover);
                }
            }
        }

        /// <summary>
        /// Notified by an alert system of an alert.
        /// </summary>
        public void OnAlert(GeneratedAlert alert)
        {
            if (alert.Actor != null && alert.Actor.Side != Actor.Side)
            {
                if (Threat == null)
                    SetUnseenThreat(alert.IsDirect, alert.Actor, alert.Position, null);
                else if (alert.Actor == Threat && !CanSeeTheThreat)
                    SetUnseenThreat(alert.IsDirect, alert.Actor, alert.Position, Threat.Cover);
                else if (Time.timeSinceLevelLoad - LastSeenThreatTime > 3)
                    SetUnseenThreat(alert.IsDirect, alert.Actor, alert.Position, alert.IsDirect ? alert.Actor.Cover : null);

                if (!alert.IsHostile && !IsScared && !IsAlerted)
                    setState(CivilianState.follow);
            }
        }

        /// <summary>
        /// Notified by the sight AI that an actor has entered the view.
        /// </summary>
        public void OnSeeActor(Actor actor)
        {
            if (actor.Side != Actor.Side)
            {
                if (Threat == null || Threat == actor || Time.timeSinceLevelLoad - LastSeenThreatTime > 3)
                {
                    SetThreat(actor, actor.transform.position, actor.Cover);

                    if (!IsAlerted && !IsScared)
                        setState(CivilianState.follow);
                }
            }
        }

        /// <summary>
        /// Notified by the sight AI that an actor has dissappeared from the view.
        /// </summary>
        public void OnUnseeActor(Actor actor)
        {
            if (Threat == actor)
                UnseeThreat();
        }

        #endregion

        #region Behaviour

        private void Awake()
        {
            Actor.IsAggressive = false;
        }

        private void Update()
        {
            if (Actor == null || !Actor.IsAlive)
                return;

            _stateTime += Time.deltaTime;

            if (Threat != null && CanSeeTheThreat)
                SetThreat(Threat, Threat.transform.position, Threat.Cover);

            if (_futureSetState != CivilianState.none)
            {
                var state = _futureSetState;
                _futureSetState = CivilianState.none;
                setState(state);
            }

            switch (_state)
            {
                case CivilianState.none:
                    setState(CivilianState.walkAround);
                    break;

                case CivilianState.walkAround:
                    break;

                case CivilianState.follow:
                    if (!_wasThreatArmed)
                    {
                        _wasThreatArmed = Threat.IsArmed;

                        if (_wasThreatArmed)
                            alarm();
                    }
                    break;

                case CivilianState.flee:
                    break;
            }
        }

        #endregion

        #region State

        private void setState(CivilianState state, bool forceRestart = false)
        {
            if (_state == state && !forceRestart)
                return;

            if (_state != state)
                _previousState = _state;

            closeState(_state, state);
            _stateTime = 0;
            _state = state;
            openState(_state, _previousState);

            if (!_wasAlerted && IsAlerted)
            {
                _wasAlerted = true;
                Message("OnAlerted");
            }
        }

        private void openState(CivilianState state, CivilianState previous)
        {
            switch (state)
            {
                case CivilianState.none:
                    break;

                case CivilianState.walkAround:
                    if (Actor.Cover != null)
                        Message("ToLeaveCover");

                    Message("ToStartVisitingWaypoints");
                    break;

                case CivilianState.follow:
                    Message("ToStartFollowing", LastKnownThreatPosition);
                    Message("ToTakePhone");
                    Message("ToStartFilming");

                    _wasThreatArmed = Threat.IsArmed;

                    if (_wasThreatArmed || !OnlyAlarmedByWeapons)
                        alarm();
                    break;

                case CivilianState.call:
                    Message("ToTakePhone");
                    Message("ToCall");
                    break;

                case CivilianState.flee:
                    Message("ToStartFleeing", LastKnownThreatPosition);
                    alarm();
                    break;
            }
        }

        private void closeState(CivilianState state, CivilianState next)
        {
            switch (state)
            {
                case CivilianState.walkAround:
                    Message("ToStopVisitingWaypoints");
                    break;

                case CivilianState.follow:
                    Message("ToStopFollowing");
                    Message("ToStopFilming");
                    Message("ToHidePhone");
                    break;

                case CivilianState.call:
                    if (next != CivilianState.follow)
                        Message("ToHidePhone");
                    break;

                case CivilianState.flee:
                    Message("ToStopFleeing");
                    break;
            }
        }


        #endregion

        #region Other methods

        private void alarm()
        {
            if (!_wasAlarmed)
            {
                _wasAlarmed = true;
                Message("OnAlarmed");
            }
        }

        #endregion
    }
}
