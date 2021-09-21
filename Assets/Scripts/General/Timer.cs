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

    public int m, s;

    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Incidents incidents;
    

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
    }

    public void Again()
    {
        CancelInvoke();
      
    }

    private void UpdateTimer()
    {
        s--;
        if (s == 0) {

            if (m == 0)
            {
                StopTimer();
            }

            else {
                m--;
                s = 59;
            }
        }
        WriteTimer(m, s);
        Invoke("UpdateTimer", 1f);
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
