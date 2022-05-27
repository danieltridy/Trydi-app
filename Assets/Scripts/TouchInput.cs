using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchInput : TridyEditor, ITransformInteract
{

    private Vector3 offset;
    private Vector3 lastPos;
    float mZCoord;
    private Touch touch;
    [SerializeField]
    private ItemsCreator meshEditor;
    [SerializeField]
    private TMP_Text text;
    private Vector3 currentPos;
    private Vector3 deltaPos;



     private void Start()
    {
        SelectionManager.Instance.OnFocusableSet += OnFocusableSet;
        CurrentGameObject = null;
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
    public override void Init()
    {
        MinScaleValue = 1;
        MaxScaleValue = 10;
        PinchSpeed = 0.001f;
        RotationSpeed = 3;
        MovementTolerance = 3;
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
                CurrentGameObject.transform.position = GetInputWorldPos();

            lastPos = currentPos;
        }
        else if (Input.GetMouseButtonUp(0))
            CurrentGameObject = null;
    }

    public void OnTextEnable()
    {
        OnTextChanged(text.text);
    }

    public void OnRotate()
    {
        if (!EnableRotation)
            return;

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                CurrentGameObject.transform.Rotate(Camera.transform.up * -touch.deltaPosition.x * RotationSpeed, Space.World);
                CurrentGameObject.transform.Rotate(Camera.transform.right * touch.deltaPosition.y * RotationSpeed, Space.World);
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

    public void OnScale()
    {
        if (!EnableScale)
            return;

        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;

            ScaleValue = CurrentGameObject.transform.localScale.x;
            ScaleValue = Mathf.Clamp(ScaleValue + difference * PinchSpeed, MinScaleValue, MaxScaleValue);
            CurrentGameObject.transform.localScale = Vector3.one * ScaleValue;

        }
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
