using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.CheapRulerCs;
using Mapbox.Unity.Location;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    AbstractMap map;
    [SerializeField]
    private Transform target;
    
    private Vector3 currentPos;
    private Vector3 LastPosition;
    private Vector3 deltaPos;
    private double distance;
    [SerializeField]
    private float toleranceDistance;
    [SerializeField]
    int samplesToEvaluate = 20;
    int frameCount;
    private LocationProvider locationProvider;
    // Start is called before the first frame update
    void Start()
    {
        locationProvider = LocationProvider.Instance;

    }

   
   
    private void Update()
    {

        if (Evaluate())
            AnimatePlayer();
    }
    private void AnimatePlayer()
    {

        currentPos = map.GeoToWorldPosition(locationProvider.GetCurrentLocation());
        deltaPos = LastPosition - currentPos;
        distance = Vector3.Distance(currentPos, LastPosition);
       // print("Distance: " + distance);
        if (distance > toleranceDistance)
            animator.SetBool("Walk", true);
        else
            animator.SetBool("Walk", false);

        LastPosition = currentPos;
    }
    private bool Evaluate()
    {
        if(frameCount<samplesToEvaluate)
        {
            frameCount++;
            return false;
        }else
        {
            frameCount = 0;
            return true;
        }
    }


}



