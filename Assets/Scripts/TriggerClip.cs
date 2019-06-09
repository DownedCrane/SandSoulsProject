using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerClip : MonoBehaviour {
	public GameObject Camera;
	public float TimeEnd;
	public GameObject Player;
    public GameObject DialogeCanvas;

    private float TimeStart;
	private bool OnZone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OnZone == true) {
			TimeStart += 1 * Time.deltaTime;
			if (TimeStart >= TimeEnd) {
				Player.SetActive (true);
                DialogeCanvas.SetActive(false);

                Camera.SetActive (false);
				Destroy (gameObject);
			}
		}
	}
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {

            DialogeCanvas.SetActive(true);
            Camera.SetActive (true);
			Player.SetActive (false);
			OnZone = true;
		}
	}
}
