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




    public void CreateDetails() {
        SingletonInformation.Instance.start.interactable = false;

        foreach (Transform child in transform.parent.gameObject.GetComponent<TransformDetails>().transformDetails)
        {
            Destroy(child.gameObject);
        }

        foreach (var s in fail.details) { 
        PanelDetails patron = Instantiate(prefabDetail, transform.parent.gameObject.GetComponent<TransformDetails>().transformDetails);
        patron.affected.text = s.affected.ToString();
        patron.service.text = s.service;
        patron.severity = s.severity;
        patron.information = s.error;
        }
    }

 
}
