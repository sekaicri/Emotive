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
    [SerializeField]
    public GameObject ButtonState;

    private void Start()
    {
        ButtonState = transform.parent.gameObject;
    }

    public void Incidents(Sprite sprite, int num) {


        spriteIn = sprite;

        switch (num)
        {
            case 0:
                fail = Fail.DAÑO_AMBIENTAL;
                
                break;
            case 1:
                fail = Fail.IMPREVISTO;
                break;
            case 2:
                fail = Fail.FALLA;
                break;
            case 3:
                fail = Fail.MANTENIMIENTO;
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
    DAÑO_AMBIENTAL,
    IMPREVISTO,
    FALLA,
    MANTENIMIENTO
}


