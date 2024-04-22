using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenu;

    private void Update()
    {
        OnEscPress();
    }
    public void OnFirstPersonLevelPress()
    {
        SceneManager.LoadScene("Level1-fp");
    }

    public void OnThirdPersonLevelPress()
    {
        SceneManager.LoadScene("Level1-tp");
    }

    public void OnMenuButtonPress()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void OnEscPress()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            Paused();
        }

    }

    public void Paused()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
