using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleSettings : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject SettingMenu;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("IsMobile") == false)
        {
            MainMenu.SetActive(false);
            SettingMenu.SetActive(true);
        }
        else { 
            MainMenu.SetActive(true);
            SettingMenu.SetActive(false);
        }
    }

    public void SelectedComputer()
    {
        PlayerPrefs.SetFloat("IsMobile", 0);
        PlayerPrefs.SetFloat("GenerateShadowCasters", 1);

        MainMenu.SetActive(true);
        SettingMenu.SetActive(false);
    }

    public void SelectedMobile()
    {
        PlayerPrefs.SetFloat("IsMobile", 1);
        PlayerPrefs.SetFloat("GenerateShadowCasters", 1);

        MainMenu.SetActive(true);
        SettingMenu.SetActive(false);
    }


    /*
    public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("Deleted all PlayerPrefs");
    }
    */


}
