using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignedPoints : MonoBehaviour
{
    private float low=0;
    private float medium=0;
    private float high=0;
    private float num;
    [SerializeField]
    private float points;
    [SerializeField]
    private Score score;

  
    public void Points() {
        foreach (var s in SingletonInformation.Instance.states) {


            switch (s.Complexity1)
            {
                case "BAJA":
                    low++;
                    break;
                case "MEDIA":
                    medium++;
                    break;
                case "ALTA":
                    high++;
                    break;
                default:
                    break;
            }

        }

        float all = low + high + medium;

        float pointsPorcent = (points * 0.50f);
        float porcent1 = pointsPorcent / all;
        float porcent2 = ((points*0.2f)/medium)+ porcent1;
        float porcent3 = ((points * 0.3f)/high) + porcent1;
        score.Save(porcent1,porcent2,porcent3);
    }


}
