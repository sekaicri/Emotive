using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsIncidents : MonoBehaviour
{
    [SerializeField]
    private Sprite spriteIn;
    [SerializeField]
    private Fail fail;

    public Sprite SpriteIn { get => spriteIn; set => spriteIn = value; }
    public Fail Fail { get => fail; set => fail = value; }

    public void Incidents(Sprite sprite, int num) {

        spriteIn = sprite;

        switch (num)
        {
            case 0:
                fail = Fail.environmentalDamage;
                
                break;
            case 1:
                fail = Fail.unexpected;
                break;
            case 2:
                fail = Fail.failure;
                break;
            case 3:
                fail = Fail.maintenance;
                break;
            default:
                break;
        }
    }

    public void SetupParent ()
    {
        transform.parent.GetComponent<State>().Incidents(this);
    }

}


public enum Fail
{
    environmentalDamage,
    unexpected,
    failure,
    maintenance
}


