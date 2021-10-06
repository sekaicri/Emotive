using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    private float brightness;
    [SerializeField]
    private TMP_InputField server;
    [SerializeField]
    private Ws_Client_S ws;
    private void Start()
    {

        Screen.brightness = PlayerPrefs.GetFloat("brightness");
        if (!PlayerPrefs.HasKey("server"))
        {
            PlayerPrefs.SetString("server", "ws://localhost:8080");
        }
      
        ws.Start1();
        server.text = PlayerPrefs.GetString("server");
    }
    public void ChangeBrigthness(float value)
    {
        Screen.brightness = value;
        brightness = value;
    }


    public void Save() {


        if (server.text == PlayerPrefs.GetString("server"))
        {
            ws.Start1();

        }

        else {
            ws.EndServer();
            PlayerPrefs.SetString("server", server.text);
            ws.Start1();

        }

        PlayerPrefs.SetFloat("brightness", brightness);
    }



}
