using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignOff : MonoBehaviour
{

    [SerializeField]
    private UnityEvent succeededLogin;

    public void SignOffStart() {
        PlayerPrefs.DeleteAll();
        succeededLogin.Invoke();
        UserData.Instance.items.Clear();   
            
            }
}
