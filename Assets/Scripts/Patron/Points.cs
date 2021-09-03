using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
   
    [SerializeField]
    private Button point;
    public int xy;
    [SerializeField]
    public PrefabsPoint num;

    public List<List<GameObject>> listNueva = new List<List<GameObject>>();


    public void Patron( )
    {
        if (Num.Instance.temp < xy) {

            num.num.text = Num.Instance.temp.ToString();
            point.interactable = false;
            Draw.Instance.DrawLine(point);
        }
        Num.Instance.Enum(xy);

    }

}
