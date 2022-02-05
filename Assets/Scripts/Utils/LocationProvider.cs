using System;
using Mapbox.CheapRulerCs;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using UnityEngine;

public class LocationProvider : MonoBehaviour
{
    public event Action<Location> OnLocationUpdated;
    public static LocationProvider Instance = null;

    private ILocationProvider locationProvider = null;
    // Start is called before the first frame update
    void Start()
    {
        locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider;
        locationProvider.OnLocationUpdated += Device_OnLocationUpdated;
    }

    public Vector2d GetCurrentLocation()
    {
        return locationProvider.CurrentLocation.LatitudeLongitude;
    }
    public float GetOrientation()
    {
        return locationProvider.CurrentLocation.DeviceOrientation;
    }
    public float GetUserHeading()
    {
        return locationProvider.CurrentLocation.UserHeading;
    }
 public float GetAccuracy()
    {
        return locationProvider.CurrentLocation.Accuracy;
    }
    private void Device_OnLocationUpdated(Location obj)
    {

        OnLocationUpdated?.Invoke(obj);
    }

    public double Distance(double[] TargetPoint) // Calculate Distance using mapbox algorithm
    {
        CheapRuler ruler = new CheapRuler(locationProvider.CurrentLocation.LatitudeLongitude.x, CheapRulerUnits.Meters);
        double[] devicePosition = new double[2];
        if (locationProvider != null)
        {

            devicePosition[0] = locationProvider.CurrentLocation.LatitudeLongitude.x;
            devicePosition[1] = locationProvider.CurrentLocation.LatitudeLongitude.y;
        }
       
        return ruler.Distance(devicePosition, TargetPoint);
    }

    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

}
