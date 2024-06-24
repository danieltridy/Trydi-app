using SnowKore.Services;
using System.Collections.Generic;

public class RegisterDataLikes : newServiceData
{
  private int user_id;
  private int tridy_id;
    public RegisterDataLikes(int user_id, int tridy_id)
    {
        this.user_id = user_id;
        this.tridy_id = tridy_id;



    }

    protected override Dictionary<string, object> Body
    {
        get
        {
            Dictionary<string, object> body = new Dictionary<string, object>();
            body.Add("user_id", user_id);
            body.Add("tridy_id", tridy_id);
      
            return body;
        }
    }

    protected override string ServiceURL => "api/Likes";

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
