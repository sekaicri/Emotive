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
    private GameObject buttonWith;
    [SerializeField]
    private GameObject buttonWithout;
    [SerializeField]
    private Image load;
    [SerializeField]
    private Text informationNotification;
    [SerializeField]
    private Text Title;
    [SerializeField]
    private ElementIdentifier Show;
    [SerializeField]
    private GameObject again;



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
                buttonWith.SetActive(false);
                buttonWithout.SetActive(false);
                load.gameObject.SetActive(false);
                informationNotification.text = clase.textInformation;
                informationNotification.gameObject.SetActive(true);
                Title.gameObject.SetActive(true);
                Title.text = clase.title;
                again.SetActive(false);

                break;

             case EnumNotification.Buttonx:
                buttonX.SetActive(true);
                buttonOk.SetActive(false);
                buttonWith.SetActive(false);
                buttonWithout.SetActive(false);
                load.gameObject.SetActive(false);
                informationNotification.gameObject.SetActive(true);
                Title.gameObject.SetActive(true);
                informationNotification.text = clase.textInformation;
                Title.text = clase.title;
                again.SetActive(false);

                break;


            case EnumNotification.buttonw:
                again.SetActive(false);
                buttonX.SetActive(false);
                buttonOk.SetActive(false);
                buttonWith.SetActive(true);
                buttonWithout.SetActive(true);
                load.gameObject.SetActive(false);
                informationNotification.gameObject.SetActive(true);
                Title.gameObject.SetActive(true);
                informationNotification.text = clase.textInformation;
                Title.text = clase.title;
                break;


            case EnumNotification.buttonw1:
                buttonX.SetActive(false);
                buttonOk.SetActive(false);
                buttonWith.SetActive(false);
                again.SetActive(true);
                buttonWithout.SetActive(true);
                load.gameObject.SetActive(false);
                informationNotification.gameObject.SetActive(true);
                Title.gameObject.SetActive(true);
                informationNotification.text = clase.textInformation;
                Title.text = clase.title;
                break;


            case EnumNotification.Load:
                buttonX.SetActive(false);
                buttonWith.SetActive(false);
                buttonWithout.SetActive(false);
                buttonOk.SetActive(false);
                load.gameObject.SetActive(true);
                informationNotification.gameObject.SetActive(false);
                Title.gameObject.SetActive(false);
                again.SetActive(false);

                break;

          

        }

        InterfaceManager.Instance.ShowScreen(Show);
    }

    public void HideNotication()
    {
        InterfaceManager.Instance.HideScreen(Show);
    }



}


