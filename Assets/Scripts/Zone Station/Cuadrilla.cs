using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Cuadrilla : MonoBehaviour
{

    [SerializeField]
    private Button button;
    [SerializeField]
    private Text severityScene;
    [SerializeField]
    private List<TMP_Text> texts = new List<TMP_Text>();
    private Zones currentZonePatron;
    [SerializeField]
    private Image cuadrillasZone;
    [SerializeField]
    private Button disable;
    private Button ubication;
    [SerializeField]
    private FontPre fontPre;
    private int num;
    [SerializeField]
    private UILineRenderer lr;
    private Vector2 ubi;
    [SerializeField]
    private int timer;
    private string severityCua;
    private Fail failcua;
    [SerializeField]
    private Incidents Points;
    [SerializeField]
    private InterfaceGame interfaceGame;
    [SerializeField]
    private Teams teams;
    private State state;
    [SerializeField]
    private List<PrefabFilled> prefabFilleds = new List<PrefabFilled>();
    [SerializeField]
    private Button button1;
    [SerializeField]
    private Button button2;
    [SerializeField]
    private Button button3;
    private string severity;
    [SerializeField]
    private Score Score;

    [SerializeField]
    private Button equipo;
    [SerializeField]
    private Text monitoring;




    public void Eraser()
    {
        StopAllCoroutines();

        foreach (var s in prefabFilleds)
        {
            s.image.gameObject.SetActive(false);
            s.filed.fillAmount = 0;

        }

       
       cuadrillasZone.gameObject.SetActive(false);
        

        foreach (var s in texts)
        {
            s.fontStyle = TMPro.FontStyles.Normal;
            s.fontSize = 35;
        }
        button1.interactable = true;
        button1.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
        button2.interactable = true;
        button2.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
        button3.interactable = true;
        button3.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";

        StopAllCoroutines();

    }

    public void ButttonDisable()
    {
        disable.interactable = false;
    }
    public void CuadrillaStart(string severity)
    {
        this.severity = severity;
        if (severityScene.text == severity)
        {
            foreach (var s in texts)
            {
                if (s.text[0] == severity[0])
                {
                    s.fontStyle = TMPro.FontStyles.Underline;
                    s.fontSize = 40;

                }
            }
            button.interactable = true;
        }
        else
        {
            foreach (var s in texts)
            {
                s.fontStyle = TMPro.FontStyles.Normal;
                s.fontSize = 35;
            }
            button.interactable = false;

            ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.NotiEmotiv, "ESTA CUADRILLA NO ESTA EQUIPADA PARA SOLUCIONAR ESTE PROBLEMA", null);
            InAppNotification1.Instance.ShowNotication(notification);
        }
    }


    public void SaveCuadrilla(Zones currentZone, Button button, string severity, Fail fail, State states)

    {
        state = states;
        currentZonePatron = currentZone;
        ubication = button;
        severityCua = severity;
        failcua = fail;
    }

    public void CuadrillaAssigne()
    {
        switch (severity)
        {
            case "BAJA":
                button1.interactable = false;
                button1.transform.GetChild(0).GetComponent<Text>().text = "OCUPADO";
                break;
            case "MEDIA":
                button2.interactable = false;
                button2.transform.GetChild(0).GetComponent<Text>().text = "OCUPADO";
                break;
            case "ALTA":
                button3.interactable = false;
                button3.transform.GetChild(0).GetComponent<Text>().text = "OCUPADO";
                break;
            default:
                break;
        }

        ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.NotiEmotiv, "¡EXCELENTE! \nLA CUADRILLA ESTÁ EN CAMINO.", null);
        InAppNotification1.Instance.ShowNotication(notification);
        button.interactable = false;

        cuadrillasZone.gameObject.SetActive(true);
        StartCoroutine(LineDraw());


    }

    public IEnumerator LineDraw()
    {

        lr.color = Color.white;

        yield return new WaitForSeconds(1);
        Vector2 orig = new Vector2();
        Vector2 orig2 = new Vector2();
        foreach (var s in fontPre.Buttons)
        {
            if (ubication == s)
            {
                orig = new Vector2(cuadrillasZone.GetComponent<RectTransform>().localPosition.x, cuadrillasZone.GetComponent<RectTransform>().localPosition.y);
                orig2 = new Vector2(s.GetComponent<RectTransform>().localPosition.x, s.GetComponent<RectTransform>().localPosition.y);
                ubi = orig2;
            }
        }
        lr.Points[0] = orig;

        float t = 0;
        float time = 2;

        Vector2 newpos;
        for (; t < time; t += Time.deltaTime)
        {
            newpos = Vector2.Lerp(orig, orig2, t / time);
            var point = newpos;
            var pointlist = new List<Vector2>(lr.Points);
            pointlist.Add(point);
            lr.Points = pointlist.ToArray();
            yield return null;
        }

        if (severityCua == "ALTA")
        {
            StartCoroutine(CuadrillaHigh());

        }
        else
        {
            StartCoroutine(CuadrillaFilled());

        }
    }


    private IEnumerator CuadrillaFilled()
    {
        lr.Points = new Vector2[1];

        prefabFilleds[state.NumState - 1].image.gameObject.SetActive(true);
        for (float i = 0; i < 10; i += Time.deltaTime * timer)
        {
            prefabFilleds[state.NumState - 1].filed.fillAmount = i / 10;
            prefabFilleds[state.NumState - 1].filed.color = Color.green;
            yield return null;
        }

        CuadrillaEnd();
    }


    private IEnumerator CuadrillaHigh()
    {
        lr.Points = new Vector2[1];

        prefabFilleds[state.NumState - 1].image.gameObject.SetActive(true);

        for (float i = 0; i < 7; i += Time.deltaTime * timer)
        {
            prefabFilleds[state.NumState - 1].filed.fillAmount = i / 10;
            prefabFilleds[state.NumState - 1].filed.color = Color.Lerp(Color.green, Color.red, i / 10);
            yield return null;
        }


        ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.NotiEmotiv, "¡TENEMOS UN IMPREVISTO! LA CUADRILLA HA LOGRADO DAR SOLUCIÓN PARCIAL AL INCIDENTE, EN LA PESTAÑA DE EQUIPOS PODRÁ TERMINAR  LA TAREA ENVIANDO REFUERZOS.", null);
        InAppNotification1.Instance.ShowNotication(notification);
        interfaceGame.High();
        teams.SaveTeams(ubication, failcua);
        monitoring.text = "solución insuficiente, es necesario enviar un Equipo ";


        foreach (var s in SingletonInformation.Instance.states)
        {
            if (state == s)
            {

                s.States = States.Three;
            }
        }

    }



    public IEnumerator LineDrawEND()
    {
        prefabFilleds[state.NumState - 1].image.gameObject.SetActive(false);


        yield return new WaitForSeconds(1);
        Vector2 orig = new Vector2();
        Vector2 orig2 = new Vector2();
        foreach (var s in fontPre.Buttons)
        {
            if (ubication == s)
            {
                orig2 = new Vector2(cuadrillasZone.GetComponent<RectTransform>().localPosition.x, cuadrillasZone.GetComponent<RectTransform>().localPosition.y);
                orig = new Vector2(s.GetComponent<RectTransform>().localPosition.x, s.GetComponent<RectTransform>().localPosition.y);
                ubi = orig2;
            }
        }
        lr.Points[0] = orig;

        float t = 0;
        float time = 2;

        Vector2 newpos;
        for (; t < time; t += Time.deltaTime)
        {
            newpos = Vector2.Lerp(orig, orig2, t / time);
            var point = newpos;
            var pointlist = new List<Vector2>(lr.Points);
            pointlist.Add(point);
            lr.Points = pointlist.ToArray();
            yield return null;
        }

        TeamsEnd1();

    }
    public void TeamsEnd1()
    {

        prefabFilleds[state.NumState - 1].image.gameObject.SetActive(false);
        prefabFilleds[state.NumState - 1].filed.fillAmount = 0;
        lr.Points = new Vector2[1];
        cuadrillasZone.gameObject.SetActive(false);
    }


    public void TeamsEnd()
    {
        StartCoroutine(CuadrillaHighEnd());
    }


    private IEnumerator CuadrillaHighEnd()
    {

        foreach (var s in SingletonInformation.Instance.states)
        {
            if (state == s)
            {
                s.Points();

            }
        }

        lr.color = Color.blue;
        yield return new WaitForSeconds(1);
        Vector2 orig = new Vector2();
        Vector2 orig2 = new Vector2();
        foreach (var s in fontPre.Buttons)
        {
            if (ubication == s)
            {
                orig = new Vector2(cuadrillasZone.GetComponent<RectTransform>().localPosition.x, cuadrillasZone.GetComponent<RectTransform>().localPosition.y);
                orig2 = new Vector2(s.GetComponent<RectTransform>().localPosition.x, s.GetComponent<RectTransform>().localPosition.y);
                ubi = orig2;
            }
        }
        lr.Points[0] = orig;

        float t = 0;
        float time = 2;

        Vector2 newpos;
        for (; t < time; t += Time.deltaTime)
        {
            newpos = Vector2.Lerp(orig, orig2, t / time);
            var point = newpos;
            var pointlist = new List<Vector2>(lr.Points);
            pointlist.Add(point);
            lr.Points = pointlist.ToArray();
            yield return null;
        }


        equipo.gameObject.SetActive(false);
        equipo.interactable = false;

        switch (severity)
        {
            case "BAJA":
                button1.interactable = true;
                button1.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            case "MEDIA":
                button2.interactable = true;
                button2.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            case "ALTA":
                button3.interactable = true;
                button3.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            default:
                break;

        }

     


        lr.Points = new Vector2[1];


        foreach (var s in texts)
        {
            s.fontStyle = TMPro.FontStyles.Normal;
            s.fontSize = 35;
        }

        for (float i = 7; i < 10; i += Time.deltaTime * timer)
        {
            prefabFilleds[state.NumState - 1].filed.fillAmount = i / 10;
            prefabFilleds[state.NumState - 1].filed.color = Color.Lerp(Color.red, Color.green, i / 10);
            yield return null;
        }


        foreach (var s in fontPre.Buttons)
        {
            if (ubication == s)
            {
                s.interactable = false;
            }
        }
 
        ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.EndTarea, "TAREA FINALIZADA", null);
        InAppNotification1.Instance.ShowNotication(notification);

        Score.ScorePoints("ALTA");

        Points.Points(failcua);
        interfaceGame.EndHig();


        StartCoroutine(LineDrawEND());
  



    }


    private void CuadrillaEnd()
    {



        foreach (var s in SingletonInformation.Instance.states)
        {
            if (state == s)
            {
                s.Points();

            }
        }

        switch (severity)
        {
            case "BAJA":
                button1.interactable = true;
                button1.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            case "MEDIA":
                button2.interactable = true;
                button2.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            case "ALTA":
                button3.interactable = true;
                button3.transform.GetChild(0).GetComponent<Text>().text = "DISPONIBLE";
                break;
            default:
                break;
        }
        prefabFilleds[state.NumState - 1].image.gameObject.SetActive(false);
        prefabFilleds[state.NumState - 1].filed.fillAmount = 0;
        Points.Points(failcua);
        cuadrillasZone.gameObject.SetActive(false);
        foreach (var s in fontPre.Buttons)
        {
            if (ubication == s)
            {
                s.interactable = false;
            }
        }
        ClasNotiEmotiv notification = new ClasNotiEmotiv(EnumNotiEmotiv.EndTarea, "TAREA FINALIZADA", null);
        InAppNotification1.Instance.ShowNotication(notification);
        interfaceGame.endmedium();
        Score.ScorePoints(severityCua);

        foreach (var s in texts)
        {
            s.fontStyle = TMPro.FontStyles.Normal;
            s.fontSize = 35;
        }
    }

}

