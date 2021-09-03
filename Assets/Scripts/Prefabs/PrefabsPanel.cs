using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabsPanel : MonoBehaviour
{
    [SerializeField]
    private Text fecha;
    [SerializeField]
    private Image happy ;
    [SerializeField]
    private Image sad;
    [SerializeField]
    private Text puntos;
    [SerializeField]
    private Text incidencias;
    [SerializeField]
    private Text estres;
    [SerializeField]
    private Text enfoque;
    [SerializeField]
    private Text relajacion;
    [SerializeField]
    private Text bonus;
    [SerializeField]
    private Image stres;
    [SerializeField]
    private Image rela;
    [SerializeField]
    private Image enfo;



    public void Setup(Item info)
    {
        fecha.text = ($"{info.fecha}");
        puntos.text = ($"{info.puntos}");
        incidencias.text = ($"{info.incidencias}");
        estres.text = ($"{info.estres}");
        stres.fillAmount = info.estres;
        enfoque.text = ($"{info.enfoque}");
        enfo.fillAmount = info.enfoque;
        relajacion.text = ($"{info.relajacion}");
        rela.fillAmount = info.relajacion;
        bonus.text = ($"{info.bonus}");

        if (info.estado == 0)
        {
            sad.gameObject.SetActive(true);
            happy.gameObject.SetActive(false);
        }
        else { 
            happy.gameObject.SetActive(true);
            sad.gameObject.SetActive(false);
        }

    }
}
