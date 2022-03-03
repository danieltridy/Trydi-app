using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour
{
    public static UserData Instance;

    [SerializeField]
    private PlayerData playerData;

    public PlayerData PlayerData { get => playerData; set => playerData = value; }

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }



}
