using SnowKore.Services;
using System.Collections.Generic;

public class UpdateServiceData : NewServiceData
{
    private int usuario;
    private string mail;
    private string lastname;
    private string name;

    public UpdateServiceData(int usuario, string mail, string lastname, string name)
    {
        this.usuario = usuario;
        this.mail = mail;
        this.lastname = lastname;
        this.name = name;

    }
    //public SaveProgressServiceData(int usuario, Item item)
    //{
    //    this.usuario = usuario;
    //    this.Item = item;
    //}

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("usuario", usuario);
            body.Add("email", mail);
            body.Add("lastname", lastname);
            body.Add("name", name);

            return body;
        }
    }

    protected override string ServiceURL => ($"updateRegistro/{UserData.Instance.usuario.id}");

    protected override Dictionary<string, object> Params
    {
        get
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            return parameters;
        }
    }

    protected override Dictionary<string, string> Headers
    {
        get
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "application/json");
            return headers;
        }
    }

    protected override ServiceType ServiceType => ServiceType.POST;
}
