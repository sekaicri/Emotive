using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SingletonInformation : MonoBehaviour
{

    public static SingletonInformation Instance { get; private set; }
    [SerializeField]
    public Text severity;
    [SerializeField]
    private Text information;
    [SerializeField]
    public Button start;
    [SerializeField]
    public Transform fail,fail1;




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


    public void Text(string xy, string x)
    {
        severity.text = xy;
        information.text = x;
        start.interactable = true;
    }

}
