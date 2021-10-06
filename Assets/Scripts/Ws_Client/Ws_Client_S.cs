using Newtonsoft.Json;
using System;
using UnityEngine;
using WebSocketSharp;
public class Ws_Client_S : MonoBehaviour
{
    WebSocket ws;
    [SerializeField]
    private CommandService command;
    [SerializeField]
    public Ws_VarResponsive response;
    [SerializeField]
    private Success responseSucce;



    bool isInit;

    [SerializeField]
    private VarEmotiv varEmotive;


    [SerializeField]
    private StartGame start;
    public void Start1()
    {
        try
        {
            ws = new WebSocket(PlayerPrefs.GetString("server"));
            ws.Connect();
            if (ws.IsAlive)
            {
                ws.OnMessage += messageReceived;
            }
            else
            {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, "No se puede conectar al servidor ", "Server");
                InAppNotification.Instance.ShowNotication(notification);
            }
        }
        catch {
            
        }
    }

    public void EndServer()
    {
        ws.Close();
    }

    public void messageReceived(object sender, MessageEventArgs e)
    {
        Debug.Log(e.Data);
        responseSucce = JsonConvert.DeserializeObject<Success>(e.Data);

        if (e.Data.Contains("vars"))
        {
            response = JsonConvert.DeserializeObject<Ws_VarResponsive>(e.Data);
            InAppNotification.Instance.HideNotication();
        }


        if (responseSucce.success)
        {
            if (!isInit)
            {
                VarEmotivService();
                isInit = true;
            }
        }

    }
    private void InAppNotificationCall()
    {
        if (!responseSucce.success)
        {
            ClassnNotification notification = new ClassnNotification(EnumNotification.buttonw, "El Emotiv esta desconectado", "Emotiv");
            InAppNotification.Instance.ShowNotication(notification);
        }

        else
        {
            StartGames();
        }

    }

    public void InitService()
    {
        if (isInit) {
            command.command = "initStream";
            string json = JsonConvert.SerializeObject(command);
            ws.Send(json);
            Invoke("InAppNotificationCall", 0.5f);

        }

        else {
            try
            {
                command.command = "connectToHeadset";
                string json = JsonConvert.SerializeObject(command);
                ws.Send(json);
                Invoke("InAppNotificationCall", 0.5f);
            }
            catch {
                ClassnNotification notification = new ClassnNotification(EnumNotification.buttonw1,"No se puede conectar al servidor ", "Emotiv");
                InAppNotification.Instance.ShowNotication(notification);
            }
        }
    }

    public void StartGames()
    {
        start.StartGames();
        start.StartWiht();

    }

    public void VarEmotivService()
    {
        command.command = "initStream";
        string json = JsonConvert.SerializeObject(command);
        ws.Send(json);
    }

    public void Stopservice()
    {
        command.command = "stopStream";
        string json = JsonConvert.SerializeObject(command);
        ws.Send(json);
        Debug.Log("end");
    }


}