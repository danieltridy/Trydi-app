using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorInput : GestureSettings, ITransformInteract
{

    private Vector3 deltaPos;
    private Vector3 lastPos;
    private Vector3 offset;
    float mZCoord;

    private void Reset()
    {
        Init();
    }

    public void OnMove(IFocusable focusable, Camera camera)
    {
        if (!EnableMovement)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            mZCoord = camera.WorldToScreenPoint(focusable.GetCurrentFocusedTransform().position).z;
            offset = focusable.GetCurrentFocusedTransform().position - GetInputWorldPos(camera);
        }
        else
        if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition - lastPos;
            if (deltaPos.magnitude > MovementTolerance)
                focusable.GetCurrentFocusedTransform().position = GetInputWorldPos(camera) + offset;
            lastPos = Input.mousePosition;
        }
    }


    public void OnRotate(IFocusable focusable, Camera camera)
    {
        if (!EnableRotation)
            return;

        if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition - lastPos;
            focusable.GetCurrentFocusedTransform().Rotate(camera.transform.up * -deltaPos.x * RotationSpeed, Space.World);
            focusable.GetCurrentFocusedTransform().Rotate(camera.transform.right * deltaPos.y * RotationSpeed, Space.World);
            lastPos = Input.mousePosition;
        }
    }

    public void OnScale(IFocusable focusable)
    {
        if (!EnableScale)
            return;

        ScaleValue = focusable.GetCurrentFocusedTransform().localScale.x;
        ScaleValue = Mathf.Clamp(ScaleValue + Input.GetAxis("Mouse ScrollWheel") * PinchSpeed, MinScaleValue, MaxScaleValue);
        print("ScaleValue: " + ScaleValue);
        focusable.GetCurrentFocusedTransform().localScale = Vector3.one * ScaleValue;
    }

    public override Vector3 GetInputWorldPos(Camera camera)
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return camera.ScreenToWorldPoint(mousePoint);
    }

    public override void Init()
    {
        MinScaleValue = 1;
        MaxScaleValue = 10;
        PinchSpeed = 2;
        RotationSpeed = 3;
        MovementTolerance = 3;
    }
}
