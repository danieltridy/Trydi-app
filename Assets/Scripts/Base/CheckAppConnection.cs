using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAppConnection 
{
    

  public static bool IsConnected()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
            return false;
        else
            return true;
    }
}
