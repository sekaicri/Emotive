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

    [SerializeField]
    private List<PanelDetails> tempInstantiates;
    private Fail typeFail;
    private int currentSeelcted;
    private bool currentalreadySelected=false;

    public Fail TypeFail { get => typeFail; set => typeFail = value; }
    public FailPrefab Fail { get => fail; set => fail = value; }

    public void CreateDetails()
    {

        SingletonInformation.Instance.start.interactable = false;
        SingletonInformation.Instance.severity.text = "";
        SingletonInformation.Instance.information.text = "";


        foreach (Transform child in transform.parent.gameObject.GetComponent<TransformDetails>().transformDetails)
        {
            Destroy(child.gameObject);
        }

        foreach (var s in Fail.details)
        {
            PanelDetails patron = Instantiate(prefabDetail, transform.parent.gameObject.GetComponent<TransformDetails>().transformDetails);
            patron.affected.text = s.affected.ToString();
            patron.service.text = s.service;
            patron.severity = s.severity;
            patron.information = s.error;
        }
    }


    public void CreateDetail(Fail fail1, int num)
    {

        int n = 1;
        tempInstantiates.Clear();
        currentSeelcted = num;
        for (int i = 0; i < Fail.details.Count; i++)
        {

            if (Fail.text.text.Replace(" ", "_") == fail1.ToString())
            {
                PanelDetails patron = Instantiate(prefabDetail, transform.parent.gameObject.GetComponent<TransformDetails>().transformDetails);
                tempInstantiates.Add(patron);
                typeFail = fail1;
                patron.affected.text = Fail.details[i].affected.ToString();
                patron.service.text = Fail.details[i].service;
                patron.severity = Fail.details[i].severity;
                patron.information = Fail.details[i].error;
                patron.id = Fail.details[i].num;

            }

        }

        n = 1;
        SelectCurrent();
    }

    private void SelectCurrent ()
    {
        foreach (var item in tempInstantiates)
        {
            if (item.id == currentSeelcted)
            {
                item.service.fontStyle = FontStyle.Bold;
                item.Title();
            }
        }
    }

}



