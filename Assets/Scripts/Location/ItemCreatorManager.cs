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
/// Create Items With Data
/// </summary>
public class ItemCreatorManager : MonoBehaviour
{
    public static ItemCreatorManager Instance = null;

    [Header("Item Data")]
    [SerializeField]
    private bool createPointWhenMapIsLoaded = false; 
    [SerializeField]
    private LocationData locationData;
    [SerializeField]
    private List<GameObject> items; 
    [SerializeField]
    private GameObject itemPrefab;
    [SerializeField]
    private float altitudeTreshold;
    [SerializeField]
    private double DistanceUpdate=50;

    private double[] NextUpdate= new double[2];
    [SerializeField]
    private AbstractMap abstractMap;
    private LocationProvider locationProvider;
    private bool firstGpsData = true;
    public UnityEvent OnSpawnItems,OnDistanceUpdated;
    public LocationData LocationData { get => locationData; set => locationData = value; }
    public GameObject ItemPrefab { get => itemPrefab; set => itemPrefab = value; }
    public LocationProvider LocationProvider { get => locationProvider; set => locationProvider = value; }

    private void Awake()
    {
        abstractMap.OnInitialized += AbstractMap_OnInitialized; // When MapBox Is loaded

        if (Instance == null) // create Instance
            Instance = this;

    }

    private void Start()
    {
        locationProvider = LocationProvider.Instance;
        LocationProvider.OnLocationUpdated += LocationProvider_OnLocationUpdated;
    }

    private void LocationProvider_OnLocationUpdated(Location obj)
    {
        if(firstGpsData)
        {
            NextUpdate[0] = locationProvider.GetCurrentLocation().x ;
            NextUpdate[1] = locationProvider.GetCurrentLocation().y ;
            firstGpsData = false;
        }
        else if(locationProvider.Distance(NextUpdate) >= DistanceUpdate)
        {
            OnDistanceUpdated.Invoke();
            print("New Update");
            firstGpsData = true;
        }
    }

    private void AbstractMap_OnInitialized() // When Map is loaded
    {
        if (createPointWhenMapIsLoaded)
            CreateItems();

        print("Map Init");

    }

    [EasyButtons.Button]
    private void CreateItems() // Create All Sites
    {
        for (int i = 0; i < locationData.LocationController.Count; i++)
        {
            Vector2d pos = new Vector2d((float)locationData.LocationController[i].LatitudeLongitude[0], (float)locationData.LocationController[i].LatitudeLongitude[1]);
            GameObject newItem = SpawnItem(itemPrefab, pos);
            items.Add(newItem);
            newItem.transform.parent = abstractMap.transform;
        }

        OnSpawnItems.Invoke();
        print("Set POI in the Map");

    }

  
    private GameObject SpawnItem(GameObject Prefab, Vector2d pos)
    {
        GameObject hostpot;
        hostpot = Instantiate(Prefab);
        Vector3 worldCordenate = abstractMap.GeoToWorldPosition(pos, true);
        hostpot.transform.position = new Vector3(worldCordenate.x, worldCordenate.y + altitudeTreshold, worldCordenate.z);
        return hostpot;
    }

  


}
