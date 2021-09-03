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

    private int m, s;

    [SerializeField]
    private Text timerText;

    [SerializeField]
    private ElementIdentifier main;
    [SerializeField]
    private ElementIdentifier final;
    [SerializeField]
    private ElementIdentifier patron;

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
        InterfaceManager.Instance.ShowScreen(final);
        InterfaceManager.Instance.HideScreen(main);
        InterfaceManager.Instance.HideScreen(patron);

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
