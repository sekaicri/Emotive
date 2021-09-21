using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InAppNotification1 : MonoBehaviour
{
    public static InAppNotification1 Instance { get; private set; }


    [SerializeField]
    private GameObject noti;
    [SerializeField]
    private GameObject end;
    [SerializeField]
    private TMP_Text textend;
    [SerializeField]
    private TMP_Text textNoti;
    [SerializeField]
    private ElementIdentifier NotiEmotiv;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
        }
        else
            Destroy(gameObject);
    }


    public void ShowNotication(ClasNotiEmotiv clase)
    {

        switch (clase.state)
        {
            case EnumNotiEmotiv.NotiEmotiv:
                noti.gameObject.SetActive(true);
                end.gameObject.SetActive(false);
                textNoti.text = clase.textInformation;
                InterfaceManager.Instance.ShowScreen(NotiEmotiv);
                break;

            case EnumNotiEmotiv.EndTarea:
                noti.gameObject.SetActive(false);
                end.gameObject.SetActive(true);
                textend.text = clase.textInformation;
                InterfaceManager.Instance.ShowScreen(NotiEmotiv);
                Invoke("HideNotication", 1f);
                break;

            case EnumNotiEmotiv.Two:
                noti.gameObject.SetActive(true);
                end.gameObject.SetActive(true);
                textend.text = clase.textInformation;
                textNoti.text = clase.textInformation1;
                InterfaceManager.Instance.ShowScreen(NotiEmotiv);
                break;

        }
      

    }

    public void HideNotication()
    {
        InterfaceManager.Instance.HideScreen(NotiEmotiv);
    }



}




