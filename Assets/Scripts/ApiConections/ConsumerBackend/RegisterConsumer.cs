using Newtonsoft.Json;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RegisterConsumer : MonoBehaviour
{

   
    [SerializeField]
    private string email, password, name ,lastname;
    [SerializeField]
    private LoginResponse response;
    [SerializeField]
    private TMP_InputField email1, password1,name1, lastname1 ;
    [SerializeField]
    private UnityEvent succeededRegister;
    [SerializeField]
    private Toggle toggle1, toggle2;
    [SerializeField]
    private TMP_Text name2;


    [ContextMenu("probar registro")]
    public void RegisterPetition()
    {
            name = name1.text;
            lastname = lastname1.text;
            email = email1.text;
            password = password1.text;

        if (password1.text == "")
        {
            ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, "Campo de Contraseña vacío", "Contraseña");
            InAppNotification.Instance.ShowNotication(notification);
        }

        else if (!toggle1.isOn || !toggle2.isOn) {

            ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, "Aceptar Terminos","Terminos" );
            InAppNotification.Instance.ShowNotication(notification);
        }
        else
        {
            StartCoroutine(AsyncPetition());
        }
    }

    private IEnumerator AsyncPetition()

    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null, null);
        InAppNotification.Instance.ShowNotication(notification);
        RegisterServiceData serviceData = new RegisterServiceData(email, password,name, lastname);
        yield return serviceData.SendAsync(Response);
    }

    private void Response(string response, string code)
    {
        InAppNotification.Instance.HideNotication();
        if (code.Contains("200")) {
            this.response = JsonConvert.DeserializeObject<LoginResponse>(response);
            succeededRegister.Invoke();
            UserData.Instance.usuario = this.response.usuario;
            name2.text = $" ¡BIENVENIDO! {UserData.Instance.usuario.name}";

            email1.text = "";
            name1.text = "";
            lastname1.text = "";
            password1.text = "";

        }
        else
        {
            ErrorRegisterResponse error = new ErrorRegisterResponse();
            error = JsonConvert.DeserializeObject<ErrorRegisterResponse>(response);
            ClassnNotification notification = new ClassnNotification(EnumNotification.Buttonx, error.code, "Error");
            InAppNotification.Instance.ShowNotication(notification);

        }
    }
}
