using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnFirstPersonLevelPress()
    {
        SceneManager.LoadScene("Level1-fp");
    }

    public void OnThirdPersonLevelPress()
    {
        SceneManager.LoadScene("Level1-tp");
    }
}
