﻿using System.Collections.Generic;
using UnityEngine;

namespace CoverShooter
{
    public class AIListener : MonoBehaviour
    {
        /// <summary>
        /// Fraction of an alert distance at which the AI hears it. 0 means no hearing, 1 means perfect.
        /// </summary>
        [Tooltip("Fraction of an alert distance at which the AI hears it. 0 means no hearing, 1 means perfect.")]
        public float Hearing = 1.0f;

        private void OnEnable()
        {
            AIListeners.Register(this);
        }

        private void OnDisable()
        {
            AIListeners.Unregister(this);
        }

        private void OnDestroy()
        {
            AIListeners.Unregister(this);
        }
    }

    public static class AIListeners
    {
        public static IEnumerable<AIListener> All
        {
            get { return _list; }
        }

        private static List<AIListener> _list = new List<AIListener>();
        private static Dictionary<GameObject, AIListener> _map = new Dictionary<GameObject, AIListener>();

        public static AIListener Get(GameObject gameObject)
        {
            if (_map.ContainsKey(gameObject))
                return _map[gameObject];
            else
                return null;
        }

        public static void Register(AIListener listener)
        {
            if (!_list.Contains(listener))
                _list.Add(listener);

            _map[listener.gameObject] = listener;
        }

        public static void Unregister(AIListener listener)
        {
            if (_list.Contains(listener))
                _list.Remove(listener);

            if (_map.ContainsKey(listener.gameObject))
                _map.Remove(listener.gameObject);
        }
    }
}
