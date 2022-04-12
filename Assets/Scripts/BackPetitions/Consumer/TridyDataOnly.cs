
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridyDataOnly : MonoBehaviour
{
    public static TridyDataOnly Instance;

    [SerializeField]
    private Tridy tridy;

    [SerializeField]
    private Likes likes;


    public Tridy Tridy { get => tridy; set => tridy = value; }
    public Likes Likes { get => likes; set => likes = value; }

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void OnClick()
    {
        SceneViewManagers.Instance.LikesConsumer.Looks(tridy);
        SceneViewManagers.Instance.ViewManagerItem.ViewSpecificItem(tridy);
        CreateARObject.Instance.AddInformation(Tridy.estructura);
    }
}


