
using SnowKore.Services;
using System.Collections.Generic;

public class MeTridyServiceData : newServiceData
{
    private int id_user;

    public MeTridyServiceData(int id_user)
    {
        this.id_user = id_user;
    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("id_user", id_user);
            return body;
        }
    }

    protected override string ServiceURL => "api/MeCreations";

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
