using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Disable : MonoBehaviour
{
    [SerializeField]
    private List<State> states = new List<State>();


    private void StateButton() {


        foreach (var s in states) {
            s.stateButton = false;
        }

        
    }



}

