using SnowKore.Services;
using System.Collections.Generic;

public class RegisterServiceData : NewServiceData
{
    private string email, password, name, lastname;
    
    public RegisterServiceData(string email, string password, string name, string lastname)
    {
        this.email = email;
        this.password = password;
        this.name = name;
        this.lastname = lastname;

    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("email", email);
            body.Add("password", password);
            body.Add("name", name);
            body.Add("lastname", lastname);
            return body;
        }
    }

    protected override string ServiceURL => "registro";

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
