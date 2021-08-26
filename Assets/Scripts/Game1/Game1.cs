using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game1 : MonoBehaviour
{

    [SerializeField]
    private GridLayoutGroup layaout;



    [SerializeField]
    private int x, y;

    [HideInInspector]
    public int xy;

    [SerializeField]
    private GameObject point;

    public List<List<GameObject>> planeList = new List<List<GameObject>>();



    [ContextMenu("points")]
    private void CreatePlane()
    {

        xy = x * y;
        layaout.constraintCount = x;
        for (int i = 0; i < y; i++)
        {
            List<GameObject> plane = new List<GameObject>();
            for (int s = 0; s < x; s++)
            {
                GameObject patron = Instantiate(point, transform);
                plane.Add(patron);
            }
            planeList.Add(plane);
        }
    }




   
}
