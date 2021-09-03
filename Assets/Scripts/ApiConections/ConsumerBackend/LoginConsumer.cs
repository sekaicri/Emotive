using Newtonsoft.Json;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoginConsumer : MonoBehaviour
{
    
    private string email, password;
    [SerializeField]
    private LoginResponse response;
    [SerializeField]
    private InputField email1;
    [SerializeField]
    private InputField password1;
    [SerializeField]
    private UnityEvent succeededLogin;
    [SerializeField]
    private Text name;

    public string Email { get => email; set => email = value; }
    public string Password { get => password; set => password = value; }

    [ContextMenu("probar login")]
    public void LoginPetition()
    {
        email = email1.text;
        password = password1.text;

        StartCoroutine(AsyncPetition());
    }
    public void AutoLogin()
    {

        StartCoroutine(AsyncPetition());

    }


    private IEnumerator AsyncPetition ()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load , null , null );
        InAppNotification.Instance.ShowNotication(notification);
        LoginServiceData serviceData = new LoginServiceData(email, password);
        yield return serviceData.SendAsync(Response);
    }

    private void Response (string response, string code)
    {
        InAppNotification.Instance.HideNotication();

        if (code.Contains("200"))
        {
          
            this.response = JsonConvert.DeserializeObject<LoginResponse>(response);
            succeededLogin.Invoke();
            UserData.Instance.usuario = this.response.usuario;
            UserData.Instance.items = this.response.items;
            name.text = $" ¡Bienvenido! {UserData.Instance.usuario.name}";
         
         

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
