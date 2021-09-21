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

    public List<Button> Buttons { get => buttons; set => buttons = value; }

    public void ButtonsPre(Button button)
    {



        foreach (var s in Buttons)
        {
            ColorBlock cba = s.colors;
            cba.normalColor = Color.white;
            s.colors = cba;
        }

        ColorBlock cb = button.colors;
        cb.normalColor = new Color(1F, 0.05F, 0.36F, 1F);
        button.colors = cb;

    }

    public void ButtonsPre1()
    {



        foreach (var s in Buttons)
        {
            ColorBlock cba = s.colors;
            cba.normalColor = Color.white;
            s.colors = cba;
        }

    }


}
