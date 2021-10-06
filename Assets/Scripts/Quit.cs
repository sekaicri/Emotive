using UnityEngine;
using System.Collections;

public class    Quit : MonoBehaviour
{

    [SerializeField]
    private Ws_Client_S ws;
    void OnApplicationQuit()
    {
        ws.Stopservice();
    }
}