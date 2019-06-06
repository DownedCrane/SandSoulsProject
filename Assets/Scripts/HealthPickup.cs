using UnityEngine;

namespace CoverShooter
{
    public class HealthPickup : MonoBehaviour
    {
        public float HealAmount = 100f;
        public GameObject player;
        // public GameObject father;
        public bool odnorazoviy;
        

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
                

            }

        }
        void Healing()
        {
            player.GetComponent<CharacterHealth>().Heal(HealAmount);
            if (odnorazoviy)
            {
                // father.SetActive(false);
                Destroy(gameObject, .5f);
            }
        }
    }
}
// Destroy(gameObject, .5f);