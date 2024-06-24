using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool success;
    public string message;
    public Data data ;
    public List<Like> likes;

}

public class Like
{
    public int tridy_id;
}
[System.Serializable]
public class Data
{
    public int id ;
    public string name ;
    public string email ;
    public DateTime created_at ;
    public DateTime updated_at ;
}



