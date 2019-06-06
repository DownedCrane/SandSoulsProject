using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CoverShooter
{
    public class DamageZone : MonoBehaviour
    {
        public float DmgAmount = -100f;
        public GameObject player;
        public float timer = 1f;
        private float realTimer = 1f;
        // public GameObject father;
        public bool odnorazoviy;
        bool deal;

        public float debug;

        // Start is called before the first frame update
        void Start()
        {
            deal = false;
        }

        // Update is called once per frame
        void Update()
        {
            realTimer -= Time.deltaTime;
            if (deal && (realTimer <= 0f))
            {
                player.GetComponent<CharacterHealth>().Heal(DmgAmount);
                realTimer = timer;
                debug = player.GetComponent<CharacterHealth>().Health;
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                deal = true;


            }

        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                deal = false;


            }

        }


    }
}