using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PatronView : MonoBehaviour
{

    [SerializeField]
    private GridLayoutGroup layaout;

    [SerializeField]
    private GameObject point;

    [SerializeField]
    private PrefabsPoint prefabPoint;

    [SerializeField]
    public int x, y;


    [SerializeField]
    public Patron patron;


    public int xy;


    public List<List<GameObject>> planeList = new List<List<GameObject>>();

    List<int> guardados = new List<int>();


    private void Start()
    {
        xy = x * y;

        layaout.constraintCount = x;

    }
    private void CreatePlane()
    {
        foreach (List<GameObject> item in planeList)
        {
            foreach (GameObject item1 in item)
            {
                DestroyImmediate(item1);
            }
        }

        planeList = new List<List<GameObject>>();

        planeList.Clear();


        for (int i = 0; i < xy; i++)
        {
            prefabPoint.num.text = guardados[i].ToString();
            List<GameObject> plane = new List<GameObject>();
            GameObject patron1 = Instantiate(point, transform);
            plane.Add(patron1);
            planeList.Add(plane);
        }
    }

   // [EasyButtons.Button()]

[ContextMenu("Holi")]
    private void Rando8()
    {

        List<int> numerosGuardados = new List<int>();
        int posicionAleatoria;
        for (int i = 0; i < xy; i++)
        {
            do
            {
                posicionAleatoria = Random.Range(0, xy);
            } while (numerosGuardados.Contains(posicionAleatoria));
            numerosGuardados.Add(posicionAleatoria);
        }


       
        guardados = numerosGuardados;

        CreatePlane();
        patron.CreatePlane();
    }


}
