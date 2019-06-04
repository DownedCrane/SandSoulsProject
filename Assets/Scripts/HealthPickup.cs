using UnityEngine;

namespace CoverShooter
{
    public class HealthPickup : MonoBehaviour
    {
        public float HealAmount = 100f;
        public GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Healing();
                Destroy(gameObject, .5f);
            }
               
        }
        void Healing()
        {
            player.GetComponent<CharacterHealth>().Heal(HealAmount);
            
        }
    }
}