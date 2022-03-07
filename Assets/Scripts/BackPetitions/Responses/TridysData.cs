using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
[System.Serializable]
public class TridysData
{
    public bool success;
    public string message;
    public List<Tridys> data;
}
[System.Serializable]

public class Tridys
{
        public int id;
        public string name;
        public object description;
        public object estructura;
        public double latitude;
        public double longitude;
        public int likes;
        public int user_id;
        public DateTime created_at;
        public DateTime updated_at;
        public string distance;
    }

  

