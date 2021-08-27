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
    [ContextMenu("GenerateRandomCode")]
    private void GenerateRandomCode() {
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
        if (text == input.text)
        {
            Debug.Log("Correcto Perro");
        }
        else {
            Debug.Log("Incorrecto Perro");

        }
    }

    }
