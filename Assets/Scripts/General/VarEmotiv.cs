using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VarEmotiv : MonoBehaviour
{

    public float stress = 0;
    public float focus = 0;
    public float relaxation = 0;
    private float stressRan;
    private float focusRan;
    private float relaxationRan;
    private float stressRantemp = 0;
    private float focusRantemp = 0;
    private float relaxationtemp = 0;
    [SerializeField]
    private Text tstre;
    [SerializeField]
    private Text tfoc;
    [SerializeField]
    private Text trel;
    [SerializeField]
    private Image stre;
    [SerializeField]
    private Image foc;
    [SerializeField]
    private Image rel;
    public float count;

    [SerializeField]
    private Image Var;
    public void StartVar()
    {
        StartCoroutine(TimerTime());
        stre.fillAmount = 0;
        foc.fillAmount = 0;
        rel.fillAmount = 0;
        stress = 0;
        focus = 0;
        relaxation = 0;
        count = 0;
    }

    public IEnumerator TimerTime()
    {
        int segundos = 0;


        stressRan = Random.Range(0, 7);
        focusRan = Random.Range(0, 7);
        relaxationRan = Random.Range(0, 7);
        stressRan = stressRan / 10;
        focusRan = focusRan / 10;
        relaxationRan = relaxationRan / 10;


        for (float i = 0; i < 5; i += Time.deltaTime)
        {
  
            var tempStress = Mathf.Lerp(stressRantemp, stressRan, i / 5);
            var tempFocus = Mathf.Lerp(focusRantemp, focusRan, i / 5);
            var temprela = Mathf.Lerp(relaxationtemp, relaxationRan, i / 5);

            stre.fillAmount =tempStress;
            foc.fillAmount = tempFocus;
            rel.fillAmount = temprela;
            if (tempStress>0.5) {
                StartCoroutine(ColorPinture());
            }

            tstre.text = tempStress.ToString("0.#");
            tfoc.text = tempFocus.ToString("0.#");
            trel.text = temprela.ToString("0.#");
            yield return null;
        }


        while (segundos <= 3)
        {
            stressRantemp = stressRan;
            focusRantemp = focusRan;
            relaxationtemp = relaxationRan;

            segundos++;
            yield return new WaitForSeconds(1);
        }

        Average(stressRan, focusRan, relaxationRan);
        StartCoroutine(TimerTime());
    }


    private IEnumerator ColorPinture()
    {

        if (stressRan > 0.5)
        {
            for (float i = 0; i < 100; i += Time.deltaTime)
            {
                float newStres = (stressRan - 0.5f) * 2;
                var tempColor = Var.color;
                tempColor.a = newStres;
                var tempColor1 = Color.Lerp(Var.color, tempColor, i / 100);
                Var.color = tempColor1;

                yield return null;
            }
        }
        else
        {
            for (float i = 0; i < 100; i += Time.deltaTime)
            {
                float newStres = (stressRan - 0.5f) * 2;
                var tempColor = Var.color;
                tempColor.a = newStres;
                var tempColor1 = Color.Lerp(Var.color, tempColor, i / 100);
                Var.color = tempColor1;

                yield return null;
            }
        }



    }




    private void Average(float stressRan, float focusRan, float relaxationRan)
    {
        count++;
        stress = (stress + stressRan);
        focus = (focus + focusRan);
        relaxation = (relaxation + relaxationRan);
    }

}


