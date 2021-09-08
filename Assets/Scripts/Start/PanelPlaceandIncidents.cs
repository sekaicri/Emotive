using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelPlaceandIncidents : MonoBehaviour
{
    [SerializeField]
    private TMP_Text place;


    public void Place(string pla) {

        place.text = pla;
    }
}
