using Mapbox.Unity.Map;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour,IFocusable
{
    private LocationProvider locationProvider;
    private AbstractMap abstractMap;
    private double currentDistance;
    public LocationProvider LocationProvider { get => locationProvider; set => locationProvider = value; }

    //public double GetCurrentDistance { get => currentDistance; set => currentDistance = value; }

    public virtual void Start()
    {
        locationProvider = LocationProvider.Instance;
        abstractMap = FindObjectOfType<AbstractMap>();
      
    }

      public virtual double GetCurrentDistance()
    {
        Vector2d Pos = abstractMap.WorldToGeoPosition(transform.position);
        double[] target = new double[2];
        target[0] = Pos.x;
        target[1] = Pos.y;


        return locationProvider.Distance(target);
    }

    public abstract Transform GetCurrentFocusedTransform();
    public abstract Item GetCurrentFocusableReference();
}
