using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CoverShooter;

public class DeadActivator : MonoBehaviour
{
    public bool active;
    public GameObject motor;
    public GameObject something;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        active = motor.GetComponent<CharacterMotor>().IsAlive;
        if (active == false)
        {
            something.SetActive(true);
        }
    }
}
