﻿using UnityEngine;
using System.Collections;

public class WaveTimer : MonoBehaviour
{

    public float targetTime = 60.0f;
    public GameObject myObject;
    public GameObject OTHERObject;
    private bool working;
    void Start()
    {
        working = true;
    }
    
    void Update()
    {

        if (working)
        {
            targetTime -= Time.deltaTime;
        }
        

        if (targetTime <= 0.0f)
        {
            timerEnded();
            working = false;
        }

    }

    void timerEnded()
    {
        if (myObject != null) {
            myObject.SetActive(true);

            OTHERObject.SetActive(false);
        }
        
        //do your stuff here.
    }


}