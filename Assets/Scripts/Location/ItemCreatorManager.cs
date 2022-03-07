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
    private bool SpawnItemWhenMapLoaded = false; 
    public List<Location> LocationController= new List<Location>();
    [SerializeField]
    private List<GameObject> items; 
    [SerializeField]
    private GameObject itemPrefab;
    [SerializeField]
    private float altitudeTreshold;
    [SerializeField]
    private AbstractMap abstractMap;
    public UnityEvent OnSpawnItems;
  
    public GameObject ItemPrefab { get => itemPrefab; set => itemPrefab = value; }

    public void GetTridys(TridysData data) {
        Location latitude = new Location();

        for (int i=0; i<data.data.Count;i++) {
            latitude.LatitudeLongitude.x = data.data[i].latitude;
            latitude.LatitudeLongitude.y = data.data[i].longitude;
            LocationController.Add(latitude);
        }

        CreateItems();
    }

    private void Awake()
    {
        //abstractMap.OnInitialized += AbstractMap_OnInitialized; // When MapBox Is loaded

        if (Instance == null) // create Instance
            Instance = this;
    }


    private void AbstractMap_OnInitialized() // When Map is loaded
    {
        if (SpawnItemWhenMapLoaded)
            CreateItems();
        print("Map Init");
    }

    [EasyButtons.Button]
    public void CreateItems() // Create All Sites
    {
        for (int i = 0; i < LocationController.Count; i++)
        {
            Vector2d pos = new Vector2d((float)LocationController[i].LatitudeLongitude[0], (float)LocationController[i].LatitudeLongitude[1]);
            GameObject newItem = SpawnItem(itemPrefab, pos);
            items.Add(newItem);
            newItem.transform.parent = abstractMap.transform;
        }
        OnSpawnItems.Invoke();
        
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
