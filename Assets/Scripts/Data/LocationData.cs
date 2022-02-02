
using System;

using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "LocationData")]
public class LocationData : ScriptableObject
{
   
    public List<Location> LocationController;
   

    [Serializable]
    public class Location
    {
        public string LocationName;
        public double[] LatitudeLongitude;
    }
   

}
