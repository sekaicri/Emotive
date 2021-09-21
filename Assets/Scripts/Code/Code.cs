using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class Code : MonoBehaviour
{

    [SerializeField]
    private Text code;
    private string text;
    [SerializeField]
    private InputField input;
    private Button ubication;
    private Fail failcua;
    [SerializeField]
    private Incidents Points;
    [SerializeField]
    private FontPre fontPre;
    [SerializeField]
    private InterfaceGame interfaceGame;
    [SerializeField]
    private CuadrillaManager cuadrilla;
    private int num;
    [SerializeField]
    private Teams  teams;
    [SerializeField]
    private Score Score;



    public void GenerateRandomCode() {
        int length = 5;
        const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        StringBuilder token = new StringBuilder();
        System.Random rnd = new System.Random();
        for (int i = 0; i < length; i++)
        {
            int index = rnd.Next(alphabet.Length);
            token.Append(alphabet[index]);
        }
        text = token.ToString();
        code.text = $"<size={UnityEngine.Random.Range(45, 75)}>{text[0]}</size>  <size={UnityEngine.Random.Range(45, 75)}>{text[1]}</size>  <size={UnityEngine.Random.Range(45, 75)}>{text[2]}</size>  <size={UnityEngine.Random.Range(45, 75)}>{text[3]}</size>  <size={UnityEngine.Random.Range(45, 75)}>{text[4]}</size>";
    }

    public void Validate()
    {
        if (text == input.text.ToUpper())
        {
            teams.TeamsEnd();
            interfaceGame.CodeOff();
            cuadrilla.Cuadrillas[num-1].TeamsEnd();
            input.text = "";

        }
        else {
            input.text = "";
            Debug.Log(text);
            Debug.Log(input.text);
            ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.NotiEmotiv, "CODIGO INVÁLIDO", null);
            InAppNotification1.Instance.ShowNotication(notification);
            GenerateRandomCode();

        }
    }

    public void SaveCode(Button button, Fail fail) {
        ubication = button;
        failcua = fail;
        GenerateRandomCode();
    }
    public void SaveCuadrilla(int num)
    {
        this.num=num;
    }


}
