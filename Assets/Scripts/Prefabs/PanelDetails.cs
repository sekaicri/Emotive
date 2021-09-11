using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelDetails : MonoBehaviour
{
    public Text service ;
    public Text affected;
    public string severity;
    public string information;
    public int id;


    public void Title() {
        SingletonInformation.Instance.Text(severity, information);
    }

}
