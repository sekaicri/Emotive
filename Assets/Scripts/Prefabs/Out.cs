using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Out : MonoBehaviour
{

    [SerializeField]
    private PanelDetails prefabDetail;
    [SerializeField]
    private FailPrefab fail;


    public void CreateDetails()
    {

        SingletonInformation.Instance.start.interactable = false;

        foreach (Transform child in transform.parent.gameObject.GetComponent<TransformDetails>().transformDetails)
        {
            Destroy(child.gameObject);
        }

        foreach (var s in fail.details)
        {
            PanelDetails patron = Instantiate(prefabDetail, transform.parent.gameObject.GetComponent<TransformDetails>().transformDetails);
            patron.affected.text = s.affected.ToString();
            patron.service.text = s.service;
            patron.severity = s.severity;
            patron.information = s.error;
        }
    }


    public void CreateDetail(Fail fail1, int n)
    {



        for (int i = 0; i < fail.details.Count; i++)
        {

            if (fail.text.text.Replace(" ", "_") == fail1.ToString())
            {
                PanelDetails patron = Instantiate(prefabDetail, transform.parent.gameObject.GetComponent<TransformDetails>().transformDetails);
                patron.affected.text = fail.details[i].affected.ToString();
                patron.service.text = fail.details[i].service;
                patron.severity = fail.details[i].severity;
                patron.information = fail.details[i].error;

                if (fail.details.Count == 1)
                {
                    patron.service.fontStyle = FontStyle.Bold;
                    patron.Title();
                }

                else {
                    SingletonInformation.Instance.start.interactable = false;
                    fail.details[0].num = n;
                }
                Debug.Log(n);
           
            }
        }
    }


}
