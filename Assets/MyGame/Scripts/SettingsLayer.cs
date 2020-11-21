using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsLayer : MonoBehaviour
{
    public GameObject popUp;
    public TextMeshProUGUI textField;
    public GameObject[] settings;

    public void OpenPopUp(string msg)
    {
        foreach(var c in settings)
        {
            c.SetActive(false);
        }
        popUp.SetActive(true);

        textField.text = msg;
    }

    public void ClosePopUp()
    {
        foreach(var c in settings)
        {
            c.SetActive(true);
        }
        popUp.SetActive(false);
    }
}
