using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject eventTextUI;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        eventTextUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {

        eventTextUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
