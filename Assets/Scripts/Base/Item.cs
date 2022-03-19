using Mapbox.Unity.Map;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour,IFocusable
{
    private LocationProvider locationProvider;
    private AbstractMap abstractMap;
    private double currentDistance;
    public LocationProvider LocationProvider { get => locationProvider; set => locationProvider = value; }
    //public double GetCurrentDistance { get => currentDistance; set => currentDistance = value; }

    private void Start()
    {
        locationProvider = LocationProvider.Instance;
        abstractMap = FindObjectOfType<AbstractMap>();
      
    }

    public double GetCurrentDistance()
    {
        Vector2d Pos = abstractMap.WorldToGeoPosition(transform.position);
        double[] target = new double[2];
        target[0] = Pos.x;
        target[1] = Pos.y;


        return locationProvider.Distance(target);
    }

    public Transform GetCurrentFocusedTransform()
    {
       return transform;
    }
}
