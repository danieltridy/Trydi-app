using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemDistancePopUp : MonoBehaviour,IDistanceViewer
{
    public UnityEvent OnEnableAR, OnDisableAR;
    [SerializeField]
    private TMP_Text distanceTex;
    [SerializeField]
    private double distanceToAREnable;


    private void Start()
    {
        OnDisableAR.Invoke();
    }

    public void ShowDistance(double Distance)
    {
        distanceTex.gameObject.SetActive(true);
        distanceTex.text = "Distancia Actual: " + Distance.ToString("F2") +" Metros";
        if (Distance <= distanceToAREnable)
            OnEnableAR.Invoke();
        else
            OnDisableAR.Invoke();

    }

    private void ExitDistance() {
        distanceTex.gameObject.SetActive(false);
    }


}
