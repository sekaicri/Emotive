using SnowKore.Services;
using System.Collections.Generic;

public class LoginServiceData : NewServiceData
{
    private string email, password;

    public LoginServiceData(string email, string password)
    {
        this.email = email;
        this.password = password;
    }

    protected override Dictionary<string, object> Body {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("email", email);
            body.Add("password", password);
            return body;
        }
    }

    protected override string ServiceURL => "login";

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
