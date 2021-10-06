using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private int minutes;

    [SerializeField]
    private int seconds;

    public int m, s, r;

    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Incidents incidents;
    [SerializeField]
    private Alert alerta;
    [SerializeField]
    private RandomScene randomScene;

    [SerializeField]
    private Ws_Client_S ws;
    public void StartTimer()
    {
        
        m = minutes;
        s = seconds;
        WriteTimer(m, s);
        Invoke("UpdateTimer",1f);
       
    }

    private void StopTimer()
    {
        CancelInvoke();
        incidents.EndGame();
        randomScene.StopAllCoroutines();
    }

    public void Again()
    {
        CancelInvoke();

    }

    private void UpdateTimer()
    {
        r++;
        s--;
        if (s == 0) {

            if (m == 0)
            {
                StopTimer();
                CancelInvoke();

            }

            else {
                m--;
                s = 59;

                int alert = UnityEngine.Random.Range(0, 11);
                if (alert > 6)
                {
                    alerta.PlayandImage();
                }
            }
        }

        if (m == 9 && s == 58) {
            randomScene.init = true;
          randomScene.RandomStart();
        }

        if (r == 10) {
            randomScene.init = false;
            randomScene.RandomStart();
            r = 0;
        }
        WriteTimer(m, s);
        if (m == 0 && s == 0)
        {


        }
        else {
            Invoke("UpdateTimer", 1f);
        }
    }
    private void WriteTimer(int m, int s)
    {
        if (s < 10)
        {
            timerText.text = m.ToString() + ":0" + s.ToString();
        }
        else {
            timerText.text = m.ToString() + ":" + s.ToString();
        }

    }

}
