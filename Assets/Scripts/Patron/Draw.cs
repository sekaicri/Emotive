using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class Draw : MonoBehaviour
{
    [SerializeField]
    private UILineRenderer lineRenderer;

    [SerializeField]
    private Image image;
    public static Draw Instance { get; private set; }
   
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
  
    public void DrawLine(Button points) {


        image.transform.localPosition = new Vector2(points.GetComponent<RectTransform>().localPosition.x, points.GetComponent<RectTransform>().localPosition.y);
        var point = new Vector2(points.GetComponent<RectTransform>().localPosition.x,points.GetComponent<RectTransform>().localPosition.y);
        var pointlist = new List<Vector2>(lineRenderer.Points);
        pointlist.Add(point);

        if (Num.Instance.temp == 0)
        {
            lineRenderer.Points[0] = point;
        }
        else {
            lineRenderer.Points = pointlist.ToArray();
        }

    }

    public void Happy(Button points)
    {
        string Cristian= "";
        if (Cristian == "solo")
        {
            Cristian = "Triste";
        }

        else {
            Cristian = "Feliz";
        }
    }

}
