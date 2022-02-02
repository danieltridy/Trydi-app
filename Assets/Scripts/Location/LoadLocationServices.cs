using Mapbox.Unity.Location;
using System.Collections;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.Events;

public class LoadLocationServices : MonoBehaviour
{
    public UnityEvent OnLocationServicesLoaded;
    [SerializeField]
    private bool loadForIOS;
    private ILocationProvider locationProvider = null;
    // Start is called before the first frame update
    void Start()
    {
       // Invoke("WaitToLoad", 2);
        Input.compass.enabled = true;
        Input.location.Start();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        LoadServicesLocation();
    }

    public void LoadServicesLocation()
    {
        if (loadForIOS)
           Invoke("WaitToLoad", 2);
        else
           StartCoroutine(WaitToSetLocationServices());
    }

   
    private void WaitToLoad()
    {
        if (loadForIOS)
            OnLocationServicesLoaded.Invoke();
    }

    private IEnumerator WaitToSetLocationServices()
    {

        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
        if (!Input.location.isEnabledByUser)
            yield return new WaitForSeconds(3);

        
        // Start service before querying location

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            print("call");
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else 
        {
            yield return new WaitForSeconds(5f);
            OnLocationServicesLoaded.Invoke();
            print("Servicio Iniciado");
        }
    }

}
