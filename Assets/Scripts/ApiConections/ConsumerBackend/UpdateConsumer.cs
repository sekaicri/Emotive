using Newtonsoft.Json;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpdateConsumer : MonoBehaviour
{

    private int usuario;
    private string mail;
    private string lastname;
    private string name;
    [SerializeField]
    private LoginResponse response;
    [SerializeField]
    private InputField mail1;
    [SerializeField]
    private InputField lastname1;
    [SerializeField]
    private InputField name1;
    [SerializeField]
    private UnityEvent succeededLogin;
    [SerializeField]
    private LoginConsumer login;


    public void UpdatePetition()
    {
        mail = mail1.text;
        lastname = lastname1.text;
        name = name1.text;
        usuario = UserData.Instance.usuario.id;

        StartCoroutine(AsyncPetition());
    }
    public void AutoLogin()
    {

        StartCoroutine(AsyncPetition());

    }


    private IEnumerator AsyncPetition()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null, null);
        InAppNotification.Instance.ShowNotication(notification);
        UpdateServiceData serviceData = new UpdateServiceData( usuario,  mail,  lastname,  name);
        yield return serviceData.SendAsync(Response);
    }

    private void Response(string response, string code)
    {
        InAppNotification.Instance.HideNotication();

        if (code.Contains("200"))
        {
            succeededLogin.Invoke();
            login.LoginPetitionUpdate(mail, PlayerPrefs.GetString("Password"));
            mail1.text = "";
            name1.text = "";
            lastname1.text = "";


        }
        else
        {
            ErrorLoginResponse error = new ErrorLoginResponse();
            error = JsonConvert.DeserializeObject<ErrorLoginResponse>(response);
            ClassnNotification notification = new ClassnNotification(EnumNotification.Buttonx, error.code, "Error");
            InAppNotification.Instance.ShowNotication(notification);

        }
    }
}
