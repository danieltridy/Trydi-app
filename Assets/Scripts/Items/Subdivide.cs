using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subdivide : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Transform Meshparent;
    public Vector3 cubesPerAxis;
    GameObject tempParent;
    private List<GameObject> cubes= new List<GameObject>();
    void Start()
    {
        
       
    }
    [EasyButtons.Button]
   private  void SubdivideCube()
    {
        tempParent = new GameObject("Parent");
        tempParent.transform.position = target.transform.position;

        for (int x = 0; x < cubesPerAxis.x; x++)
        {
            for (int y = 0; y < cubesPerAxis.y; y++)
            {
                for (int z = 0; z < cubesPerAxis.z; z++)
                {
                    CreateCube(new Vector3(x, y, z));
                }
            }
        }
        tempParent.transform.rotation = target.transform.rotation;
        foreach (GameObject cube in cubes)
        {
            cube.transform.parent = null;
            cube.transform.parent = Meshparent;
        }  
        cubes.Clear();
        Destroy(tempParent);
        Destroy(target);
    }
   
    void CreateCube(Vector3 coordinates)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubes.Add(cube);
        Renderer rd = cube.GetComponent<Renderer>();
        rd.material = target.GetComponent<Renderer>().material;

        cube.transform.localScale = new Vector3( (target.transform.localScale.x / cubesPerAxis.x), (target.transform.localScale.y / cubesPerAxis.y), (target.transform.localScale.z / cubesPerAxis.z));
        Vector3 firstCube = target.transform.position - target.transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);
        cube.transform.parent = tempParent.transform;
        cube.transform.localRotation = Quaternion.Inverse(tempParent.transform.rotation);
        




    }
}
