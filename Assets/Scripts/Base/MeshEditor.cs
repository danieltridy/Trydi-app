using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class MeshEditor : MonoBehaviour
{
    [SerializeField]
    private GameObject initCube;
    [SerializeField]
    private GameObject faceSelector;
    [SerializeField]
    private List<Item> itemsToSpawn;
    [SerializeField]
    private List<GameObject> generatedCubes = new List<GameObject>();
    [SerializeField]
    private Camera editorCam;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private List<SavedMeshes> savedMeshes = new List<SavedMeshes>();
    private Dictionary<ObjectType, Item> Items = new Dictionary<ObjectType, Item>();
    private ObjectType itemToSpawn;
    private Ray ray;
    private RaycastHit hit;
    private int idCount;
    private string jsonString;

    public string JsonString { get => jsonString; set => jsonString = value; }

    public void Start() {
        Init();
        transform.GetComponent<MeshEditor>().enabled = false;
    }


    public void ResetMesh()
    {
        generatedCubes.Clear();
        savedMeshes.Clear();
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }
    public void StartMesh()
    {
        initCube = transform.GetChild(0).gameObject;
        savedMeshes.Add(GetSavedMesh(initCube));
        generatedCubes.Add(initCube);
    }



    // Update is called once per frame
    void Update()
    {
        CreateMeshFromEditor();
    }
    private void Init()
    {
        //Fill Dictionary
        foreach (Item go in itemsToSpawn)
            Items.Add(go.ObjectType, go);

        itemToSpawn = ObjectType.Cube;
    }

    public void CreateMeshFromEditor()
    {

        //TODO: Refactorizar esto
        ray = editorCam.ScreenPointToRay(Input.mousePosition);
        faceSelector.SetActive(false);
        faceSelector.transform.parent = null;
        GameObject current = null;
        //
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, layerMask))
        {
            if (!current)
            {
                current = hit.transform.gameObject;
                faceSelector.transform.parent = hit.transform;
                faceSelector.transform.localPosition = Vector3.zero;
                faceSelector.transform.localRotation = Quaternion.identity;
                faceSelector.transform.localScale = Vector3.one;
            }
            faceSelector.SetActive(true);
        }
        //Spawn item
        if (Input.GetMouseButtonUp(0))
        {
            if (current)
            {
                Vector3 direction = current.transform.position - current.transform.parent.position;
                Vector3 newPos = hit.transform.position + direction;
                var go = Instantiate(GetItemToSpawn(itemToSpawn), newPos, hit.transform.rotation);
                go.transform.localScale = hit.transform.parent.localScale;
                go.transform.SetParent(transform);
                generatedCubes.Add(go);
            }
        }
    }
    [EasyButtons.Button]
    public void CreateMeshFromJson()
    {
        ResetMesh();
        savedMeshes.Clear();
        generatedCubes.Clear();
        savedMeshes = JsonConvert.DeserializeObject<List<SavedMeshes>>(jsonString);
        foreach (SavedMeshes mesh in savedMeshes)
        {
            GameObject go = Instantiate(GetItemToSpawn(mesh.ObjectType));
            go.transform.SetParent(transform);
            go.transform.localPosition = new Vector3(mesh.Position.X, mesh.Position.Y, mesh.Position.Z);
            go.transform.localEulerAngles = new Vector3(mesh.Rotation.X, mesh.Rotation.Y, mesh.Rotation.Z);
            go.transform.localScale = new Vector3(mesh.Scale.X, mesh.Scale.Y, mesh.Scale.Z);
            if (mesh.TextureName != "")
            {
                IMaterialFocusable materialFocusable = go.GetComponent<IMaterialFocusable>();
                if (materialFocusable == null)
                    throw new Exception("IMaterial Focusable Not Found");
                materialFocusable.OnTextureChanged(Resources.Load<Texture>("Textures/" + mesh.TextureName));
            }

            IColorFocusable colorFocusable = go.GetComponent<IColorFocusable>();
            if (colorFocusable == null)
                throw new Exception("IColorFocusable  Not Found");
            Color newcolor = new Color(mesh.Color.X, mesh.Color.Y, mesh.Color.Z);
            colorFocusable.OnColorChanged(newcolor);
        }


    }


  
 

    [EasyButtons.Button]
    public void SaveJson()
    {
        idCount = 1;
        savedMeshes.Clear();
        for (int i = 0; i < generatedCubes.Count; i++)
        {
            idCount++;
            savedMeshes.Add(GetSavedMesh(generatedCubes[i]));

        }
        jsonString = JsonUtil.SerializeJson(savedMeshes);
    }

    private SavedMeshes GetSavedMesh(GameObject itemToSaveConfig)
    {
        SerilizedVector pos = new SerilizedVector(itemToSaveConfig.transform.localPosition.x, itemToSaveConfig.transform.localPosition.y, itemToSaveConfig.transform.localPosition.z);
        SerilizedVector rot = new SerilizedVector(itemToSaveConfig.transform.localEulerAngles.x, itemToSaveConfig.transform.localEulerAngles.y, itemToSaveConfig.transform.localEulerAngles.z);
        SerilizedVector scale = new SerilizedVector(itemToSaveConfig.transform.localScale.x, itemToSaveConfig.transform.localScale.y, itemToSaveConfig.transform.localScale.z);
        IFocusable focusable = itemToSaveConfig.GetComponent<IFocusable>();
        if (focusable == null)
            throw new Exception("Current Object Does not Implement Interface");

        SerilizedVector itemColor = new SerilizedVector(focusable.GetCurrentRGBFocusable().x, focusable.GetCurrentRGBFocusable().y, focusable.GetCurrentRGBFocusable().z);
        SavedMeshes newMesh = new SavedMeshes(idCount, ObjectType.Cube, pos, rot, scale, itemColor, focusable.GetfocusableTextureName());
        return newMesh;
    }

    public void SetItemToSpawn(ObjectType objectType)
    {
        itemToSpawn = objectType;
    }
    private GameObject GetItemToSpawn(ObjectType objectType)
    {
        return Items[objectType].gameObject;
    }

}
