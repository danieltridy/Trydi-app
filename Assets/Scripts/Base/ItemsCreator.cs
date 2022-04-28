using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class ItemsCreator : MonoBehaviour
{
    public static ItemsCreator Instance = null;
    [Header("General Settings")]
    [SerializeField]
    private GameObject initCube;
    [SerializeField]
    private GameObject faceSelector;
    [SerializeField]
    private ObjectType itemToSpawn;
    [SerializeField]
    private List<Item> itemsToSpawn;
    [SerializeField]
    private List<GameObject> generatedItems = new List<GameObject>();
    [SerializeField]
    private Camera editorCam;
    [SerializeField]
    private LayerMask layerMask;
    [Header("JSON List")]
    [SerializeField]
    private List<SavedMeshes> savedMeshes = new List<SavedMeshes>();
    [Header("Subdivision Settings")]
    [SerializeField]
    private int subdivision = 2;

    private Dictionary<ObjectType, Item> Items = new Dictionary<ObjectType, Item>();

    private SelectionManager selectionManager;
    private Ray ray;
    private RaycastHit hit;
    private int idCount;
    private string jsonString;
    private IFocusable focusableSelected;
    public bool start;
    public string JsonString { get => jsonString; set => jsonString = value; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void OffStart()
    {
        start = false;
    }



    private void SelectionManager_OnFocusableSet(IFocusable obj)
    {
        focusableSelected = obj;
    }

    public void ResetMesh()
    {
        generatedItems.Clear();
        savedMeshes.Clear();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }


    public void StartMesh()
    {
        if (!start)
        {
            initCube = transform.GetChild(0).gameObject;
            transform.GetComponent<ItemsCreator>().enabled = false;
            selectionManager = SelectionManager.Instance;
            savedMeshes.Add(GetSavedMesh(initCube));
            generatedItems.Add(initCube);
            generatedItems.Add(transform.GetChild(1).gameObject);
            selectionManager.OnFocusableSet += SelectionManager_OnFocusableSet;
            start = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        CreateMeshFromEditor();
    }
    public void Init()
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
        GameObject current = null;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, layerMask))
        {
            if (!current)
                current = hit.transform.gameObject;
        }


        #region faceSelectorTodo
        //faceSelector.SetActive(false);
        //faceSelector.transform.parent = null;

        ////
        //if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, layerMask))
        //{
        //    if (!current)
        //    {
        //        current = hit.transform.gameObject;
        //        faceSelector.transform.parent = hit.transform;
        //        faceSelector.transform.localPosition = Vector3.zero;
        //        faceSelector.transform.localRotation = Quaternion.identity;
        //        faceSelector.transform.localScale = Vector3.one;
        //    }
        //    faceSelector.SetActive(true);
        //}
        #endregion

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
                generatedItems.Add(go);
            }
        }
    }
    [EasyButtons.Button]
    public void CreateMeshFromJson()
    {
        ResetMesh();
        savedMeshes.Clear();
        generatedItems.Clear();
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

            if (mesh.FontName != "")
            {
                ITextSettings textSettings = go.GetComponent<ITextSettings>();
                if (colorFocusable == null)
                    throw new Exception("ITextSettings  Not Found");

                textSettings.SetTextValue(mesh.TextValue);
                textSettings.SetFontText(Resources.Load<TMP_FontAsset>("Fonts/" + mesh.FontName));

            }
        }
    }
    [EasyButtons.Button]
    public void SubdivideMesh()
    {
        if (focusableSelected == null)
            throw new Exception("Focusable is Null");



        if (focusableSelected.GetFocusableType() == ObjectType.Cube)
        {
            List<GameObject> cubes = new List<GameObject>();
            GameObject tempParent = new GameObject("TempParent");
            GameObject target = focusableSelected.GetCurrentFocusableObject();
            tempParent.transform.position = focusableSelected.GetCurrentFocusedTransform().position;

            for (int x = 0; x < subdivision; x++)
            {
                for (int y = 0; y < subdivision; y++)
                {
                    for (int z = 0; z < subdivision; z++)
                    {

                        GameObject cube = Instantiate(GetItemToSpawn(focusableSelected.GetFocusableType()));
                        cubes.Add(cube);
                        generatedItems.Add(cube);
                        Renderer rd = cube.GetComponent<Renderer>();
                        rd.material = target.GetComponent<Renderer>().material;

                        cube.transform.localScale = (target.transform.localScale) / subdivision;
                        Vector3 firstCube = target.transform.position - target.transform.localScale / 2 + cube.transform.localScale / 2;
                        cube.transform.position = firstCube + Vector3.Scale(new Vector3(x, y, z), cube.transform.localScale);
                        cube.transform.parent = tempParent.transform;
                        cube.transform.localRotation = Quaternion.Inverse(tempParent.transform.rotation);


                    }
                }
            }
            tempParent.transform.rotation = focusableSelected.GetCurrentFocusedTransform().rotation;
            foreach (GameObject cube in cubes)
            {
                cube.transform.parent = null;
                cube.transform.parent = transform;
            }

            cubes.Clear();
            generatedItems.Remove(focusableSelected.GetCurrentFocusableObject());
            Destroy(tempParent);
            Destroy(focusableSelected.GetCurrentFocusableObject());

        }
    }




    [EasyButtons.Button]
    public void SaveJson()
    {
        idCount = 1;
        savedMeshes.Clear();
        for (int i = 0; i < generatedItems.Count; i++)
        {
            idCount++;
            savedMeshes.Add(GetSavedMesh(generatedItems[i]));

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
        SavedMeshes newMesh = new SavedMeshes(idCount, focusable.GetFocusableType(), pos, rot, scale, itemColor, focusable.GetfocusableTextureName(), focusable.GetFocusableTextValue(), focusable.GetFocusableFontName());
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
