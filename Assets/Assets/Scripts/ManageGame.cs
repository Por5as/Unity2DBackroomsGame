using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    [SerializeField] GameObject LoadingScreen;
    [SerializeField] GameObject PauseScreen;
    [SerializeField] GameObject Joystick;
    [SerializeField] GameObject Character;

    void Start()
    {
        Invoke(nameof(HideLoadingScreen), 3f);

        
        if (PlayerPrefs.GetFloat("IsMobile") == 0)
        {
            Joystick.SetActive(false);
            Character.GetComponent<JoystickMove>().enabled = false;
        }
        
        else 
        { 
            Character.GetComponent <CharacterMoveScript>().enabled = false;
            Joystick.SetActive(true);
        }

    }

    void HideLoadingScreen()
    {
        LoadingScreen.SetActive(false);
    }

}
