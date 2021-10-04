using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    public AudioSource source;

    [SerializeField]
    private Image image;
    [SerializeField]
    private Image filled;
    void Start()
    {
        gameObject.AddComponent<AudioSource>();
    }


    public void PlaySound()
    {
        source.Play();
    }



    public void PlayandImage() {

        source.Play();
        StartCoroutine(FilledImageSound());
    }


    private IEnumerator FilledImageSound()
    {
        
        image.gameObject.SetActive(true);

        for (float i = 0; i < source.clip.length ; i += Time.deltaTime )
        {
            filled.fillAmount = i / source.clip.length;
            yield return null;
        }


        image.gameObject.SetActive(false);
        filled.fillAmount = 0;
    }

}
