using Mapbox.Unity.Map;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour,IFocusable
{
    private LocationProvider locationProvider;
    [SerializeField]
    private ObjectType objectType;
    private AbstractMap abstractMap;
    private double currentDistance;
    public LocationProvider LocationProvider { get => locationProvider; set => locationProvider = value; }
    public ObjectType ObjectType { get => objectType; set => objectType = value; }

    //public double GetCurrentDistance { get => currentDistance; set => currentDistance = value; }

    public virtual void Start()
    {
        locationProvider = LocationProvider.Instance;
        abstractMap = FindObjectOfType<AbstractMap>();

      
    }
    private void Reset()
    {
        Init();
    }
    public virtual double GetCurrentDistance()
    {
        Vector2d Pos = abstractMap.WorldToGeoPosition(transform.position);
        double[] target = new double[2];
        target[0] = Pos.x;
        target[1] = Pos.y;


        return locationProvider.Distance(target);
    }

    public abstract void Init();

    public abstract Transform GetCurrentFocusedTransform();

    public abstract GameObject GetCurrentFocusableObject();

    public abstract Vector3 GetCurrentRGBFocusable();

    public abstract string GetfocusableTextureName();

  
}
