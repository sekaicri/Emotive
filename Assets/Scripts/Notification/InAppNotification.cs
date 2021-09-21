using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InAppNotification : MonoBehaviour
{

    public static InAppNotification Instance { get; private set; }

    [SerializeField]
    private GameObject buttonX;
    [SerializeField]
    private GameObject buttonOk;
    [SerializeField]
    private Image load;
    [SerializeField]
    private Text informationNotification;
    [SerializeField]
    private Text Title;
    [SerializeField]
    private ElementIdentifier Show;



    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
        }
        else
            Destroy(gameObject);
    }


    public void ShowNotication(ClassnNotification clase)
    {

        switch (clase.state)
        {
            case EnumNotification.ButtonOk:
                buttonX.SetActive(false);
                buttonOk.SetActive(true);
                load.gameObject.SetActive(false);
                informationNotification.text = clase.textInformation;
                informationNotification.gameObject.SetActive(true);
                Title.gameObject.SetActive(true);
                Title.text = clase.title;
                break;

             case EnumNotification.Buttonx:
                buttonX.SetActive(true);
                buttonOk.SetActive(false);
                load.gameObject.SetActive(false);
                informationNotification.gameObject.SetActive(true);
                Title.gameObject.SetActive(true);
                informationNotification.text = clase.textInformation;
                Title.text = clase.title;
                break;

            case EnumNotification.Load:
                buttonX.SetActive(false);
                buttonOk.SetActive(false);
                load.gameObject.SetActive(true);
                informationNotification.gameObject.SetActive(false);
                Title.gameObject.SetActive(false);
                break;

        }
        InterfaceManager.Instance.ShowScreen(Show);
    }

    public void HideNotication()
    {
        InterfaceManager.Instance.HideScreen(Show);
    }



}


