using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Out : MonoBehaviour
{

    [SerializeField]
    private PanelDetails prefabDetail;
    [SerializeField]
    private Transform transformDetail;


    public void CreateDetail(List<State> state, int num)
    {

        foreach (var s in state)
        {
            if (s.details.affected > 0) {
            PanelDetails patron = Instantiate(prefabDetail, transformDetail);
            patron.affected.text = s.details.affected.ToString();
            patron.service.text = s.details.service;
            patron.severity = s.details.severity;
            patron.information = s.details.error;
            patron.id = s.details.num;
            if (s.details.num == num)
            {
                patron.service.fontStyle = FontStyle.Bold;
                patron.Title();

            }
            }
        }

    }

  

}



