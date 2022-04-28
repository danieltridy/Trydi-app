using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchInput : TridyEditor, ITransformInteract
{

    private Vector3 offset;
    float mZCoord;
    private Touch touch;
    [SerializeField]
    private ItemsCreator meshEditor;
    [SerializeField]
    private TMP_Text text;
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

    public void OnMove(IFocusable focusable)
    {
        if (!EnableMovement)
            return;
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                mZCoord = Camera.WorldToScreenPoint(focusable.GetCurrentFocusedTransform().position).z;
                offset = focusable.GetCurrentFocusedTransform().position - GetInputWorldPos();
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.magnitude > MovementTolerance)
                    focusable.GetCurrentFocusedTransform().position = GetInputWorldPos() + offset;
            }
        }
    }

    public void OnTextEnable() {
        OnTextChanged(text.text);
    }

    public void OnRotate(IFocusable focusable)
    {
        if (!EnableRotation)
            return;

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                focusable.GetCurrentFocusedTransform().Rotate(Camera.transform.up * -touch.deltaPosition.x * RotationSpeed, Space.World);
                focusable.GetCurrentFocusedTransform().Rotate(Camera.transform.right * touch.deltaPosition.y * RotationSpeed, Space.World);
            }

        }
    }

    public void OnTexture(Texture texture)
    {
        TextureDebug = texture;
        OnTextureDebug();
    }
    public void Oncolor(Color color)
    {
        ColorDebug = color;
        OnColorDebug();
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
    public override Vector3 GetInputWorldPos()
    {
        Vector3 mousePoint = touch.position;
        mousePoint.z = mZCoord;
        return Camera.ScreenToWorldPoint(mousePoint);
    }

    public override void Start()
    {
        SelectionManager.Instance.OnFocusableSet += OnFocusableSet;
    }

    private void OnFocusableSet(IFocusable obj)
    {
        Focusable = obj;
        CurrentGameObject = Focusable.GetCurrentFocusableObject();
    }

    public override void Update()
    {
        if (!Camera || Focusable == null)
            return;


        OnMove(Focusable);
        OnRotate(Focusable);
        OnScale(Focusable);
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
            EnableRotation = false;
        }
        else
        {
            EnableRotation = true;
            meshEditor.enabled = false;
            EnableScale = false;
            EnableMovement = false;
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
}
