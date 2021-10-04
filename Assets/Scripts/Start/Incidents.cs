using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Incidents : MonoBehaviour
{

    [SerializeField]
    public List<State> images = new List<State>();
    [SerializeField]
    private List<Sprite> sprite = new List<Sprite>();
    [SerializeField]
    private PrefabsIncidents prefabIncidents;
    private int environmentalDamage;
    private int unexpected;
    private int failure;
    private int maintenance;
    private int environmentalDamage1;
    private int unexpected1;
    private int failure1;
    private int maintenance1;
    public int envir = 0;
    public int unexpe = 0;
    public int failu = 0;
    public int mainte = 0;
    private decimal mision;
    [SerializeField]
    private Text textEnvironmentalDamage;
    [SerializeField]
    private Text textUnexpected;
    [SerializeField]
    private Text textfailure;
    [SerializeField]
    private Text textMaintenance;
    [SerializeField]
    private Image filled;
    [SerializeField]
    private Timer time;
    private decimal all = 0;
    private decimal fill;
    private decimal num;
    [SerializeField]
    private VarEmotiv var;
    public List<Sprite> Sprite { get => sprite; set => sprite = value; }


    [SerializeField]
    private Final final;


    public void End() {
        foreach (State item in images)
        {
            item.stateRandom = false;
            item.gameObject.SetActive(false);
        }
    }
    public void StartGame()
    {
        all = 0;
        envir = 0;
        unexpe = 0;
        failu = 0;
        mainte = 0;
        all = 0;
        environmentalDamage = 0;
        unexpected = 0;
        failure = 0;
        maintenance = 0;
        environmentalDamage1 = 0;
        unexpected1 = 0;
        failure1 = 0;
        maintenance1 = 0;

        foreach (State item in images)
        {
            foreach (Transform child in item.transform)
            {
                DestroyImmediate(child.gameObject);
            }
            item.State1 = false;
            item.button.interactable = true;
            item.States = States.First;

        }


        mision = 15;
        fill = (1 / mision);
        decimal num = (mision / 4);
        num = Math.Floor(num);

        for (int s = 0; s < 4; s++)
        {

            int i = 0;
            do
            {
                int trans = UnityEngine.Random.Range(0, 15);
                if (images[trans].State1 == true)
                {
                    i--;
                }
                else
                {
                    PrefabsIncidents tempInstantiate = Instantiate(prefabIncidents, images[trans].transform);
                    tempInstantiate.Incidents(Sprite[s], s);
                    tempInstantiate.SetupParent();
                }
                i++;
            }
            while (i < num);
        }

        decimal numnew = mision - (num * 4);
        for (int s = 0; s < numnew; s++)
        {
            int trans = UnityEngine.Random.Range(0, 15);
            if (images[trans].State1 == true)
            {
                s--;
            }
            else
            {
                int temp = UnityEngine.Random.Range(0, 4);
                PrefabsIncidents tempInstantiate = Instantiate(prefabIncidents, images[trans].transform);
                tempInstantiate.Incidents(Sprite[temp], temp);
                tempInstantiate.SetupParent();
                switch (temp)
                {
                    case 0:
                        environmentalDamage++;
                        break;
                    case 1:
                        unexpected++;
                        break;
                    case 2:
                        failure++;
                        break;
                    case 3:
                        maintenance++;
                        break;
                    default:
                        break;
                }
            }
        }
        Dates(num);
    }


    public void Dates(decimal num)
    {
        
        this.num = num;

        filled.fillAmount = (float)(all * fill);

    }




    public void Points1(Fail fail)
    {

        switch (fail)
        {
            case Fail.DAÑO_AMBIENTAL:
                environmentalDamage1++;
                break;
            case Fail.IMPREVISTO:
                unexpected1++;
                break;
            case Fail.FALLA:
                failure1++;
                break;
            case Fail.MANTENIMIENTO:
                maintenance1++;
                break;
            default:
                break;
        }

        filled.fillAmount = (float)(all * fill);
        textEnvironmentalDamage.text = ($"{envir}/{ environmentalDamage1}");
        textUnexpected.text = ($"{unexpe}/{ unexpected1}");
        textfailure.text = ($"{failu}/{ failure1}");
        textMaintenance.text = ($"{mainte}/{ maintenance1}");
   
    }

    public void Points(Fail fail)
    {

        switch (fail)
        {
            case Fail.DAÑO_AMBIENTAL:
                envir++;
                all++;
                break;
            case Fail.IMPREVISTO:
                unexpe++;
                all++;
                break;
            case Fail.FALLA:
                failu++;
                all++;
                break;
            case Fail.MANTENIMIENTO:
                mainte++;
                all++;
                break;
            default:
                break;
        }

        filled.fillAmount = (float)(all * fill);
        textEnvironmentalDamage.text = ($"{envir}/{ environmentalDamage1}");
        textUnexpected.text = ($"{unexpe}/{ unexpected1}");
        textfailure.text = ($"{failu}/{ failure1}");
        textMaintenance.text = ($"{mainte}/{ maintenance1}");




        if (all == mision)
        {
            Invoke("EndGame", 2f);
        }

    }

    public void EndGame()
    {

        string incidents = $"{all}/{mision}";
        string bonus = "0";


        switch (time.m)
        {
            case 5:
                bonus = "500";
                break;

            case 4:
                bonus = "500";
                break;
            case 3:
                bonus = "400";
                break;
            case 2:
                bonus = "300";
                break;
            case 1:
                bonus = "100";
                break;
           
            default:
                break;
        }
        
        final.EndGame(incidents, bonus, var.stress/var.count, var.focus/var.count, var.relaxation/var.count);
        var.Stop();

        foreach (State item in images)
        {
            item.stateRandom = false;
        }
        End();

    }




}

