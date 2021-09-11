using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailPrefab : MonoBehaviour
{

    [SerializeField]
    public Text score;
    [SerializeField]
    public Image image;
    [SerializeField]
    public Text text;
    public Fail typeFail;
    public List<Details> details = new List<Details>();

}
