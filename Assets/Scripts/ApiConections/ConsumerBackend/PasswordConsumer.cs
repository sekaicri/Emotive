using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Newtonsoft.Json;


public class PasswordConsumer : MonoBehaviour
{

    [SerializeField]
    private string email;
    [SerializeField]
    private InputField email1;

    public void Password()
    {
        email = email1.text;
        StartCoroutine(AsyncPetition());
    }



    private IEnumerator AsyncPetition()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null, null);
        InAppNotification.Instance.ShowNotication(notification);
        PasswordServiceData serviceData = new PasswordServiceData(email);
        yield return serviceData.SendAsync(Response);
    }

    private void Response(string response, string code)
    {
        InAppNotification.Instance.HideNotication();

        if (code.Contains("200"))
        {
            ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, "Te llegara un correo con las instruccciones", "");
            InAppNotification.Instance.ShowNotication(notification);

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
