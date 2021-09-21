using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class EraserAll : MonoBehaviour
{
    [SerializeField]
    private Text one;
    [SerializeField]
    private Text two;
    [SerializeField]
    private Text three;
    [SerializeField]
    private Text four;
    [SerializeField]
    private Button button;
    [SerializeField]
    private Button button2;
    [SerializeField]
    private List<UILineRenderer> lr = new List<UILineRenderer>();
    [SerializeField]
    private Transform details;
    [SerializeField]
    private Transform fail;
    [SerializeField]
    private TMP_Text place;

    public void EraserALL() {
        one.text = "";
        two.text = "";
        three.text = "ASIGNAR";
        four.text = "";
        place.text = "";
        button.interactable = false;
        button.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);
        foreach (var s in lr) {
            s.Points = new Vector2[1];
        }


        
            foreach (Transform child in fail)
            {
                Destroy(child.gameObject);
            }


            foreach (Transform child in details)
            {
            Destroy(child.gameObject);
            }
        
    }





}
