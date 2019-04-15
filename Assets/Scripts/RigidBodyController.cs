using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyController : MonoBehaviour
{
    float speed = 1f, horizontal, vertical;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rigidBody.AddForce(((transform.right * horizontal) + (transform.forward * vertical)) * speed / Time.deltaTime);
    }
}
