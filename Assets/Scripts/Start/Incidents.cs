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
   

    [ContextMenu("holi")]
    public void StartGame()
    {
        mision = UnityEngine.Random.Range(10, 16);
        decimal  num = (mision / 4);
        num = Math.Floor(num);

        for (int s = 0; s < 4; s++) { 

            int i = 0;

            do
            {
                int trans = UnityEngine.Random.Range(0, 15);
                PrefabsIncidents tempInstantiate = Instantiate(prefabIncidents, images[trans].transform);
                if (images[trans].State1 == true)
                {
                    i--;
                }
                else
                {
                    tempInstantiate.Incidents(sprite[s]);
                    tempInstantiate.SetupParent();
                }
                i++; 
            }
            while (i < num);
        }


        decimal numnew = mision - (num*4);
        for (int s = 0; s < numnew; s++) {
            int trans = UnityEngine.Random.Range(0, 15);
            PrefabsIncidents tempInstantiate = Instantiate(prefabIncidents, images[trans].transform);
              if (images[trans].State1 == true)
                {
                    s--;
                }
                else
                {
                    tempInstantiate.Incidents(sprite[UnityEngine.Random.Range(0, 4)]);
                    tempInstantiate.SetupParent();
                }
        }




    }


}

