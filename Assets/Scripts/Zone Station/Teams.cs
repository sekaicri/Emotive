using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Teams : MonoBehaviour
{
    [SerializeField]
    private Text severityScene;
    [SerializeField]
    private List<TMP_Text> texts = new List<TMP_Text>();
    [SerializeField]
    private Button button;
    private Button ubication;
    private Fail failcua;
    [SerializeField]
    private Code code;
    [SerializeField]
    private InterfaceGame interfaceGame;
    [SerializeField]
    private Button button1;
    [SerializeField]
    private Button button2;
    [SerializeField]
    private Button button3;
    private string severity;


    public void TeamsStart(string severity)
    {
        if (severityScene.text == severity)
        {
            foreach (var s in texts)
            {
                if (s.text[0] == severity[0])
                {
                    s.fontStyle = TMPro.FontStyles.Underline;
                    s.fontSize = 40;
                    this.severity = severity;

                }
            }
            button.interactable = true;
        }
        else
        {
            foreach (var s in texts)
            {
                s.fontStyle = TMPro.FontStyles.Normal;
                s.fontSize = 35;
            }
            button.interactable = false;


            ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.NotiEmotiv, "ESTE EQUIPO NO ESTA EQUIPADO PARA SOLUCIONAR ESTE PROBLEMA",null);
            InAppNotification1.Instance.ShowNotication(notification);
        }
    }
    public void SaveTeams( Button button, Fail fail)

    {
        ubication = button;
        failcua = fail;
        code.SaveCode(ubication,failcua);
    }


    public void Code(){

        switch (severity)
        {
            case "BAJA":
                button1.interactable = false;
                button1.transform.GetChild(0).GetComponent<Text>().text = "OCUPADO";
                break;
            case "MEDIA":
                button2.interactable = false;
                button2.transform.GetChild(0).GetComponent<Text>().text = "OCUPADO";
                break;
            case "ALTA":
                button3.interactable = false;
                button3.transform.GetChild(0).GetComponent<Text>().text = "OCUPADO";
                break;
            default:
                break;
        }


        button.interactable = false;
        interfaceGame.CodeInterface(); 
    }



    public void Codex()
    {

        switch (severity)
        {
            case "BAJA":
                button1.interactable = true;
                button1.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            case "MEDIA":
                button2.interactable = true;
                button2.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            case "ALTA":
                button3.interactable = true;
                button3.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            default:
                break;
        }
        foreach (var s in texts)
        {
            s.fontStyle = TMPro.FontStyles.Normal;
            s.fontSize = 35;
        }
    }


    public void TeamsEnd() {
        switch (severity)
        {
            case "BAJA":
                button1.interactable = true;
                button1.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            case "MEDIA":
                button2.interactable = true;
                button2.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            case "ALTA":
                button3.interactable = true;
                button3.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            default:
                break;
        }




        foreach (var s in texts)
        {
            s.fontStyle = TMPro.FontStyles.Normal;
            s.fontSize = 35;
        }

    }


    public void Eraser()
    {
      
                button1.interactable = true;
                button1.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
          
                button2.interactable = true;
                button2.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
          
                button3.interactable = true;
                button3.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
            
        
        foreach (var s in texts)
        {
            s.fontStyle = TMPro.FontStyles.Normal;
            s.fontSize = 35;
        }

    }
}
