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

        this.gameObject.SetActive(true);
        PrefabsIncidents = prefab;
        Fail = prefab.Fail;
        button.GetComponent<Image>().sprite = PrefabsIncidents.SpriteIn;
        state = true;
        probability = Random.Range(0, 11);
        var details = new Details();
        details.CreateDetails(SingletonInformation.Instance.errors[Random.Range(0, SingletonInformation.Instance.errors.Count)], SingletonInformation.Instance.services[Random.Range(0, SingletonInformation.Instance.services.Count)]);
        details.num = numState;
        this.details = details;
        Complexity();
    }

    public void Points() {
        zone.Points(Fail);
    }
    public void IncidentsPlaces()
    {

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
                if (probability < 5)
                {
                    Complexity1 = "BAJA";
                }
                else if (probability < 8)
                {
                    Complexity1 = "MEDIA";
                }
                else
                {
                    Complexity1 = "ALTA";
                }
                break;
            case "MEDIA":
                if (probability < 3)
                {
                    Complexity1 = "BAJA";
                }
                else if (probability < 8)
                {
                    Complexity1 = "MEDIA";
                }
                else
                {
                    Complexity1 = "ALTA";
                }
                break;

            case "ALTA":

                if (probability < 2)
                {
                    Complexity1 = "BAJA";
                }
                else if (probability < 5)
                {
                    Complexity1 = "MEDIA";
                }
                else
                {
                    Complexity1 = "ALTA";
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
    ZONA_GRAN_LINE,
    ZONA_RER_LINE,
    ZONA_WATER_7,
    ZONA_WANO
}
