using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Incidents : MonoBehaviour
{

    [SerializeField]
    private List<State> images = new List<State>();
    [SerializeField]
    private List<Sprite> sprite = new List<Sprite>();
    [SerializeField]
    private PrefabsIncidents prefabIncidents;
    private int environmentalDamage;
    private int unexpected;
    private int failure;
    private int maintenance;
    private int envir=0;
    private int unexpe=0;
    private int failu=0;
    private int mainte=0;
    private int mision; 
    [SerializeField]
    private Text textEnvironmentalDamage;
    [SerializeField]
    private Text textUnexpected;
    [SerializeField]
    private Text textfailure;
    [SerializeField]
    private Text textMaintenance;

    public List<Sprite> Sprite { get => sprite; set => sprite = value; }

    public void StartGame()
    {
        mision = UnityEngine.Random.Range(10, 16);
        decimal num = (mision / 4);
        num = Math.Floor(num);

        for (int s = 0; s < 4; s++) { 

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

        decimal numnew = mision - (num*4);
        for (int s = 0; s < numnew; s++) {
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

        textEnvironmentalDamage.text = ($"{envir}/{num+ environmentalDamage}");
        textUnexpected.text = ($"{unexpe}/{num+ unexpected}");
        textfailure.text = ($"{failu}/{num+ failure}");
        textMaintenance.text = ($"{mainte}/{num+ maintenance}");
        Debug.Log(mision);
    }


}

