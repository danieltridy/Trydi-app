using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GPSUpdate : MonoBehaviour
{
    [SerializeField]
    private double distanceBeforeUpdate;
    private LocationProvider locationProvider;
    private bool firstGPSData = true;
    private double[] NextUpdateLocation= new double[2];
    public UnityEvent OnDistanceUpdated;


    private void Start()
    {
        locationProvider = LocationProvider.Instance;
        locationProvider.OnLocationUpdated += LocationProvider_OnLocationUpdated; ;
    }

    private void LocationProvider_OnLocationUpdated(Mapbox.Unity.Location.Location obj)
    {
        if(firstGPSData)
        {
            NextUpdateLocation[0] = locationProvider.GetCurrentLocation().x;
            NextUpdateLocation[0] = locationProvider.GetCurrentLocation().y;
            firstGPSData = false;

        }else if(locationProvider.Distance(NextUpdateLocation)>= distanceBeforeUpdate)
        {
            OnDistanceUpdated.Invoke();
            firstGPSData = false;
        }

    }
}
