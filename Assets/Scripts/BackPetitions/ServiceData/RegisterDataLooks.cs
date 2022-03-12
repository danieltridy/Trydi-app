using SnowKore.Services;
using System.Collections.Generic;

public class RegisterDataLooks : newServiceData
{
    private int tridy_id;
    public RegisterDataLooks(int tridy_id)
    {
        this.tridy_id = tridy_id;
    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("tridy_id", tridy_id);

            return body;
        }
    }

    protected override string ServiceURL => "api/Looks";

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
