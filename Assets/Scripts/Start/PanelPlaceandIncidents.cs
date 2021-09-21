using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelPlaceandIncidents : MonoBehaviour
{
    [SerializeField]
    private TMP_Text place;
    [SerializeField]
    private TMP_Text place1;
    [SerializeField]
    private TMP_Text place2;


    public void Place(string pla) {
        place.text = pla;
        place1.text = pla;
        place2.text = pla;


    }
}
