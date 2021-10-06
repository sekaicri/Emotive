using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScene : MonoBehaviour
{

    [SerializeField]
    private Incidents Incidents;
    [SerializeField]
    private List<GameObject> list = new List<GameObject>();
    [SerializeField]
    private Alert alert;
    private int ran;
    private int i = 0;
    public bool init;

    public void RandomStart() {
        i = 0;
        ran = Random.Range(0, 4);
        StartCoroutine(Generate());
    }

    public IEnumerator Generate()
    {
        int num = Random.Range(0, 15);

     
        if (Incidents.images[num].stateRandom == false)
        {
            num++;
            alert.PlaySound();
            list[num].SetActive(true);
            Incidents.images[num].stateRandom = true;
            if (init) {
                Incidents.images[num].button.onClick.Invoke();
            }

            Incidents.Points1(Incidents.images[num].Fail);
        }

        while (i < ran)
        {
            i++;
            StartCoroutine(Generate());
     
     }
        yield return null;

    }


    
    public void StopAll() {
        StopAllCoroutines();
    }


}
