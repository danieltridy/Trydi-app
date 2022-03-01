using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshEditor : MonoBehaviour
{
    [SerializeField]
    private GameObject faceSelector;
    [SerializeField]
    private GameObject prefabCube;
    [SerializeField]
    private List<GameObject> generatedCubes=new List<GameObject>();
    [SerializeField]
    private Camera editorCam;
    [SerializeField]
    private List<SavedMeshes> savedMeshes =new List<SavedMeshes>();
   
    private Dictionary<Vector3, Quaternion> rotations;
    private Ray ray;
    private RaycastHit hit;
    private int idCount;
    Vector3 delta;


    // Start is called before the first frame update
    void Start()
    {
        rotations = new Dictionary<Vector3, Quaternion>()
        {
            {Vector3.back,Quaternion.identity },
            {Vector3.up,Quaternion.Euler(90,0,0) },
            {Vector3.left,Quaternion.Euler(0,90,0)},
            {Vector3.forward,Quaternion.Euler(0,180,0) },
            {Vector3.down,Quaternion.Euler(270,0,0) },
            {Vector3.right,Quaternion.Euler(0,270,0) }

        };

    }

    // Update is called once per frame
    void Update()
    {
        ray = editorCam.ScreenPointToRay(Input.mousePosition);
        faceSelector.SetActive(false);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, 100))
        {
            Debug.DrawLine(ray.origin, hit.point);
            delta = hit.point - hit.transform.position;
            delta *= 2;
            float f = 0.95f;
            delta.x = Mathf.Abs(delta.x) < f ? 0 : delta.x;
            delta.y = Mathf.Abs(delta.y) < f ? 0 : delta.y;
            delta.z = Mathf.Abs(delta.z) < f ? 0 : delta.z;
            if (rotations.ContainsKey(delta))
            {
                faceSelector.SetActive(true);
                faceSelector.transform.position = hit.transform.position;
                faceSelector.transform.rotation = rotations[delta];
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 newPos = delta + hit.transform.position;
            var go = Instantiate(prefabCube, newPos, Quaternion.identity);
            generatedCubes.Add(go);

        }
    }
    [EasyButtons.Button]
    private void SaveJson()
    {
        savedMeshes.Clear();
        idCount = 0;
        for (int i = 0; i < generatedCubes.Count; i++)
        {
            SavedMeshes newMesh = new SavedMeshes();
            newMesh.Id = idCount;
            newMesh.ObjectType = ObjectType.Cube;

            SerilizedVector pos = new SerilizedVector(generatedCubes[i].transform.position.x, generatedCubes[i].transform.position.y, generatedCubes[i].transform.position.z);
            newMesh.Position=pos;

            SerilizedVector rot = new SerilizedVector(generatedCubes[i].transform.rotation.x, generatedCubes[i].transform.rotation.y, generatedCubes[i].transform.rotation.z);
            newMesh.Rotation = rot;

            SerilizedVector scale = new SerilizedVector(generatedCubes[i].transform.localScale.x, generatedCubes[i].transform.localScale.y, generatedCubes[i].transform.localScale.z);


            savedMeshes.Add(newMesh);
        }
        JsonUtil.SerializeJson(savedMeshes);
    }
    // debe tener una lista de cubos creados
    // debe tener un metodo que permita borrar todos los cubos ya guardados en un json para crear otro mesh
    // debe guardar pos, rot en un Json
    //Seleccionar las caras
    // crearlas
}
