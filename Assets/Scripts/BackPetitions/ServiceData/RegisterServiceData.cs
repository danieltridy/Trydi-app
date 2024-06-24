
using SnowKore.Services;
using System.Collections.Generic;

public class RegisterServiceData : newServiceData
{
    private string nick, email, password;

    public RegisterServiceData(string nick, string email, string password)
    {
        this.nick = nick;
        this.email = email;
        this.password = password;
    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("name", nick);
            body.Add("email", email);
            body.Add("password", password);
            return body;
        }
    }

    protected override string ServiceURL => "api/Register";

    protected override Dictionary<string, object> Params => new Dictionary<string, object>();

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
