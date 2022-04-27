using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class MeshEditorMap : MonoBehaviour
{
    [SerializeField]
    private GameObject initCube;
    [SerializeField]
    private List<Item> itemsToSpawn;
    [SerializeField]
    private List<GameObject> generatedCubes = new List<GameObject>();
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private List<SavedMeshes> savedMeshes = new List<SavedMeshes>();
    private Dictionary<ObjectType, Item> Items = new Dictionary<ObjectType, Item>();
    private ObjectType itemToSpawn;
    private int idCount;
    private string jsonString;

    public string JsonString { get => jsonString; set => jsonString = value; }

    public void Start() {
        Init();
        Invoke("CreateMeshFromJson", 1f);
    }

    public void StartMesh()
    {
        initCube = transform.GetChild(0).gameObject;
        savedMeshes.Add(GetSavedMesh(initCube));
        generatedCubes.Add(initCube);
    }



    // Update is called once per frame
    
    private void Init()
    {
        //Fill Dictionary
        foreach (Item go in itemsToSpawn)
            Items.Add(go.ObjectType, go);

        itemToSpawn = ObjectType.Cube;
    }

   
    [EasyButtons.Button]
    public void CreateMeshFromJson()
    {
        transform.GetComponent<MeshEditorMap>().enabled = false;
        savedMeshes.Clear();
        generatedCubes.Clear();
        savedMeshes = JsonConvert.DeserializeObject<List<SavedMeshes>>(jsonString);
        foreach (SavedMeshes mesh in savedMeshes)
        {
            GameObject go = Instantiate(GetItemToSpawn(mesh.ObjectType));
            go.transform.SetParent(transform);
            go.transform.localPosition = new Vector3(mesh.Position.X, mesh.Position.Y, mesh.Position.Z-4);
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

            if(mesh.FontName!="")
            {
                ITextSettings textSettings = go.GetComponent<ITextSettings>();
                if (colorFocusable == null)
                    throw new Exception("ITextSettings  Not Found");

                textSettings.SetTextValue(mesh.TextValue);
                textSettings.SetFontText(Resources.Load<TMP_FontAsset>("Fonts/" + mesh.FontName));

            }
        }


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
        SavedMeshes newMesh = new SavedMeshes(idCount, focusable.GetFocusableType(), pos, rot, scale, itemColor, 
            focusable.GetfocusableTextureName(),focusable.GetFocusableTextValue(),focusable.GetFocusableFontName());
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
