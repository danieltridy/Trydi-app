using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ErrorsData
{
    public bool success;
    public string message;
    public Errors data;
}



[System.Serializable]
public class Errors
{
    public List<string> password = new List<string>(); 
    public List<string> email =new List<string>();
    public List<string> name = new List<string>();
}




