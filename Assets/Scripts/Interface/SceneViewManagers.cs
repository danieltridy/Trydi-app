using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneViewManagers : MonoBehaviour
{
    public static SceneViewManagers Instance;

    [SerializeField]
    private LikesConsumer likesConsumer;

    [SerializeField]
    private ViewManagerItem viewManagerItem;

    [SerializeField]
    private ViewManagerItem viewManagerItemM;
    public ViewManagerItem ViewManagerItem { get => viewManagerItem; set => viewManagerItem = value; }
    public LikesConsumer LikesConsumer { get => likesConsumer; set => likesConsumer = value; }
    public ViewManagerItem ViewManagerItemM { get => viewManagerItemM; set => viewManagerItemM = value; }

    void Start()
    {
        Instance = this;
    }
}
