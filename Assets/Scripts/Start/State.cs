using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class State : MonoBehaviour
{

    private PrefabsIncidents prefabsIncidents;
    [SerializeField]

    private Button button;
    [SerializeField]
    private bool state;

    public bool State1 { get => state; set => state = value; }

    private void Start()
    {
    }
    public void Incidents(PrefabsIncidents prefab) {
        this.gameObject.SetActive(true);
        prefabsIncidents = prefab;
        button.GetComponent<Image>().sprite = prefabsIncidents.SpriteIn;
        state = true;

    }

}
