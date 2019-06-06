using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VehicleBehaviour;
//[RequireComponent(typeof(AudioSource))]
public class ON_OFF : MonoBehaviour
{
    [Header("Находится ли игрок в машине")]
    public bool k;
    public bool car_active;
    public GameObject carCamera;
    public GameObject car;
    public GameObject person;

    private AudioSource audioSource;
    
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

    void Update()
    {

        WheelVehicle m1 = GetComponent<WheelVehicle>();
        EngineSoundManager m2 = GetComponent<EngineSoundManager>();
        audioSource = GetComponent<AudioSource>();



        if (Input.GetKeyUp(KeyCode.F) && k == false && car_active == true)
        {
            m1.enabled = true;
            m2.enabled = true;


            audioSource.enabled = true;
            audioSource.Play();
            person.SetActive(false);
            carCamera.SetActive(true);

            k = true;
        }

        else if (Input.GetKeyUp(KeyCode.F) && k == true)
        {
            m1.enabled = false;
            m2.enabled = false;

            person.transform.position = car.transform.position;
            float newX = person.transform.position.x - 1.7f;
            float newY = person.transform.position.y + 0.357f;
            float newZ = person.transform.position.z + 0.5f;
            person.transform.position = new Vector3(newX, newY, newZ);

            audioSource.Stop();
            audioSource.enabled = false;
            carCamera.SetActive(false);
            person.SetActive(true);

            k = false;
        }


    }
}
