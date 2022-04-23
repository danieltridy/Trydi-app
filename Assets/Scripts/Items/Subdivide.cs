using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subdivide : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    public Vector3 cubesPerAxis;
  

    void Start()
    {
       
    }
    [EasyButtons.Button]
   private  void SubdivideCube()
    {
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

        Destroy(target);
    }
   
    void CreateCube(Vector3 coordinates)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //Renderer rd = cube.GetComponent<Renderer>();
        //rd.material = GetComponent<Renderer>().material;

        cube.transform.localScale = new Vector3( (target.transform.localScale.x / cubesPerAxis.x), (target.transform.localScale.y / cubesPerAxis.y), (target.transform.localScale.z / cubesPerAxis.z));

        Vector3 firstCube = target.transform.position - target.transform.localScale / 2 + cube.transform.localScale / 2;
        cube.transform.position = firstCube + Vector3.Scale(coordinates, cube.transform.localScale);
       
    }
}
