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
    private GameObject parentContent;
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
    public Camera EditorCam { get => editorCam; set => editorCam = value; }
    public List<GameObject> GeneratedItems { get => generatedItems; set => generatedItems = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        Init();

    }
    public void OffStart()
    {
        start = false;
    }

    public void ItemToSpawnCube()
    {
        itemToSpawn = ObjectType.Cube;
    }
    public void ItemToSpawnText()
    {
        itemToSpawn = ObjectType.Text;
    }

    private void SelectionManager_OnFocusableSet(IFocusable obj)
    {
        focusableSelected = obj;
    }

    public void ResetMesh()
    {
        generatedItems.Clear();
        savedMeshes.Clear();
        foreach (Transform child in parentContent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    [EasyButtons.Button]
    public void Init()
    {
        //Fill Dictionary
        foreach (Item go in itemsToSpawn)
            Items.Add(go.ObjectType, go);

        itemToSpawn = ObjectType.Cube;
    }
    [EasyButtons.Button]
    public void StartMesh()
    {
        if (!start)
        {
            initCube = parentContent.transform.GetChild(0).gameObject;
            transform.GetComponent<ItemsCreator>().enabled = false;
            selectionManager = SelectionManager.Instance;
            savedMeshes.Add(GetSavedMesh(initCube));
            generatedItems.Add(initCube);
            selectionManager.OnFocusableSet += SelectionManager_OnFocusableSet;
            start = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        CreateMeshFromEditor();
    }

    Vector3 operation;
    public void CreateMeshFromEditor()
    {

        //TODO: Refactorizar esto
        ray = editorCam.ScreenPointToRay(Input.mousePosition);
        GameObject current = null;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, layerMask))
        {
            if (!current)
                current = hit.transform.gameObject;
            if (current.GetComponent<LocalDireccionFromFace>())
            {
                operation = current.GetComponent<LocalDireccionFromFace>().GetDirection();
            }

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
                Vector3 normal = operation;
                var go = Instantiate(GetItemToSpawn(itemToSpawn), Vector3.zero, Quaternion.identity);
                go.transform.parent = current.transform.parent;
                go.transform.localRotation = Quaternion.identity;
                go.transform.localPosition = normal;
                SelectionManager.Instance.CurrentFocusable = go.GetComponent<IFocusable>();
                go.transform.localScale = Vector3.one;
                go.transform.SetParent(parentContent.transform);
                generatedItems.Add(go);

            }
        }
    }

    //private Vector3 GetNormalDirection(Vector3 normal)
    //{
    //    Vector3 result;
    //    if (normal.x >)

    //}


    [EasyButtons.Button]
    public void CreateMeshFromJson()
    {
        ResetMesh();
        savedMeshes.Clear();
        generatedItems.Clear();
        savedMeshes = JsonConvert.DeserializeObject<List<SavedMeshes>>(jsonString);
        parentContent.transform.localScale = new Vector3(savedMeshes[0].Scale.X, savedMeshes[0].Scale.Y, savedMeshes[0].Scale.Z);
        for (int i = 1; i < savedMeshes.Count; i++)
        {
            GameObject go = Instantiate(GetItemToSpawn(savedMeshes[i].ObjectType));
            go.transform.SetParent(parentContent.transform);
            go.transform.localPosition = new Vector3(savedMeshes[i].Position.X, savedMeshes[i].Position.Y, savedMeshes[i].Position.Z);
            go.transform.localEulerAngles = new Vector3(savedMeshes[i].Rotation.X, savedMeshes[i].Rotation.Y, savedMeshes[i].Rotation.Z);
            go.transform.localScale = new Vector3(savedMeshes[i].Scale.X, savedMeshes[i].Scale.Y, savedMeshes[i].Scale.Z);
            generatedItems.Add(go);
            if (savedMeshes[i].TextureName != "")
            {
                IMaterialFocusable materialFocusable = go.GetComponent<IMaterialFocusable>();
                if (materialFocusable == null)
                    throw new Exception("IMaterial Focusable Not Found");
                materialFocusable.OnTextureChanged(Resources.Load<Texture>("Textures/" + savedMeshes[i].TextureName));
            }

            IColorFocusable colorFocusable = go.GetComponent<IColorFocusable>();
            if (colorFocusable == null)
                throw new Exception("IColorFocusable  Not Found");
            Color newcolor = new Color(savedMeshes[i].Color.X, savedMeshes[i].Color.Y, savedMeshes[i].Color.Z);
            colorFocusable.OnColorChanged(newcolor);

            if (savedMeshes[i].FontName != "")
            {
                ITextSettings textSettings = go.GetComponent<ITextSettings>();
                if (colorFocusable == null)
                    throw new Exception("ITextSettings  Not Found");

                textSettings.SetTextValue(savedMeshes[i].TextValue);
                textSettings.SetFontText(Resources.Load<TMP_FontAsset>("Fonts/" + savedMeshes[i].FontName));

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
                cube.transform.parent = parentContent.transform;
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
        savedMeshes.Add(GetSavedMesh(parentContent));

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

    private void OnDrawGizmos()
    {
        //if (!current)
        //    return;

        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(current.transform.position, hit.normal);
        //Gizmos.color = Color.red;
        //Gizmos.DrawLine(current.transform.position, operation*3f);

    }

}
