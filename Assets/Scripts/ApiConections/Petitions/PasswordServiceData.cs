using SnowKore.Services;
using System.Collections.Generic;

public class PasswordServiceData : NewServiceData
{

    private string email;

    public PasswordServiceData(string email)
    {
        this.email = email;
  

    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("email", email);
            return body;
        }
    }

    protected override string ServiceURL => "/olvido";

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
