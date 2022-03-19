using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : GestureSettings, ITransformInteract
{

    private Vector3 offset;
    float mZCoord;
    private Touch touch;

    private void Reset()
    {
        Init();
    }
    public override void Init()
    {
        MinScaleValue = 1;
        MaxScaleValue = 10;
        PinchSpeed = 0.001f;
        RotationSpeed = 3;
        MovementTolerance = 3;
    }

    public void OnMove(IFocusable focusable, Camera camera)
    {
        if (!EnableMovement)
            return;
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                mZCoord = camera.WorldToScreenPoint(focusable.GetCurrentFocusedTransform().position).z;
                offset = focusable.GetCurrentFocusedTransform().position - GetInputWorldPos(camera);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.magnitude > MovementTolerance)
                    focusable.GetCurrentFocusedTransform().position = GetInputWorldPos(camera) + offset;
            }
        }
    }

    public void OnRotate(IFocusable focusable, Camera camera)
    {
        if (!EnableRotation)
            return;

        if (Input.touchCount == 1)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                focusable.GetCurrentFocusedTransform().Rotate(camera.transform.up * -touch.deltaPosition.x * RotationSpeed, Space.World);
                focusable.GetCurrentFocusedTransform().Rotate(camera.transform.right * touch.deltaPosition.y * RotationSpeed, Space.World);
            }
        }
    }

    public void OnScale(IFocusable focusable)
    {
        if (!EnableScale)
            return;

        if(Input.touchCount==2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;

            ScaleValue = focusable.GetCurrentFocusedTransform().localScale.x;
            ScaleValue = Mathf.Clamp(ScaleValue + difference * PinchSpeed, MinScaleValue, MaxScaleValue);
            focusable.GetCurrentFocusedTransform().localScale = Vector3.one * ScaleValue;

        }
    }
    public override Vector3 GetInputWorldPos(Camera camera)
    {
        Vector3 mousePoint = touch.position;
        mousePoint.z = mZCoord;
        return camera.ScreenToWorldPoint(mousePoint);
    }

}
