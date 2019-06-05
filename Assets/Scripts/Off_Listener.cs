using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Off_Listener : MonoBehaviour
{

    public AudioListener person;
    public AudioListener car;
    private bool k = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F) && k == true)
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
