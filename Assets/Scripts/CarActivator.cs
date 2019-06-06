using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarActivator : MonoBehaviour
{
    public GameObject car;
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
            car.GetComponent<ON_OFF>().Activate();
        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            car.GetComponent<ON_OFF>().Deactivate();
        }

    }
}
