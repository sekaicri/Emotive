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
    [SerializeField]
    private List<string> errors = new List<string>();
    [SerializeField]
    private List<string> services = new List<string>();
    [SerializeField]
    List<Details> tempt = new List<Details>();
    List<Details> tempt1 = new List<Details>();
    List<Details> tempt2 = new List<Details>();
    List<Details> tempt3 = new List<Details>();



    private State stateChild;
    private int n;

    private Fail fail1;

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
        this.n = n;
        fail1 = fail;
        PrefabCreate();
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
            if (fail1 == Fail.DAÑO_AMBIENTAL) { 
            patron.text.fontStyle = FontStyle.Bold;
            }
            patron.text.text = Fail.DAÑO_AMBIENTAL.ToString().Replace("_", " ");
            patron.score.text = ($"{envir}/{ environmentalDamage}");
            patron.typeFail = Fail.DAÑO_AMBIENTAL;
            int i = 0;

            if (tempt.Count > 0)
            {
                foreach (var s in tempt)
                {
                    patron.details.Add(s);
                }
            }
            else
            {

                do
                {
                    var details = new Details();
                    details.CreateDetails(errors[Random.Range(0, errors.Count)], services[Random.Range(0, services.Count)]);
                    patron.details.Add(details);
                    tempt.Add(details);

                    i++;
                }
                while (i < environmentalDamage);
            }
        }

        if (unexpected > 0)
        {
            FailPrefab patron = Instantiate(failPrefab, transform1);
            patron.image.sprite = incidents.Sprite[1];
            if (fail1 == Fail.IMPREVISTO)
            {
                patron.text.fontStyle = FontStyle.Bold;
            }
            patron.text.text = Fail.IMPREVISTO.ToString();
            patron.typeFail = Fail.IMPREVISTO;

            patron.score.text = ($"{unexpe}/{ unexpected}");
            int i = 0;

            if (tempt1.Count > 0)
            {

                foreach (var s in tempt1)
                {
                    patron.details.Add(s);
                }
            }
            else
            {
                do
                {
                    var details = new Details();
                    details.CreateDetails(errors[Random.Range(0, errors.Count)], services[Random.Range(0, services.Count)]);
                    patron.details.Add(details);
                    tempt1.Add(details);
                    i++;
                }
                while (i < unexpected);

            }

        }
        if (failure > 0)
        {
            FailPrefab patron = Instantiate(failPrefab, transform1);
            patron.image.sprite = incidents.Sprite[2];
            if (fail1 == Fail.FALLA)
            {
                patron.text.fontStyle = FontStyle.Bold;
            }
            
            patron.text.text = Fail.FALLA.ToString();
            patron.typeFail = Fail.FALLA;

            patron.score.text = ($"{failu}/{failure}");
            int i = 0;

            if (tempt2.Count > 0)
            {

                foreach (var s in tempt2)
                {
                    patron.details.Add(s);
                }
            }
            else
            {
                do
                {
                    var details = new Details();
                    details.CreateDetails(errors[Random.Range(0, errors.Count)], services[Random.Range(0, services.Count)]);
                    patron.details.Add(details);
                    tempt2.Add(details);
                    i++;
                }

                while (i < failure);
            }
        }
        if (maintenance > 0)
        {
            FailPrefab patron = Instantiate(failPrefab, transform1);
            patron.image.sprite = incidents.Sprite[3];
            if (fail1 == Fail.MANTENIMIENTO)
            {
                patron.text.fontStyle = FontStyle.Bold;
            }
            patron.text.text = Fail.MANTENIMIENTO.ToString();
            patron.typeFail = Fail.MANTENIMIENTO;

            patron.score.text = ($"{mainte}/{ maintenance}");
            int i = 0;

            if (tempt3.Count > 0)
            {
                foreach (var s in tempt3)
                {
                    patron.details.Add(s);

                }
            }
            else
            {
                do
                {
                    var details = new Details();
                    details.CreateDetails(errors[Random.Range(0, errors.Count)], services[Random.Range(0, services.Count)]);
                    patron.details.Add(details);
                    tempt3.Add(details);
                    i++;
                }
                while (i < maintenance);
            }
        }

        CreateAll();
    }


    public void CreateAll()
    {
        List<State> temp = new List<State>();
        Out current=new Out();
        foreach (var item in state)
        {
            if (item.Fail == fail1)
            {
                temp.Add(item);
            }
        }
        foreach (Transform child in transform1)
        {
            if (child.GetComponent<FailPrefab>().typeFail == fail1)
            {
                current = child.GetComponent<Out>();
            }
            //  child.gameObject.GetComponent<Out>().CreateDetail(fail1,n);

        }

      
            for (int i = 0; i < temp.Count; i++)
            {
                current.Fail.details[i].num = temp[i].Numero;
        }
        current.CreateDetail(fail1, n);

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