using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
[System.Serializable]
public class TridyDataRegister
{
    public bool success;
    public string message;
    public  Tridy data;
    public string name;
}


[System.Serializable]
public class Likes
{
    public bool success;
}


[System.Serializable]
public class Tridy
{
    public int id;
    public string name;
    public string name_user;
    public string description;
    public string estructura;
    public double latitude;
    public double longitude;
    public int likes;
    public int user_id;
    public DateTime created_at;
    public DateTime updated_at;
    public string distance;
}



