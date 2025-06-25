using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandleDropdown : MonoBehaviour
{

    [SerializeField] private TMP_Dropdown DeviceTypeDropdown;
    [SerializeField] private TMP_Dropdown SightBehindWallsDropdown;

    public void Start()
    {
        DeviceTypeDropdown.value = (int) PlayerPrefs.GetFloat("IsMobile");
        SightBehindWallsDropdown.value = (int) PlayerPrefs.GetFloat("GenerateShadowCasters");
    }
    
    public void IsMobile()
    {
        if (PlayerPrefs.GetFloat("IsMobile") != DeviceTypeDropdown.value)
        { 
            PlayerPrefs.SetFloat("IsMobile", DeviceTypeDropdown.value);
            //Debug.Log(PlayerPrefs.GetFloat("IsMobile"));
        }
    }

    public void SightBehindWalls()
    {
        if (PlayerPrefs.GetFloat("GenerateShadowCasters") != SightBehindWallsDropdown.value)
        { 
            PlayerPrefs.SetFloat("GenerateShadowCasters", SightBehindWallsDropdown.value);
            //Debug.Log(PlayerPrefs.GetFloat("GenerateShadowCasters"));
        }
    }

}


//Debug.Log(dropdown.value);
//Debug.Log(dropdown.options[dropdown.value].text);