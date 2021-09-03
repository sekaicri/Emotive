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
    [HideInInspector]
    public int x=0, y=0;


    [SerializeField]
    public Patron patron;


    public int xy;

    public List<List<GameObject>> planeList = new List<List<GameObject>>();

    public List<int> save = new List<int>();



    [ContextMenu("Holi")]

    public void StartPatron()
    {
        Num.Instance.temp = 0;
        x = Random.Range(3, 4);
        y = Random.Range(3, 4);
        xy = x * y;
        layaout.constraintCount = x;
        Rando8();
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
            prefabPoint.num.text = save[i].ToString();
            List<GameObject> plane = new List<GameObject>();
            GameObject patron1 = Instantiate(point, transform);
            plane.Add(patron1);
            planeList.Add(plane);
        }

    }

    // [EasyButtons.Button()]

    private void Rando8()
    {

        List<int> numSave = new List<int>();
        int posicionAleatoria;
        for (int i = 0; i < xy; i++)
        {
            do
            {
                posicionAleatoria = Random.Range(0, xy);
            } while (numSave.Contains(posicionAleatoria));
            numSave.Add(posicionAleatoria);
        }

        save = numSave;
        patron.CreatePlane();
        CreatePlane();
    }


}
