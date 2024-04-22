using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public bool isPaused;
    public GameObject pauseMenu;
    public void OnFirstPersonLevelPress()
    {
        SceneManager.LoadScene("Level1-fp");
    }

    public void OnThirdPersonLevelPress()
    {
        SceneManager.LoadScene("Level1-tp");
    }

    public void OnEscPress()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            isPaused = true;
            if (isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
                {
                    pauseMenu.SetActive(true);
                    Time.timeScale = 0f;
                    isPaused = false;
                }
            }
        }

    }
}
