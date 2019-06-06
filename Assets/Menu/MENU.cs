using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{

    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject buttonsSettings;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
        buttonsSettings.SetActive(false);
    }
    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
        buttonsSettings.SetActive(false);
    }
    public void ShowSettings()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(false);
        buttonsSettings.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void NewGameLoadScenceStart()
    {
        //Application.LoadLevel("World#1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    
}

