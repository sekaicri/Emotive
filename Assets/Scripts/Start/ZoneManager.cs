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
    private Transform transform;
    [SerializeField]
    private List<string> errors = new List<string>();
    [SerializeField]
    private List<string> services = new List<string>();

    List<Details> tempt = new List<Details>();
    List<Details> tempt1 = new List<Details>();
    List<Details> tempt2 = new List<Details>();
    List<Details> tempt3 = new List<Details>();



    private void Reset()
    {
        GetAllChildStates();
    }

    public void CountZone()
    {

        foreach (Transform child in transform)
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
                    case Fail.environmentalDamage:
                        environmentalDamage++;
                        break;
                    case Fail.unexpected:
                        unexpected++;
                        break;
                    case Fail.failure:
                        failure++;
                        break;
                    case Fail.maintenance:
                        maintenance++;
                        break;
                    default:
                        break;
                }

            }
        }

        PrefabCreate();

    }


    private void PrefabCreate()
    {
        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);

        }


        if (environmentalDamage > 0)
        {
            FailPrefab patron = Instantiate(failPrefab, transform);
            patron.image.sprite = incidents.Sprite[0];
            patron.text.text = "DAÑO AMBIENTAL";
            patron.score.text = ($"{envir}/{ environmentalDamage}");
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
            FailPrefab patron = Instantiate(failPrefab, transform);
            patron.image.sprite = incidents.Sprite[1];
            patron.text.text = "IMPREVISTO";
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
            FailPrefab patron = Instantiate(failPrefab, transform);
            patron.image.sprite = incidents.Sprite[2];
            patron.text.text = "FALLA";
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
            FailPrefab patron = Instantiate(failPrefab, transform);
            patron.image.sprite = incidents.Sprite[3];
            patron.text.text = "MANTENIMIENTO";
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

    }

    [EasyButtons.Button]
    public void GetAllChildStates()
    {
        foreach (Transform child in transform)
        {
            state.Add(child.GetComponent<State>());
        }
    }

}