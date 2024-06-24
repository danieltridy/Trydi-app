using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerUpdateTransform : MonoBehaviour
{


   
    [SerializeField]
    private Transform userLocationContent;
    [SerializeField]
    private float speedRot;
    [SerializeField]
    private AbstractMap _map;

    private Vector3 currentPos;
    private LocationProvider locationProvider;

    // Start is called before the first frame update
    void Start()
    {
        locationProvider = LocationProvider.Instance;
        locationProvider.OnLocationUpdated += Device_OnLocationUpdated;
    }

    private void Device_OnLocationUpdated(Location obj)
    {
        currentPos = _map.GeoToWorldPosition(locationProvider.GetCurrentLocation());
    }


    // Update is called once per frame
    void Update()
    {
        if (userLocationContent)
        {
            userLocationContent.position = currentPos;
            userLocationContent.localRotation = Quaternion.Lerp(userLocationContent.localRotation, Quaternion.AngleAxis(locationProvider.GetOrientation(), Vector3.up), Time.deltaTime * speedRot);
        }
    }
}