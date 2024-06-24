
using System;

using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "LocationData")]
public class LocationData : ScriptableObject
{
   
    public List<LocationInfo> LocationController;
   

    
   

}
[Serializable]
public class LocationInfo
{
    public string LocationName;
    public double[] LatitudeLongitude;
}