using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {


    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject canvasPerson;

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
	}

   public void Resume()
    {
        pauseMenuUI.SetActive(false);
        canvasPerson.SetActive(true);
        Time.timeScale = 1;
        GameIsPaused = false;
    }

   public void Pause()
    {
        canvasPerson.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }



    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

 

}
