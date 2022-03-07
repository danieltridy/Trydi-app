using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridyData : MonoBehaviour
{
    public static TridyData Instance;

    [SerializeField]
    private TridysData tridysData;


    public TridysData TridysData { get => tridysData; set => tridysData = value; }

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
