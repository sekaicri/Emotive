using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZoneManager : MonoBehaviour
{
    [SerializeField]
    private List<State> state = new List<State>();
    private int environmentalDamage;
    private int unexpected;
    private int failure;
    private int maintenance;
    private int envir = 0;
    private int unexpe = 0;
    private int failu = 0;
    private int mainte = 0;
    [SerializeField]
    private FailPrefab failPrefab;
    [SerializeField]
    private Incidents incidents;
    [SerializeField]
    private Transform transform1;
    private State stateChild;
    private int n;
    private Fail failState;
    [SerializeField]
    private Out panel;


    private bool sta;
    private void Reset()
    {
        GetAllChildStates();
    }

    public void CountZone(Fail fail, int n)
    {

        foreach (Transform child in transform1)
        {
            DestroyImmediate(child.gameObject);

        }

        environmentalDamage = 0;
        unexpected = 0;
        failure = 0;
        maintenance = 0;


        foreach (var s in state)
        {

            if (s.gameObject.activeSelf)
            {
                switch (s.PrefabsIncidents.Fail)
                {
                    case Fail.DAÑO_AMBIENTAL:
                        environmentalDamage++;
                        break;
                    case Fail.IMPREVISTO:
                        unexpected++;
                        break;
                    case Fail.FALLA:
                        failure++;
                        break;
                    case Fail.MANTENIMIENTO:
                        maintenance++;
                        break;
                    default:
                        break;
                }

            }
        }
        sta = false;
        this.n = n;
        failState = fail;
        PrefabCreate();
    }

    public void Points(Fail fail)
    {
     

            switch (fail)
            {
                case Fail.DAÑO_AMBIENTAL:
                    envir++;
                    break;
                case Fail.IMPREVISTO:
                    unexpe++;
                    break;
                case Fail.FALLA:
                    failu++;
                    break;
                case Fail.MANTENIMIENTO:
                    mainte++;
                    break;
                default:
                    break;

            }
        
    }

    public void PointsMinime(Fail fail)
    {
        

            switch (fail)
            {
                case Fail.DAÑO_AMBIENTAL:
                    envir--;
                    break;
                case Fail.IMPREVISTO:
                    unexpe--;
                    break;
                case Fail.FALLA:
                    failu--;
                    break;
                case Fail.MANTENIMIENTO:
                    mainte--;
                    break;
                default:
                    break;
            }

        

    }


    public void PointsEraser()
    {
        envir = 0;
        unexpe = 0;
        failu = 0;
        mainte = 0;
    }



    private void PrefabCreate()
    {
        foreach (Transform child in transform1)
        {
            DestroyImmediate(child.gameObject);
        }


        if (environmentalDamage > 0)
        {
            FailPrefab patron = Instantiate(failPrefab, transform1);
            patron.image.sprite = incidents.Sprite[0];
            if (failState == Fail.DAÑO_AMBIENTAL)
            {
                patron.text.fontStyle = FontStyle.Bold;
            }
            patron.text.text = Fail.DAÑO_AMBIENTAL.ToString().Replace("_", " ");
            patron.score.text = ($"{envir}/{ environmentalDamage}");
            patron.typeFail = Fail.DAÑO_AMBIENTAL;
        }

        if (unexpected > 0)
        {
            FailPrefab patron = Instantiate(failPrefab, transform1);
            patron.image.sprite = incidents.Sprite[1];
            if (failState == Fail.IMPREVISTO)
            {
                patron.text.fontStyle = FontStyle.Bold;
            }
            patron.text.text = Fail.IMPREVISTO.ToString();
            patron.typeFail = Fail.IMPREVISTO;
            patron.score.text = ($"{unexpe}/{ unexpected}");

        }
        if (failure > 0)
        {
            FailPrefab patron = Instantiate(failPrefab, transform1);
            patron.image.sprite = incidents.Sprite[2];
            if (failState == Fail.FALLA)
            {
                patron.text.fontStyle = FontStyle.Bold;
            }
            patron.text.text = Fail.FALLA.ToString();
            patron.typeFail = Fail.FALLA;
            patron.score.text = ($"{failu}/{failure}");

        }
        if (maintenance > 0)
        {
            FailPrefab patron = Instantiate(failPrefab, transform1);
            patron.image.sprite = incidents.Sprite[3];
            if (failState == Fail.MANTENIMIENTO)
            {
                patron.text.fontStyle = FontStyle.Bold;
            }
            patron.text.text = Fail.MANTENIMIENTO.ToString();
            patron.typeFail = Fail.MANTENIMIENTO;
            patron.score.text = ($"{mainte}/{ maintenance}");


        }
        if (!sta)
        {
            CreateAll();
        }
    }


    public void CreateAll()
    {
        List<State> temp = new List<State>();

        foreach (var item in state)
        {
            if (item.Fail == failState)
            {
                temp.Add(item);
            }
        }
        panel.CreateDetail(temp, n);



    }

    [EasyButtons.Button]
    public void GetAllChildStates()
    {
        foreach (Transform child in transform1)
        {
            state.Add(child.GetComponent<State>());
        }
    }

}