using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PickupCrystals : MonoBehaviour {
	
	// public float speed;
	public Text countText;

	
	private Rigidbody rb;
	private int count;

    

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
	
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			count += 1;
			SetCountText ();
            
        }
		
		
    }
	
	
	void SetCountText ()
	{
		countText.text = count.ToString ();
	}
}
