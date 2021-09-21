using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    [SerializeField]
    private Text name;

    [SerializeField]
    private Text points;
    [SerializeField]
    private Text incidentes;
    [SerializeField]
    private Image stres;
    [SerializeField]
    private Image focus;
    [SerializeField]
    private Image relajate;
    [SerializeField]
    private Text tstres;
    [SerializeField]
    private Text tfocus;
    [SerializeField]
    private Text trelajate;
    [SerializeField]
    private Text  bonus;
    [SerializeField]
    private Text pointsinScene;
    [SerializeField]
    private ElementIdentifier main;
    [SerializeField]
    private ElementIdentifier final;
    [SerializeField]
    private List<Sprite> Smile = new List<Sprite>();
    [SerializeField]
    private SaveProgressConsumer saveProgressConsumer;
    public void EndGame(string incidentes, string bonus, float stress, float focus, float relajate) {
        name.text = $"¡HA TERMINADO LA JORNADA! {UserData.Instance.usuario.name.ToUpper()}";
        points.text = pointsinScene.text;
        this.incidentes.text = incidentes;
        this.bonus.text = bonus;
        InterfaceManager.Instance.ShowScreen(final);
        InterfaceManager.Instance.HideScreen(main);
        stres.fillAmount = stress;
        this.focus.fillAmount = focus;
        this.relajate.fillAmount = relajate;
        tstres.text = stress.ToString("0.#");
        tfocus.text = focus.ToString("0.#");
        trelajate.text = relajate.ToString("0.#");
        if (stress > 0.5)
        {
            UserData.Instance.item.estado = 1;
        }
        else {
            UserData.Instance.item.estado = 1;

        }
        UserData.Instance.item.puntos = int.Parse(points.text);
        UserData.Instance.item.incidencias = this.incidentes.text;
        UserData.Instance.item.estres = stress;
        UserData.Instance.item.enfoque = focus;
        UserData.Instance.item.relajacion = relajate;
        UserData.Instance.item.bonus = int.Parse(bonus);
        saveProgressConsumer.SaveProgressPetition();
    }

}



