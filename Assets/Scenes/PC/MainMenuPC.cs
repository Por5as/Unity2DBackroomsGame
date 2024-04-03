using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuPC : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 0 - PC");
    }

    public void GoToSettingsMenu()
    {
        SceneManager.LoadScene("Settings - PC");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu - PC");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}