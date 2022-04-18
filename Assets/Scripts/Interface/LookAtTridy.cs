using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTridy : MonoBehaviour
{
    [SerializeField]
    private GameObject tridy;


    private void Update()
    {
        transform.LookAt(tridy.transform);
    }

}
