using UnityEngine;

public class DevicePermissions : MonoBehaviour
{
    public static DevicePermissions Instance = null;
#if UNITY_ANDROID && !UNITY_EDITOR
    private AndroidJavaObject jo=null;
    private AndroidJavaObject activityContext=null;
    private void Start()
    {

        if (jo ==null)
        {
            using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                activityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
            }
            using (AndroidJavaClass pluginClass = new AndroidJavaClass("com.defaultcompany.gpsenable.EnableGPS"))
            {
                if(pluginClass!=null)
                {
                    jo = pluginClass.CallStatic<AndroidJavaObject>("instance");
                    jo.Call("SetContext", activityContext);
                   
                }
            }
        }

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void EnabbleGPS()
    {

        activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            jo.Call("OnEnableGPS");

        }));    
    }
    public void EnableSettings()
    {
        activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            jo.Call("OnEnableSettings");
        }));
    }

    public bool isGPSLocationServiceEnabled()
    {
        bool result = false;
        activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            result= jo.Call<bool>("isGPSLocationServiceEnabled");
        }));
        return result;
    }

    public bool isLocationServiceEnabled()
    {
        bool result = false;
        activityContext.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            result = jo.Call<bool>("isLocationServiceEnabled");
        }));
        return result;
    }


#endif

}
