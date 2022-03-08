using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridyDataRegisters : MonoBehaviour
{
    public static TridyDataRegisters Instance;
    [SerializeField]
    private TridyDataRegister tridysData;

    public TridyDataRegister TridysData { get => tridysData; set => tridysData = value; }


    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

