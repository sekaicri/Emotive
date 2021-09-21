using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasNotiEmotiv 
{

    public EnumNotiEmotiv state;
    public string textInformation;
    public string textInformation1;



    public ClasNotiEmotiv(EnumNotiEmotiv state, string textInformation, string textInformation1)
    {
        this.state = state;
        this.textInformation = textInformation;
        this.textInformation1 = textInformation1;

    }
}
