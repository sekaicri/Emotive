using Newtonsoft.Json;
using System.Collections;
using System.Globalization;
using UnityEngine;

public class SaveProgressConsumer : MonoBehaviour
{

    [SerializeField]
    private  Item response;

    [SerializeField]
    private LoginConsumer login;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

    }

  

    public void SaveProgressPetition()
    {
        StartCoroutine(AsyncPetition());
    }

    private IEnumerator AsyncPetition()

    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null, null);
        SaveProgressServiceData serviceData = new SaveProgressServiceData(UserData.Instance.usuario.id,UserData.Instance.item.estado,UserData.Instance.item.puntos,UserData.Instance.item.incidencias,UserData.Instance.item.estres,UserData.Instance.item.enfoque, UserData.Instance.item.relajacion, UserData.Instance.item.bonus);
        yield return serviceData.SendAsync(Response);
    }

    private void Response(string response, string code)
    {
        InAppNotification.Instance.HideNotication();
        Debug.Log($"code: {code} \n response:{response}");
        if (code.Contains("200"))
        {
            this.response = JsonConvert.DeserializeObject<Item>(response);
            UserData.Instance.item.id = this.response.id;
            UserData.Instance.item.estado = this.response.estado;
            UserData.Instance.item.incidencias = this.response.incidencias;
            UserData.Instance.item.estres = this.response.estres;
            UserData.Instance.item.enfoque = this.response.enfoque;
            UserData.Instance.item.relajacion = this.response.relajacion;
            UserData.Instance.item.bonus = this.response.bonus;

            login.LoginPetitionUpdate(PlayerPrefs.GetString("mail"), PlayerPrefs.GetString("Password"));

        }
        else
        {
            Debug.Log("hombre la cago guardar");
        }
    }
}
