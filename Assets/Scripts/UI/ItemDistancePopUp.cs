using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemDistancePopUp : MonoBehaviour,IDistanceViewer
{
    public UnityEvent OnEnableAR, OnDisableAR;
    [SerializeField]
    private Text distanceTex;
    [SerializeField]
    private double distanceToAREnable;


    private void Start()
    {
        OnDisableAR.Invoke();
    }

    public void ShowDistance(double Distance)
    {
        distanceTex.text = "Distancia Actual: " + Distance.ToString("F2") +" Metros";
        if (Distance <= distanceToAREnable)
            OnEnableAR.Invoke();
        else
            OnDisableAR.Invoke();

    }

  
}
