using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeTridyData : MonoBehaviour
{
    public static MeTridyData Instance;

    [SerializeField]
    private MeTridys tridysData;


    public MeTridys TridysData { get => tridysData; set => tridysData = value; }

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
