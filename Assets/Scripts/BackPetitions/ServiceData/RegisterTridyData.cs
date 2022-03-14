using SnowKore.Services;
using System.Collections.Generic;

public class RegisterTridyData : newServiceData
{
    private string name, description;
    private double latitude, longitude;
    private int user_id, likes;
    private string name_user = " " ;
    public RegisterTridyData(string name, double latitude, double longitude,int user_id, int likes, string description)
    {
        this.name = name;
        this.latitude = latitude;
        this.longitude = longitude;
        this.user_id = user_id;
        this.likes = likes;
        this.description = description;


    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("name", name);
            body.Add("latitude", latitude);
            body.Add("longitude", longitude);
            body.Add("user_id", user_id);
            body.Add("likes", likes);
            body.Add("description", description);

            return body;
        }
    }

    protected override string ServiceURL => "api/RegisterCreation";

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
