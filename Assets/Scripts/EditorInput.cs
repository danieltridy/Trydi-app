using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorInput : TridyEditor, ITransformInteract
{
    private Vector3 currentPos;
    private Vector3 deltaPos;
    private Vector3 lastPos;
    private Vector3 offset;
    float mZCoord;
    [SerializeField]
    private ItemsCreator meshEditor;
    [SerializeField]
    private TouchInput touch;

    
    private void Start()
    {
        SelectionManager.Instance.OnFocusableSet += OnFocusableSet;
       CurrentGameObject =null;
    }

    private void OnFocusableSet(IFocusable obj)
    {
        Focusable = obj;
        CurrentGameObject = Focusable.GetCurrentFocusableObject();
        mZCoord = Camera.WorldToScreenPoint(CurrentGameObject.transform.position).z;
    }

    private void Reset()
    {
        Init();
    }

    private void Update()
    {
        if (!Camera || CurrentGameObject == null)
            return;


        OnMove();
        OnRotate();
        OnScale();
    }

    public void Oncolor(Color color)
    {
        ColorDebug = color;
        OnColorDebug();
    }


    public void OnTexture(Texture texture)
    {
        TextureDebug = texture;
        OnTextureDebug();
    }

    public void OnMove()
    {
        if (!EnableMovement)
            return;

        if (Input.GetMouseButtonDown(0))
            lastPos = Input.mousePosition;
        else
        if (Input.GetMouseButton(0))
        {

            currentPos = Input.mousePosition;
            deltaPos = currentPos - lastPos;


            if (deltaPos.magnitude > MovementTolerance)
                CurrentGameObject.transform.position = GetInputWorldPos() ;

            lastPos = currentPos;
        }
        else if (Input.GetMouseButtonUp(0))
            CurrentGameObject = null;
    }


    public void OnRotate()
    {
        if (!EnableRotation)
            return;

        if (Input.GetMouseButton(0))
        {
            deltaPos = Input.mousePosition - lastPos;
            CurrentGameObject.transform.Rotate(Camera.transform.up * -deltaPos.x * RotationSpeed, Space.World);
            CurrentGameObject.transform.Rotate(Camera.transform.right * deltaPos.y * RotationSpeed, Space.World);
            lastPos = Input.mousePosition;
        }
    }

    public void OnScale()
    {
        if (!EnableScale)
            return;

        ScaleValue = CurrentGameObject.transform.localScale.x;
        ScaleValue = Mathf.Clamp(ScaleValue + Input.GetAxis("Mouse ScrollWheel") * PinchSpeed, MinScaleValue, MaxScaleValue);
        CurrentGameObject.transform.localScale = Vector3.one * ScaleValue;
    }

    public override Vector3 GetInputWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.ScreenToWorldPoint(mousePoint);
    }


    public void ScaleEnable()
    {
        if (EnableScale)
        {
            meshEditor.enabled = true;
            EnableScale = false;
        }
        else
        {
            EnableScale = true;
            meshEditor.enabled = false;
            EnableRotation = false;
            EnableMovement = false;
        }
    }

    public void RotateEnable()
    {
        if (EnableRotation)
        {
            meshEditor.enabled = true;
            EnableMovement = false;
        }
        else
        {
            EnableRotation = true;
            meshEditor.enabled = false;
            touch.EnableScale = false;
            touch.EnableMovement = false;
        }
    }
    public void MovedEnable()
    {
        if (EnableMovement)
        {
            meshEditor.enabled = true;
            EnableMovement = false;
        }
        else
        {
            EnableMovement = true;
            meshEditor.enabled = false;
            EnableScale = false;
            EnableRotation = false;
        }
    }

    public void ResetItem()
    {
        EnableMovement = false;
        EnableRotation = false;
        EnableScale = false;
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
   
