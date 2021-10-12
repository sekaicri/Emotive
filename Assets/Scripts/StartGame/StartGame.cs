using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    [SerializeField]
    private List<ZoneManager> zoneManagers = new List<ZoneManager>();
    [SerializeField]
    private AssignedPoints assignedPoints;
    [SerializeField]
    private Patron patron;
    [SerializeField]
    private Timer time;
    [SerializeField]
    private History history;
    [SerializeField]
    private Incidents incidents;
    [SerializeField]
    private FontPre fontPre;
    [SerializeField]
    private EraserAll eraser;
    [SerializeField]
    private List<Cuadrilla> Cuadrillas = new List<Cuadrilla>();
    [SerializeField]
    private Teams teams;
    [SerializeField]
    private CuadrillaManager cuadrilla;
    [SerializeField]
    private Score score;
    [SerializeField]
    private VarEmotiv varEmotiv;
    [SerializeField]
    private ElementIdentifier Show;
    [SerializeField]
    private ElementIdentifier hide;
    [SerializeField]
    private ElementIdentifier hide2;

    [SerializeField]
    private GameObject buttonMoni;
    public void StartGames()
    {
        InterfaceManager.Instance.ShowScreen(Show);
        InterfaceManager.Instance.HideScreen(hide);
        InterfaceManager.Instance.HideScreen(hide2);


        foreach (var s in zoneManagers) {
            s.PointsEraser();
        }

        assignedPoints.Pointstart();
        patron.EraserAgain();
        time.StartTimer();
        history.HistoryDates();
        incidents.StartGame();
        fontPre.ButtonsPre1();
        eraser.EraserALL();
        foreach (var s in Cuadrillas)
        {
            s.Eraser();
        }
        teams.Eraser();
        cuadrilla.Eraser();
        score.StartPoints();
        buttonMoni.gameObject.SetActive(false);
    }
 
    public void StartWitout() {
        varEmotiv.tartVar();
    }


    public void StartWiht()
    {
        varEmotiv.StartVar();
    }
}
