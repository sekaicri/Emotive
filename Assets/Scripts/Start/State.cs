using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class State : MonoBehaviour
{

    private PrefabsIncidents prefabsIncidents;
    [SerializeField]
    private Button button;
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
    public int numero;


    public bool State1 { get => state; set => state = value; }
    public Zones CurrentZone { get => currentZone; set => currentZone = value; }
    public PrefabsIncidents PrefabsIncidents { get => prefabsIncidents; set => prefabsIncidents = value; }

    public void Incidents(PrefabsIncidents prefab) {
        this.gameObject.SetActive(true);
        PrefabsIncidents = prefab;
        fail = prefab.Fail;
        button.GetComponent<Image>().sprite = PrefabsIncidents.SpriteIn;
        state = true;
    }

    public void IncidentsPlaces()
    {
        panelPlaceandIncidents.Place(currentZone.ToString().Replace("_","  "));

        severity.text = "";
        informartion.text = "";
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }


        numero = int.Parse(button.name.ToString());
        zone.CountZone(fail,numero);
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