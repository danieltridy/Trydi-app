using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneViewManagers : MonoBehaviour
{
    public static SceneViewManagers Instance;

   
    [SerializeField]
    private ViewManagerItem viewManagerItem;

    public ViewManagerItem ViewManagerItem { get => viewManagerItem; set => viewManagerItem = value; }

    void Start()
    {
        Instance = this;
    }
}
