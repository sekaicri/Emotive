using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CuadrillaManager : MonoBehaviour
{
    [SerializeField]
    private List<Cuadrilla> cuadrillas = new List<Cuadrilla>();
    private int num;
    [SerializeField]
    private Code code;
    [SerializeField]
    private Button buttonEquipo;

    public int Num { get => num; set => num = value; }
    public List<Cuadrilla> Cuadrillas { get => cuadrillas; set => cuadrillas = value; }

    public void saveCuadrilla(int num) {
        this.Num = num;
    }
    public void StartCuadrilla()
    {
        Cuadrillas[Num - 1].ButttonDisable();
    }

    public void StartEquipo()
    {
        buttonEquipo.interactable = false;  
    }


    public void StartCuadrilla1(string severity)
    {
        Cuadrillas[Num - 1].CuadrillaStart( severity);
    }

    public void CuadrillaAssigne()
    {
        Cuadrillas[Num - 1].CuadrillaAssigne();
    }

    public void SaveCuadrillaCode()
    {
        code.SaveCuadrilla(Num);
    }


    public void Eraser() {
        foreach (var s in cuadrillas) {
            s.Eraser();
        }
    }
}
