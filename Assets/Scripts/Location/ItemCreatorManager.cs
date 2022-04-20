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
    private List<TridyDataOnly> items; 
    [SerializeField]
    private TridyDataOnly itemPrefab;
    [SerializeField]
    private float altitudeTreshold;
    [SerializeField]
    private AbstractMap abstractMap;
    public UnityEvent OnSpawnItems;
  
    public TridyDataOnly ItemPrefab { get => itemPrefab; set => itemPrefab = value; }

    public void GetTridys(TridysData data) {

        LocationController.Clear();
        Location latitude = new Location();

        for (int i=0; i<data.data.Count;i++) {
            latitude.LatitudeLongitude.x = data.data[i].latitude;
            latitude.LatitudeLongitude.y = data.data[i].longitude;
            LocationController.Add(latitude);
        }

        CreateItems(data);
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
            //CreateItems();
        print("Map Init");
    }

    [EasyButtons.Button]
    public void CreateItems(TridysData data) // Create All Sites
    {
        foreach (var s in items) {
            DestroyImmediate(s.gameObject);
                }
        items.Clear();
        for (int i = 0; i < LocationController.Count; i++)
        {
            Vector2d pos = new Vector2d((float)LocationController[i].LatitudeLongitude[0], (float)LocationController[i].LatitudeLongitude[1]);
            TridyDataOnly newItem = SpawnItem(itemPrefab, pos);
            newItem.Tridy.id = data.data[i].id;
            newItem.Tridy.name = data.data[i].name;
            newItem.Tridy.likes = data.data[i].likes;
            newItem.Tridy.description = data.data[i].description;
            newItem.Tridy.estructura = data.data[i].estructura;
            newItem.Tridy.user_id = data.data[i].user_id;
            newItem.Tridy.name_user = data.data[i].name_user;
            newItem.Tridy.looks = data.data[i].looks;
            items.Add(newItem);
            newItem.transform.parent = abstractMap.transform;
            newItem.GetComponent<MeshEditorMap>().JsonString = data.data[i].estructura;
            //newItem.GetComponent<MeshEditorMap>().CreateMeshFromJson();

        }
        OnSpawnItems.Invoke();
    }

    private TridyDataOnly SpawnItem(TridyDataOnly Prefab, Vector2d pos)
    {
        TridyDataOnly hostpot;
        hostpot = Instantiate(Prefab);
        Vector3 worldCordenate = abstractMap.GeoToWorldPosition(pos, true);
        hostpot.transform.position = new Vector3(worldCordenate.x, worldCordenate.y + altitudeTreshold, worldCordenate.z);
        return hostpot;
    }

  


}
