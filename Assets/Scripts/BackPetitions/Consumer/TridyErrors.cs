using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridyErrors : MonoBehaviour
{
    public static TridyErrors Instance;

    [SerializeField]
    private ErrorsData errors;

    public ErrorsData Errors { get => errors; set => errors = value; }

    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    //public void ErrorsStart()
    //{
    //    Errors.data.name[0] = "";
    //    Errors.data.email[0] = "";
    //    Errors.data.password[0] = "";


    //}


}
