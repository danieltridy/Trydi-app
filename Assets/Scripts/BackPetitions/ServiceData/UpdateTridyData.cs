using SnowKore.Services;
using System.Collections.Generic;

public class UpdateTridyData : newServiceData
{
    private string estructura;
    private double latitude, longitude;
    private int  tridy_id;
    private string name_user = " " ;
    public UpdateTridyData(int tridy_id, string estructura)
    {
      
        this.tridy_id = tridy_id;
        this.estructura = estructura;

    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("tridy_id", tridy_id);
            body.Add("estructura", estructura);
            return body;
        }
    }

    protected override string ServiceURL => "api/updateTridy";

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
