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
    private PrefabsPoint  point;


    [SerializeField]
    private Points points;

    public List<List<PrefabsPoint>> planeList = new List<List<PrefabsPoint>>();


    public void CreatePlane()
    {
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
            if (numSave[i] == patronView.save[i]) {
                temp++;
            }
        }
     
        if (temp==patronView.xy)
        {
            Debug.Log("correcto papi");



        }
        else 
        {
            Debug.Log("incorrecto papi");
            CreatePlane();
            Num.Instance.temp = 0;
        }
    }

}
