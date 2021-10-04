using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    private float brightness;

    private void Start()
    {
        Screen.brightness = PlayerPrefs.GetFloat("brightness"); ;
    }
    public void ChangeBrigthness(float value)
    {
        Screen.brightness = value;
        brightness = value;
    }


    public void Save() {

        PlayerPrefs.SetFloat("brightness", brightness);
    }

}
