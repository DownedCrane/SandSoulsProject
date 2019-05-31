using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PickupCrystals : MonoBehaviour {
	
	// public float speed;
	public Text countText;
	public Text winText;
	
	private Rigidbody rb;
	private int count;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
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
		
		if (other.gameObject.CompareTag("Portal"))
		{
			if  (CheckPortal(count))
			{
				// winText.text = "ПОБЕДА!";
				SceneManager.LoadScene(2);
			}
		}
    }
	
	public static bool CheckPortal(int s)
	{
		return (s >= 3);
	}
	
	void SetCountText ()
	{
		countText.text = count.ToString ();
		if (count >= 8) 
		{
			winText.text = "Иди к порталу!";
		}
	}
}
