using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGame : MonoBehaviour
{

   
    [SerializeField]
    private ElementIdentifier gamePatron;
    [SerializeField]
    private GameObject main;
    [SerializeField]
    private PatronView patronView;




    public void StartGame()
    {

        switch (SingletonInformation.Instance.severity.text)
        {
            case "BAJA":
                Patron();
                break;

            case "MEDIA":

                break;

            case "ALTA":

                break;

            default:
                break;
        }



    }

    private void Patron(){
        InterfaceManager.Instance.ShowScreen(gamePatron);
        patronView.StartPatron();
        main.gameObject.SetActive(false);

    }



}
