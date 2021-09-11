using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontPre : MonoBehaviour
{

    [SerializeField]
    private Text text;


    [SerializeField]
    private List<Button> buttons;

 
    public void Font() {


        foreach (var s in SingletonInformation.Instance.Temp)
        {
            ColorBlock cba = s.colors;
            cba.normalColor = Color.white;
            s.colors = cba;
        }

        foreach (Transform child in SingletonInformation.Instance.fail)
        {
            child.GetComponent<FailPrefab>().text.fontStyle = FontStyle.Normal; 
        }
        text.fontStyle = FontStyle.Bold;

    }


    public void Font1()
    {

        foreach (var s in SingletonInformation.Instance.Temp)
        {
            ColorBlock cba = s.colors;
            cba.normalColor = Color.white;
            s.colors = cba;
        }

        int  num = transform.parent.gameObject.GetComponent<PanelDetails>().id;
        ColorBlock cb = SingletonInformation.Instance.Temp[num].colors;
        cb.normalColor = new Color(1F, 0.05F, 0.36F, 1F);
        SingletonInformation.Instance.Temp[num].colors = cb;
        Debug.Log(num);


        foreach (Transform child in SingletonInformation.Instance.fail1)
        {
            child.GetComponent<PanelDetails>().service.fontStyle = FontStyle.Normal;
        }
        text.fontStyle = FontStyle.Bold;

    }


    public void ButtonsPre(Button button)
    {



        foreach (var s in buttons)
        {
            ColorBlock cba = s.colors;
            cba.normalColor = Color.white;
            s.colors = cba;
        }

        ColorBlock cb = button.colors;
        cb.normalColor = new Color(1F, 0.05F, 0.36F, 1F);
        button.colors = cb;

        SingletonInformation .Instance.Temp = buttons;
    }


}
