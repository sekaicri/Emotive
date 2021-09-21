using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private Text score;
    private float points=0;
    private int save = 0;
    [SerializeField]
    private AssignedPoints assignedPoints;
    private float low;
    private float medium;
    private float high;
    [SerializeField]
    private Text scorePoints;
    [SerializeField]
    private ElementIdentifier Points;
    public void StartPoints()
    {
        points = 0;
        score.text = points.ToString();
        save = 0;
        assignedPoints.Points();
        scorePoints.text = "0";
    }


    public void Save(float num1, float num2, float num3) {
        low = num1;
        medium = num2;
        high = num3;   
    }
    public void ScorePoints(string complexity)
    {


        switch (complexity)
        {
            case "BAJA":
                points = points + low;
                low = (int)low;
                scorePoints.text = $"+ {low}";
                break;
            case "MEDIA":
                points = points + medium;
                medium = (int)medium;
                scorePoints.text = $"+ {medium}";
                break;
            case "ALTA":
                points = points + high;
                high = (int)high;
                scorePoints.text = $"+ {high}";
                break;
            default:
                break;
        }


        InterfaceManager.Instance.ShowScreen(Points);
        Invoke("Scorepoint", 2f);




    }

    private void Scorepoint() {
        InterfaceManager.Instance.HideScreen(Points);

        points = (int)(points);
        score.text = points.ToString();

    }



}
