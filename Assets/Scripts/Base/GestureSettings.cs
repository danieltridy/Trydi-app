using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GestureSettings : MonoBehaviour
{
    [Header("General Settings")]
    public bool EnableMovement;
    public bool EnableScale;
    public bool EnableRotation;

    [Header("Pinch Scale Settings")]
    public float MinScaleValue;
    public float MaxScaleValue;
    public float PinchSpeed;
    [HideInInspector]
    public float ScaleValue;
    [Header("Rotation Settings")]
    public float RotationSpeed;
    [Header("Movement Settings")]
    public float MovementTolerance;

    public virtual Vector3 GetInputWorldPos(Camera camera)
    {
        return Vector3.zero;
    }

    public abstract void Init();
}
