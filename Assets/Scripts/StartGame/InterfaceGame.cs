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
    [SerializeField]
    private Button buttonCuadrilla;
    [SerializeField]
    private Button buttonEquipo;
    [SerializeField]
    private GameObject Cuadrilla;
    [SerializeField]
    private GameObject Equipo;
    [SerializeField]
    private ElementIdentifier Code;
    [SerializeField]
    private Button Equipoteams;
    private float probability;
    private string complexity;


    private void Start()
    {

    }
    public void StartGame()
    {

        SingletonInformation.Instance.start.interactable = false;

        probability = SingletonInformation.Instance.probability;
        switch (SingletonInformation.Instance.severity.text)
        {

            case "BAJA":
                if (probability < 5)
                {
                    complexity = "BAJA";
                }
                else if (probability < 8)
                {
                    complexity = "MEDIA";
                }
                else
                {
                    complexity = "ALTA";
                }
                break;
            case "MEDIA":
                if (probability < 3)
                {
                    complexity = "BAJA";
                }
                else if (probability < 8)
                {
                    complexity = "MEDIA";
                }
                else
                {
                    complexity = "ALTA";
                }
                break;

            case "ALTA":

                if (probability < 2)
                {
                    complexity = "BAJA";
                }
                else if (probability < 5)
                {
                    complexity = "MEDIA";
                }
                else
                {
                    complexity = "ALTA";
                }
                break;
            default:
                break;
        }

        Patron();

    }

    private void Patron()
    {

        patronView.StartPatron(complexity);
        InterfaceManager.Instance.ShowScreen(gamePatron);
        main.gameObject.SetActive(true);

    }



    public void off()
    {
        InterfaceManager.Instance.HideScreen(gamePatron);
        main.gameObject.SetActive(true);
    }

    public void offmedium()
    {
        InterfaceManager.Instance.HideScreen(gamePatron);
        main.gameObject.SetActive(true);
        buttonCuadrilla.gameObject.SetActive(true);
        buttonCuadrilla.interactable = true;
        buttonEquipo.gameObject.SetActive(false);
        Equipoteams.gameObject.SetActive(false);

    }


    public void endmedium()
    {
        main.gameObject.SetActive(true);
        buttonCuadrilla.gameObject.SetActive(false);
        buttonEquipo.gameObject.SetActive(true);
        Cuadrilla.gameObject.SetActive(false);
        Equipoteams.gameObject.SetActive(false);

    }

    public void High()
    {
        Cuadrilla.gameObject.SetActive(false);
        main.gameObject.SetActive(true);
        buttonCuadrilla.gameObject.SetActive(false);
        buttonEquipo.gameObject.SetActive(false);

        if (Cuadrilla.gameObject.activeSelf || buttonEquipo.enabled) {
            Equipoteams.gameObject.SetActive(true);
            Equipoteams.interactable = true;
            Cuadrilla.gameObject.SetActive(false);
            main.gameObject.SetActive(true);
            buttonCuadrilla.gameObject.SetActive(false);
            buttonEquipo.gameObject.SetActive(false);
        }


    }


    public void EndHig() {

        Equipo.gameObject.SetActive(false);
        buttonEquipo.gameObject.SetActive(false);
        buttonCuadrilla.gameObject.SetActive(false);
    }

    public void CodeInterface()
    {
        InterfaceManager.Instance.ShowScreen(Code);
    }

    public void CodeOff()
    {
        InterfaceManager.Instance.HideScreen(Code);

     

    }
}
