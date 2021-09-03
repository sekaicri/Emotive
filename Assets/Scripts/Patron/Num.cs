using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Num : MonoBehaviour
{

    public static Num Instance { get; private set; }
    public int temp = 0;

    public UnityEvent unityEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Enum(int xy)
    {
        temp++;
        if (temp == xy) {

            unityEvent.Invoke();
        }
   
    }
}
