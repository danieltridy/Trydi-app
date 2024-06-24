using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalDireccionFromFace : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction;

    public Vector3 GetDirection()
    {
        return direction;
    }
}
