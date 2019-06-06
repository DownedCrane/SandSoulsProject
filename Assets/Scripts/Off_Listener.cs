using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Off_Listener : MonoBehaviour
{
    [Header("Находится ли игрок в машине")]
    public bool k;
    public bool car_active;


    public AudioListener person;
    public AudioListener car;

    void Start()
    {
        car_active = false;
    }

    public void Activate()
    {
        car_active = true;
    }

    public void Deactivate()
    {
        car_active = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && k == true && car_active == true)
        {
            person.enabled = false;
            car.enabled = true;

            k = false;
        }

        else if (Input.GetKeyUp(KeyCode.F) && k == false)
        {

            person.enabled = true;
            car.enabled = false;

            k = true;
        }
        
    }
}
