using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TouchInput : TridyEditor, ITransformInteract
{

    private Vector3 offset;
    private Vector3 lastPosMouse = new Vector3();
    float mZCoord;
    private Touch touch;
    [SerializeField]
    private ItemsCreator meshEditor;
    [SerializeField]
    private TMP_Text text;
    private Vector3 currentPos;
    private Vector3 deltaPos;

    Vector3 operation;
    [SerializeField]
    private LayerMask layerMask;
    private RaycastHit hit;


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
        OnScaleFace();
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
            lastPosMouse = Input.mousePosition;

        else
        if (Input.GetMouseButton(0))
        {

            currentPos = Input.mousePosition;
            deltaPos = currentPos - lastPosMouse;


            if (deltaPos.magnitude > MovementTolerance)
                CurrentGameObject.transform.position = GetInputWorldPos();

            lastPosMouse = currentPos;
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
    public void OnScaleFace()
    {
        if (!EnableScaleFace)
            return;

        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        GameObject current = null;
        if (Input.GetMouseButtonDown(0))
        {
            lastPosMouse = Input.mousePosition;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, layerMask))
            {
                if (!current)
                    current = hit.transform.gameObject;

                print(current.name);
                if (current.GetComponent<LocalDireccionFromFace>())
                {
                    SelectionManager.Instance.enabled = false;
                    operation = current.GetComponent<LocalDireccionFromFace>().GetDirection();
                }
            }
        }


        else
       if (Input.GetMouseButton(0))
        {

            currentPos = Input.mousePosition;
            deltaPos = currentPos - lastPosMouse;

            var v = (Vector3.Scale(operation, deltaPos)) * Mathf.Clamp(deltaPos.magnitude, 0.00001f, 0.002f);
            v.z = operation.z != 0 ? 0.1f : 0f;
            v.z = v.z * Mathf.Clamp(deltaPos.magnitude, 0.01f, 0.2f);
            v.z = currentPos.x > lastPosMouse.x ? v.z : v.z * -1;
            CurrentGameObject.transform.localScale += v;
            //CurrentGameObject.transform.position = GetInputWorldPos();

            lastPosMouse = currentPos;
        }
        else if (Input.GetMouseButtonUp(0))
            SelectionManager.Instance.enabled = true;
    }
    public override Vector3 GetInputWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mZCoord;
        return Camera.ScreenToWorldPoint(mousePoint);
    }

    public void ScaleEnableAll()
    {
        EnableScale = true;
        meshEditor.enabled = false;
        EnableRotation = false;
        EnableMovement = false;
        EnableScaleFace = false;
    }
    public void ScaleEnable()
    {
        if (EnableScale)
        {
            EnableScale = false;
        }
        else
        {
            EnableScale = true;
            meshEditor.enabled = false;
            EnableRotation = false;
            EnableMovement = false;
            EnableScaleFace = false;
        }
    }
    public void ScaleFaceEnable()
    {
        if (EnableScaleFace)
        {
            EnableScaleFace = false;
        }
        else
        {
            EnableScaleFace = true;
            meshEditor.enabled = false;
            EnableRotation = false;
            EnableMovement = false;
            EnableScale = false;
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
            EnableScaleFace = false;

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
            EnableScaleFace = false;

        }
    }

    public void ResetItem()
    {
        EnableMovement = false;
        EnableRotation = false;
        EnableScale = false;
        EnableScaleFace = false;
    }
}
