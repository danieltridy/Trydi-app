using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;

public class UserLocationController : MonoBehaviour
{


    private LocationProvider locationProvider;
    [SerializeField]
    private Transform cameraContent;

    [SerializeField]
    private AbstractMap _map;
    [SerializeField]
    private bool updateRotation;
    Vector3 currentPos;

    public bool UpdateRotation { get => updateRotation; set => updateRotation = value; }

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
        cameraContent.position = currentPos;
        cameraContent.localRotation = Quaternion.Lerp(cameraContent.localRotation, Quaternion.AngleAxis(locationProvider.GetOrientation(), Vector3.up), Time.deltaTime * 3);
    }
}