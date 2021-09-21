using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Details
{
    public int affected;
    public int num;
    public string error;
    public string service;
    public string severity;
    
    public void CreateDetails(string errors , string services)
    {
        affected = Random.Range(1000, 4000);

        error = errors;
        service = services;
        if (affected < 2000) {
            severity = "BAJA";
        }
        else if (affected < 2800) {
            severity = "MEDIA";
        }
        else  {
            severity = "ALTA";
        }
    }


}