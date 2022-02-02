using Mapbox.CheapRulerCs;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Utils;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Create all Sites With Data
/// </summary>
public class LocationPointManagerController : MonoBehaviour
{
    public static LocationPointManagerController Instance = null;
    // this script manage all LocationData
    [Header("Totems Data")]
    [SerializeField]
    private bool createPointWhenMapIsLoaded = false; // Map is loaded
 
    [SerializeField]
    private LocationData locationData;
    [SerializeField]
    private List<GameObject> pins; // HostSpot List
    [SerializeField]
    private GameObject Totem;// AR 3DModel
    [SerializeField]
    private float altitudeTreshold; // Fixed Altitude
    [SerializeField]
    private AbstractMap abstractMap; // Mapbox Map
  
    [Header("Visualization AR Settings")]
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float distanceToVisualize;
    private GameObject curretnHostspot;
    private LocationProvider locationProvider;//Mapbox Gps Provider
    private double[] targetDistance;
    public UnityEvent OnPOICreated, OnArrivedToDestiny, OnAwayFromDestiny;
    // GET SET
    public LocationData LocationData { get => locationData; set => locationData = value; }
    public List<GameObject> Pins { get => pins; set => pins = value; }
   
   


    private void Start()
    {
        locationProvider = LocationProvider.Instance;                                                      
        locationProvider.OnLocationUpdated += LocationProvider_OnLocationUpdated;
    }
   
    private void Awake()
    {
        abstractMap.OnInitialized += AbstractMap_OnInitialized; // When MapBox Is loaded

        if (Instance == null) // create Instance
            Instance = this;

    }

    private void AbstractMap_OnInitialized() // When Map is loaded
    {
        if (createPointWhenMapIsLoaded)
            SetInfoLocation();

        print("Map Init");

    }


    private void LocationProvider_OnLocationUpdated(Location obj) // Update Gps Position
    {
       

       
    }
    [EasyButtons.Button]
    public void SetInfoLocation() // Create All Sites
    {
        //for (int i = 0; i < locationData.LocationController.Count; i++)
        //{
        //    Vector2d pos = new Vector2d((float)locationData.LocationController[i].LatitudeLongitude[0], (float)locationData.LocationController[i].LatitudeLongitude[1]);
        //    GameObject spot3D = CreateHostSpot(locationPointPrefab2D, pos);
        //    pins.Add(spot3D);

        //    hostSpot3d.Id = locationData.LocationController[i].Id;
        //    hostSpot3d.LocationName = locationData.LocationController[i].LocationName;
        //    hostSpot3d.ImageSite.sprite = locationData.LocationController[i].Photo;
        //    spot3D.transform.parent = abstractMap.transform;
        //    spot3D.name = locationData.LocationController[i].LocationName;
        //}

        OnPOICreated.Invoke();
        print("Set POI in the Map");

    }

    // Create One HostSpot and Add Atrribute and Set to WorldPosition GPS Lat / Long
    private GameObject CreateHostSpot(GameObject Prefab, Vector2d pos, float altitude = 0)
    {
        GameObject hostpot;
        hostpot = Instantiate(Prefab);
        Vector3 worldCordenate = abstractMap.GeoToWorldPosition(pos, true);
        hostpot.transform.position = new Vector3(worldCordenate.x, worldCordenate.y - altitude, worldCordenate.z);
        return hostpot;
    }

    //private void GetDistanceToCurrentDestiny()
    //{
    //    targetDistance = locationData.LocationController[GlobalVariables.idSite].LatitudeLongitude;
    //    currentDistance.text = locationProvider.Distance(targetDistance).ToString("F2") + " Metros";

    //}

  

    public void CreateItem()
    {
        float distance = 10;
        Vector3 cameraPoint = cam.transform.position + cam.transform.forward * distance;
        curretnHostspot = Instantiate(Totem, cameraPoint, Quaternion.identity);
    }

    public void DeleteHostspot()
    {
        if (curretnHostspot != null)
            Destroy(curretnHostspot);
    }

    
    // Get The LocationInfo Data ScriptableObject

   

}
