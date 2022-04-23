using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateARObject : MonoBehaviour
{
    public static CreateARObject Instance;
  
    [SerializeField]
    private MeshEditor meshEditor;

    public string estru;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddInformation(string estru) {
        this.estru = estru;
    }
    public void CreateTridyEstru() {
        meshEditor.JsonString = estru;
        meshEditor.CreateMeshFromJson();
    }

   
}