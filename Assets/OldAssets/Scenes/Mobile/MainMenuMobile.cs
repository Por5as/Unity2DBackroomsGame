using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMobile : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 0 - Mobile");
    }

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("Settings - Mobile");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu - Mobile");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}