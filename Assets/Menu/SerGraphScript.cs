using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SerGraphScript : MonoBehaviour {

    public Toggle LowGr;
    public Toggle MediumGr;
    public Toggle HighGr;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Graphics()
    {
        if (LowGr.isOn == true)
        {
            QualitySettings.currentLevel = QualityLevel.Fast;
        }
        if (MediumGr.isOn == true)
        {
            QualitySettings.currentLevel = QualityLevel.Good;
        }
        if (HighGr.isOn == true)
        {
            QualitySettings.currentLevel = QualityLevel.Fantastic;
        }
    }

}
