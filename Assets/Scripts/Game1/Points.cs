using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    [SerializeField]
    private Text num;

   

    private int temp =0 ;

    public List<List<GameObject>> ListNueva = new List<List<GameObject>>();



    public void Patron()
    {
        if (temp <= temp) {

            num.text = temp.ToString();
        }
        temp++;
    }

}
