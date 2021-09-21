using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Patron : MonoBehaviour
{

    [SerializeField]
    private GridLayoutGroup layaout;
    [SerializeField]
    private PatronView patronView;
    [SerializeField]
    private PrefabsPoint point;
    [SerializeField]
    private Points points;
    public List<List<PrefabsPoint>> planeList = new List<List<PrefabsPoint>>();
    [SerializeField]
    private InterfaceGame interfaceGame;
    private Button state;
    [SerializeField]
    private FontPre fontPre;
    private string severity;
    [SerializeField]
    private Text monitoring;
    private Fail fail;
    [SerializeField]
    private Incidents Points;

    private State states;
    [SerializeField]
    private Score Score;

    private Zones currentZonePatron;

    public void CreatePlane(string severity)
    {
        this.severity = severity;
        foreach (List<PrefabsPoint> item in planeList)
        {
            foreach (PrefabsPoint item1 in item)
            {
                DestroyImmediate(item1.gameObject);
            }
        }

        planeList = new List<List<PrefabsPoint>>();

        planeList.Clear();


        layaout.constraintCount = patronView.x;
        points.xy = patronView.xy;

        for (int i = 0; i < patronView.xy; i++)
        {
            List<PrefabsPoint> plane = new List<PrefabsPoint>();
            PrefabsPoint patron = Instantiate(point, transform);
            plane.Add(patron);
            planeList.Add(plane);
        }
    }


    public void Check()
    {
        List<int> numSave = new List<int>();
        foreach (List<PrefabsPoint> item in planeList)
        {
            foreach (PrefabsPoint item1 in item)
            {
                string num = item1.num.text.ToString();
                int tempt = int.Parse(num);
                numSave.Add(tempt);
            }
        }


        int temp = 0;
        for (int i = 0; i < patronView.xy; i++)
        {
            if (numSave[i] == patronView.save[i])
            {
                temp++;
            }
        }

        if (temp == patronView.xy)
        {
            patronView.Again = true;

            if (severity == "MEDIA")
            {

                ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.Two, "TAREA FINALIZADA, CON NOVEDADES", "LA ASISTENCIA REMOTA NO HA LOGRADO DAR SOLUCIÓN AL INCIDENTE, ASIGNE UNA CUADRILLA PARA ATENDER EL INCIDENTE.");
                InAppNotification1.Instance.ShowNotication(notification);
                monitoring.text = "solución insuficiente, es necesario enviar una cuadrilla ";
                interfaceGame.offmedium();
                foreach (var s in SingletonInformation.Instance.states)
                {
                    if (states == s)
                    {
                        s.States = States.Second;
                        s.Sevesave = severity;
                        s.Cuadri.SaveCuadrilla(currentZonePatron, state, "MEDIA", fail, states);
                    }
                }
            }

            else if (severity == "ALTA")
            {

                ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.Two, "TAREA FINALIZADA, CON NOVEDADES", "LA ASISTENCIA REMOTA NO HA LOGRADO DAR SOLUCIÓN AL INCIDENTE, ASIGNE UNA CUADRILLA PARA ATENDER EL INCIDENTE.");
                InAppNotification1.Instance.ShowNotication(notification);
                monitoring.text = "solución insuficiente, es necesario enviar una cuadrilla ";
                interfaceGame.offmedium();

                foreach (var s in SingletonInformation.Instance.states)
                {
                    if (states == s)
                    {
                        s.States = States.Second;
                        s.Sevesave =severity ;
                        s.Cuadri.SaveCuadrilla(currentZonePatron, state, "ALTA", fail, states);

                    }
                }
            }

            // Correcto Baja -------------------------------------------------------------------------------------------

            else if (severity == "BAJA")
            {
                interfaceGame.off();

                foreach (var s in fontPre.Buttons)
                {
                    if (state == s)
                    {
                        s.interactable = false;
                        
                    }
                }

                ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.EndTarea, "TAREA FINALIZADA", null);
                InAppNotification1.Instance.ShowNotication(notification);
                Points.Points(fail);
                Score.ScorePoints(severity);
            }

            // Correcto Baja ------------------------------------------------------------------------------------------
            Draw.Instance.eraserLine();
        }
        else
        {
            Draw.Instance.eraserLine();
            Debug.Log("incorrecto papi");
            CreatePlane(severity);
            Num.Instance.temp = 0;
        }
    }
    public void ButtonDisable(Fail fail, Button button, Zones currentZone, State states)
    {
        this.states = states;
        state = button;
        this.fail = fail;
        currentZonePatron = currentZone;
    }

}
