using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsIncidents : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteIn;


    public Sprite SpriteIn { get => spriteIn; set => spriteIn = value; }

    public void Incidents(Sprite sprite) {

        spriteIn = sprite;
        
    }

    public void SetupParent ()
    {
        transform.parent.GetComponent<State>().Incidents(this);
    }

}
