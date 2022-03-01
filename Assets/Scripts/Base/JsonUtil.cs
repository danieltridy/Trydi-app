using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonUtil
{

    public static string SerializeJson(object value)
    {
        string json = JsonConvert.SerializeObject(value);
        Debug.Log(json);
        return json;
    }
}

