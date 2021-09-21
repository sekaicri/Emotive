using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MonoBehaviour
{
    public AudioSource source;


    void Start()
    {
        gameObject.AddComponent<AudioSource>();
    }


    public void PlaySound()
    {
        source.Play();
    }

}
