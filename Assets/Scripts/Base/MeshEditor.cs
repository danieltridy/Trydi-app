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
    private List<GameObject> itemSToSpawn;
    [SerializeField]
    private List<GameObject> generatedCubes = new List<GameObject>();
    [SerializeField]
    private Camera editorCam;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private List<SavedMeshes> savedMeshes = new List<SavedMeshes>();
    private Ray ray;
    private RaycastHit hit;
    private Dictionary<Vector3, Quaternion> rotations;
    private int idCount;
    Vector3 delta;
    GameObject current;

    // Start is called before the first frame update
    void Start()
    {
        SerilizedVector pos = new SerilizedVector(initCube.transform.localPosition.x, initCube.transform.localPosition.y, initCube.transform.localPosition.z);
        SerilizedVector rot = new SerilizedVector(initCube.transform.localEulerAngles.x, initCube.transform.localEulerAngles.y, initCube.transform.localEulerAngles.z);
        SerilizedVector scale = new SerilizedVector(initCube.transform.localScale.x, initCube.transform.localScale.y, initCube.transform.localScale.z);


        SavedMeshes newMesh = new SavedMeshes(0, ObjectType.Cube, pos, rot, scale);
        savedMeshes.Add(newMesh);
    }

    // Update is called once per frame
    void Update()
    {
        CreateMeshFromEditor();
    }

    public void CreateMeshFromEditor()
    {
        ray = editorCam.ScreenPointToRay(Input.mousePosition);
        faceSelector.SetActive(false);
        faceSelector.transform.parent = null;
        current = null;
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

        if (Input.GetMouseButtonUp(0))
        {
            if (current)
            {
                Vector3 direction = current.transform.position - current.transform.parent.position;
                Vector3 newPos = hit.transform.position + direction;
                var go = Instantiate(GetSelectGameObjectToSpawn(ObjectType.Cube), newPos, hit.transform.rotation);
                go.transform.localScale = hit.transform.parent.localScale;
                go.transform.SetParent(transform);
                generatedCubes.Add(go);
            }


        }
    }
    [EasyButtons.Button]
    private void CreateMeshFromJson()
    {
        savedMeshes.Clear();
        generatedCubes.Clear();
        //savedMeshes = (List<SavedMeshes>)JsonUtil.DeserializeJson(temp);
        savedMeshes = JsonConvert.DeserializeObject<List<SavedMeshes>>(temp);
        foreach (SavedMeshes mesh in savedMeshes)
        {
            GameObject go = Instantiate(GetSelectGameObjectToSpawn(mesh.ObjectType));
            go.transform.SetParent(transform);
            go.transform.localPosition = new Vector3(mesh.Position.X, mesh.Position.Y, mesh.Position.Z);
            go.transform.localEulerAngles = new Vector3(mesh.Rotation.X, mesh.Rotation.Y, mesh.Rotation.Z);
            go.transform.localScale = new Vector3(mesh.Scale.X, mesh.Scale.Y, mesh.Scale.Z);
        }


    }

    string temp;

    [EasyButtons.Button]
    private void SaveJson()
    {
        idCount = 1;
        for (int i = 0; i < generatedCubes.Count; i++)
        {
            SerilizedVector pos = new SerilizedVector(generatedCubes[i].transform.localPosition.x, generatedCubes[i].transform.localPosition.y, generatedCubes[i].transform.localPosition.z);
            SerilizedVector rot = new SerilizedVector(generatedCubes[i].transform.localEulerAngles.x, generatedCubes[i].transform.localEulerAngles.y, generatedCubes[i].transform.localEulerAngles.z);
            SerilizedVector scale = new SerilizedVector(generatedCubes[i].transform.localScale.x, generatedCubes[i].transform.localScale.y, generatedCubes[i].transform.localScale.z);
            SavedMeshes newMesh = new SavedMeshes(idCount, ObjectType.Cube, pos, rot, scale);
            newMesh.Id = idCount;
            newMesh.ObjectType = ObjectType.Cube;
            idCount++;
            savedMeshes.Add(newMesh);

        }
        temp = JsonUtil.SerializeJson(savedMeshes);
    }


    private GameObject GetSelectGameObjectToSpawn(ObjectType objectType)
    {
        GameObject go = null;
        switch (objectType)
        {
            case ObjectType.Cube:
                go = itemSToSpawn[0];
                break;
            case ObjectType.Text:
                go = itemSToSpawn[1];
                break;
            case ObjectType.Image:
                go = itemSToSpawn[2];
                break;

        }
        return go;
    }

}
