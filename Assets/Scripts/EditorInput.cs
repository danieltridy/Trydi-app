using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorInput : TridyEditor, ITransformInteract
{

    private Vector3 deltaPos;
    private Vector3 lastPos;
    private Vector3 offset;
    float mZCoord;


    public override void Start()
    {
        SelectionManager.Instance.OnFocusableSet += OnFocusableSet;
    }

    private void OnFocusableSet(IFocusable obj)
    {
        Focusable=obj;
        CurrentGameObject = Focusable.GetCurrentFocusableObject();
    }
    
    private void Reset()
    {
        Init();
    }

    public override void Update()
    {
        if (!Camera || Focusable == null)
            return;


        OnMove(Focusable);
        OnRotate(Focusable);
        OnScale(Focusable);



    }

    public void OnMove(IFocusable focusable)
    {
        if (!EnableMovement)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            mZCoord = Camera.WorldToScreenPoint(focusable.GetCurrentFocusedTransform().position).z;
            offset = focusable.GetCurrentFocusedTransform().position - GetInputWorldPos();
        }
        else
        if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition - lastPos;
            if (deltaPos.magnitude > MovementTolerance)
                focusable.GetCurrentFocusedTransform().position = GetInputWorldPos() + offset;
            lastPos = Input.mousePosition;
        }
    }


    public void OnRotate(IFocusable focusable )
    {
        if (!EnableRotation)
            return;

        if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition - lastPos;
            focusable.GetCurrentFocusedTransform().Rotate(Camera.transform.up * -deltaPos.x * RotationSpeed, Space.World);
            focusable.GetCurrentFocusedTransform().Rotate(Camera.transform.right * deltaPos.y * RotationSpeed, Space.World);
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

    public override Vector3 GetInputWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.ScreenToWorldPoint(mousePoint);
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
