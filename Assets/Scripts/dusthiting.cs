using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusthiting : MonoBehaviour
{
    public Collision collision;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Go away!");
        }

    }

    void OnTriggerEnter(Collider dust)
    {
        Debug.Log("Enter");
    }
    void OnTriggerStay(Collider dust)
    {
        Debug.Log("stay");
    }
   void OnTriggerExit(Collider dust)
    {
        Debug.Log("exit");
    }
}