using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class State : MonoBehaviour
{

    private PrefabsIncidents prefabsIncidents;
    [SerializeField]
    public Button button;
    [SerializeField]
    private bool state;
    [SerializeField]
    private PanelPlaceandIncidents panelPlaceandIncidents;
    [SerializeField]
    private Zones currentZone;
    [SerializeField]
    private Transform transform;
    [SerializeField]
    private Text severity, informartion;
    private Fail fail;
    [SerializeField]
    private ZoneManager zone;
    public bool stateButton;
    [SerializeField]
    private int numState;
    [SerializeField]
    private Patron patron;
    [SerializeField]
    private States states;
    public Details details;
    [SerializeField]
    private Text cuadrillaText;
    [SerializeField]
    private Button Monitoring;
    [SerializeField]
    private Button Cuadrilla;
    [SerializeField]
    private Button Equipo;
    [SerializeField]
    private GameObject teams;
    [SerializeField]
    private GameObject cuadril;
    [SerializeField]
    private Cuadrilla cuadri;
    private string sevesave;
    [SerializeField]
    private CuadrillaManager cuadrillaManager;
    [SerializeField]
    private Teams team;
    private float probability;
    public string complexity;
    [SerializeField]
    private Text monitoring;
    [SerializeField]
    private Code code;
    public bool stateRandom = false;
    [SerializeField]
    private Alert alert;
    [SerializeField]
    private Text textfirst;
    public bool State1 { get => state; set => state = value; }
    public Zones CurrentZone { get => currentZone; set => currentZone = value; }
    public PrefabsIncidents PrefabsIncidents { get => prefabsIncidents; set => prefabsIncidents = value; }
    public Fail Fail { get => fail; set => fail = value; }
    public int NumState { get => numState; set => numState = value; }
    public States States { get => states; set => states = value; }
    public string Sevesave { get => sevesave; set => sevesave = value; }
    public Cuadrilla Cuadri { get => cuadri; set => cuadri = value; }
    public string Complexity1 { get => complexity; set => complexity = value; }

    public void Incidents(PrefabsIncidents prefab)
    {
        PrefabsIncidents = prefab;
        Fail = prefab.Fail;
        button.GetComponent<Image>().sprite = PrefabsIncidents.SpriteIn;
        state = true;
        probability = Random.Range(0, 11);
        var details = new Details();


        switch (Fail)
        {
            case Fail.DAÑO_AMBIENTAL:
                details.CreateDetails(SingletonInformation.Instance.errorsAmbienta[Random.Range(0, SingletonInformation.Instance.errorsAmbienta.Count)], SingletonInformation.Instance.services[Random.Range(0, SingletonInformation.Instance.services.Count)]);
                break;
            case Fail.IMPREVISTO:
                details.CreateDetails(SingletonInformation.Instance.errorsImprevisto[Random.Range(0, SingletonInformation.Instance.errorsImprevisto.Count)], SingletonInformation.Instance.services[Random.Range(0, SingletonInformation.Instance.services.Count)]);
                break;
            case Fail.FALLA:
                details.CreateDetails(SingletonInformation.Instance.errorsFalla[Random.Range(0, SingletonInformation.Instance.errorsFalla.Count)], SingletonInformation.Instance.services[Random.Range(0, SingletonInformation.Instance.services.Count)]);
                break;
            case Fail.MANTENIMIENTO:
                details.CreateDetails(SingletonInformation.Instance.errorMante[Random.Range(0, SingletonInformation.Instance.errorMante.Count)], SingletonInformation.Instance.services[Random.Range(0, SingletonInformation.Instance.services.Count)]);
                break;
            default:
                break;
        }
        details.num = numState;
        this.details = details;
        Complexity();
    }

    public void Points() {
        zone.Points(Fail);
    }

    public void PointsMinime()
    {
        zone.PointsMinime(Fail);
    }

    public void IncidentsPlaces()
    {
        textfirst.gameObject.SetActive(false);
        alert.PlaySound();
        SingletonInformation.Instance.probability = probability;
        cuadrillaText.text = "SOLUCIÓN REMOTA";
        panelPlaceandIncidents.Place(currentZone.ToString().Replace("_", "  "));
        cuadrillaManager.Num = numState;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        zone.CountZone(Fail, numState);

        cuadrillaManager.SaveCuadrillaCode();


        if (States == States.First)
        {
            Monitoring.interactable = true;
            Monitoring.gameObject.SetActive(true);
            Cuadrilla.gameObject.SetActive(false);
            teams.gameObject.SetActive(false);
            cuadril.gameObject.SetActive(false);
            Equipo.gameObject.SetActive(false);

            patron.ButtonDisable(fail, button, currentZone, this);
        }

        else if (States == States.Second)
        {
            Monitoring.gameObject.SetActive(false);
            Cuadrilla.gameObject.SetActive(true);
            Cuadrilla.interactable = true;
            teams.gameObject.SetActive(false);
            Equipo.gameObject.SetActive(false);

            Cuadri.SaveCuadrilla(currentZone, button, sevesave, fail, this);
            monitoring.text = "solución insuficiente, es necesario enviar una cuadrilla ";
        }

        else if (States == States.Three)
        {
            code.SaveCuadrilla(numState);
            Cuadri.SaveCuadrilla(currentZone, button, sevesave, fail, this);
            Monitoring.gameObject.SetActive(false);
            Cuadrilla.gameObject.SetActive(false);
            cuadril.gameObject.SetActive(false);
            Equipo.gameObject.SetActive(true);
            Equipo.interactable = true;
            team.SaveTeams(button, fail);
            monitoring.text = "solución insuficiente, es necesario enviar un Equipo ";

        }
    }

    private void Complexity() {

        switch (details.severity)
        {
            case "BAJA":
                if (probability < 8)
                {
                    complexity = "BAJA";
                }
                else if (probability < 10)
                {
                    complexity = "MEDIA";
                }
                else
                {
                    complexity = "ALTA";
                }
                break;
            case "MEDIA":
                if (probability < 4)
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

    }


}







public enum Zones
{
    ZONA_SANTA_ANA,
    ZONA_SANTA_BÁRBARA,
    ZONA_SAN_PEDRO,
    ZONA_SAN_JUAN,
    ZONA_SAN_MATEO
}
