
using Mapbox.Unity.Location;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ARLocationOrientation : MonoBehaviour
{
    public UnityEvent OnAlligmentFinished, OnAppPuased;
    [SerializeField]
    private Camera arCamera;
    [SerializeField]
    private Transform ArRoot;
    [Range(0.0f, 15)]
    [SerializeField]
    private float offsetTrueNorth = 0.015f;
    
    [SerializeField]
    private int maxHeadingCount;
    [SerializeField]
    private int headingCount = 0;
    
    private LocationProvider locationProvider = null;
    float inverseRotation;
    private bool canCalculate = false;
   
    private void Start()
    {
      
        locationProvider = LocationProvider.Instance;
    
        canCalculate = true;
        locationProvider.OnLocationUpdated += LocationProvider_OnLocationUpdated;
    }

    private void LocationProvider_OnLocationUpdated(Location obj)
    {

        CalculateInverseRotation();

    }
    private void CalculateInverseRotation()
    {
        if (SamplesComplete())
        {
            canCalculate = false;
            return;
        }
        headingCount++;

    }
    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            headingCount = 0;
            canCalculate = true;
        }
    }

    private void Update()
    {
        if (canCalculate)
        {
            inverseRotation = (locationProvider.GetUserHeading() - arCamera.transform.localEulerAngles.y);
            ArRoot.rotation = Quaternion.AngleAxis((inverseRotation + offsetTrueNorth), Vector3.up);
        }


    }

   
    private bool SamplesComplete()
    {
        if (headingCount >= maxHeadingCount)
            return true;
        else
            return false;
    }

}
