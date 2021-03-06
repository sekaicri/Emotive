using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class PatronView : MonoBehaviour
{

    [SerializeField]
    private GridLayoutGroup layaout;

    [SerializeField]
    private GameObject point;

    [SerializeField]
    private PrefabsPoint prefabPoint;
    [HideInInspector]
    public int x = 0, y = 0;
    [SerializeField]
    public Patron patron;

    [SerializeField]
    public Transform transformPatron;

    public int xy;
    public int a , b;

    public List<List<GameObject>> planeList = new List<List<GameObject>>();

    public List<int> save = new List<int>();

    private List<PrefabsPoint> list = new List<PrefabsPoint>();

    [SerializeField]
    private UILineRenderer lineRenderer;

    public List<PrefabsPoint> listNew = new List<PrefabsPoint>();

    private bool again = false;
    public int randomXY;
    public bool Again { get => again; set => again = value; }

    [ContextMenu("holi")]
    public void StartPatron(string severity)
    {
        StopAllCoroutines();
        Num.Instance.temp = 0;
        x = Random.Range(3, a);
        y = Random.Range(3, b);

//#if UNITY_EDITOR
//        x = 2;
//        y = 2;
//#endif
        xy = x * y;
        randomXY = Random.Range(xy/2 ,xy+1);
        layaout.constraintCount = x;
        Rando8(severity);
        lineRenderer.Points = new Vector2[1];

    }
    private void CreatePlane(string severity)
    {
        foreach (List<GameObject> item in planeList)
        {
            foreach (GameObject item1 in item)
            {
                DestroyImmediate(item1);
            }
        }


        foreach (Transform child in transformPatron)
        {
            Destroy(child.gameObject);
        }


        planeList = new List<List<GameObject>>();
        list= new List<PrefabsPoint>();
        planeList.Clear();
        list.Clear();

        for (int i = 0; i < xy; i++)
        {
            List<GameObject> plane = new List<GameObject>();
            PrefabsPoint draw = Instantiate(prefabPoint, transform);
            draw.num.text = save[i].ToString();
            list.Add(draw);
            planeList.Add(plane);
        }
        patron.CreatePlane(severity);
        StartCoroutine(Draw());

    }
    private IEnumerator Draw()
    {

        foreach (var s in listNew)
        {
                s.point.interactable = true;
        }

        again = false;
        lineRenderer.Points = new Vector2[1];

        listNew = new List<PrefabsPoint>();
        listNew.Clear();

        foreach (var s in listNew)
        {
            DestroyImmediate(s);
        }

        yield return new WaitForSeconds(1);

        float t = 0;
        Vector2 newpos;
        int i = 0;
        Vector2 point1 = new Vector2();
        float time = 1f;
        Vector2 orig = new Vector2();
        Vector2 orig2 = new Vector2();

        int y = 0;
        do
        {
            if (int.Parse(list[i].num.text) == y)
            {
                listNew.Add(list[i]);
                i = 0;
            }
            else
            {
                if (y == 0)
                {
                    y = -1;
                }
                else
                {
                    y--;
                }
                i++;

            }

            y++;

        }
        while (y < randomXY);

        point1 = new Vector2(listNew[0].point.GetComponent<RectTransform>().localPosition.x, listNew[0].point.GetComponent<RectTransform>().localPosition.y);
        lineRenderer.Points[0] = point1;

        for (int x = 0; x < (randomXY - 1); x++)
        {
            orig = new Vector2(listNew[x].point.GetComponent<RectTransform>().localPosition.x, listNew[x].point.GetComponent<RectTransform>().localPosition.y);
            orig2 = new Vector2(listNew[x + 1].point.GetComponent<RectTransform>().localPosition.x, listNew[x + 1].point.GetComponent<RectTransform>().localPosition.y);
            t = 0;
            time = 1f;
            for (; t < time; t += Time.deltaTime)
            {
                newpos = Vector2.Lerp(orig, orig2, t / time);
                var point = newpos;
                var pointlist = new List<Vector2>(lineRenderer.Points);
                pointlist.Add(point);
                lineRenderer.Points = pointlist.ToArray();
                yield return null;


                foreach (var s in listNew)
                {
                    if (int.Parse(s.num.text) == x)
                    {
                        s.point.interactable = false;
                    }
                }
           
            }
            if (x + 2 == randomXY)
            {
                listNew[randomXY - 1].point.interactable = false;
                yield return new WaitForSeconds(0.2f);
            }
        }




        if (Again == false)
        {
            StartCoroutine(Draw());
        }
       

    }

    // [EasyButtons.Button()]

    private void Rando8(string severity)
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
        CreatePlane(severity);
    }


}
