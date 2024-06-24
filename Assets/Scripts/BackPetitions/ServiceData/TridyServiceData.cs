
using SnowKore.Services;
using System.Collections.Generic;

public class TridyServiceData : newServiceData
{
    private double lat, lon;

    public TridyServiceData(double lat, double lon)
    {
        this.lat = lat;
        this.lon = lon;
    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("lat", lat);
            body.Add("lon", lon);
            return body;
        }
    }

    protected override string ServiceURL => "api/UbicationMe";

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
