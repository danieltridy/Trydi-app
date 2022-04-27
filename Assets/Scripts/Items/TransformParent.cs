using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformParent : MonoBehaviour
{
   
    [SerializeField]
    private bool enableMovevent;
    [SerializeField]
    private bool enableScale;
    [SerializeField]
    private bool enableRotation;

    [Header("Pinch Scale Settings")]
    [SerializeField]
    private float minScaleValue;
    [SerializeField]
    private float maxScaleValue;
    [SerializeField]
    private float pinchSpeed;
    [HideInInspector]
    [SerializeField]
    private float scaleValue;
    [Header("Rotation Settings")]
    [SerializeField]
    private float rotationSpeed;
    [Header("Movement Settings")]
    [SerializeField]
    private float movementTolerance;

    private GameObject target;
    private Touch touch;
    private Vector3 offset;
    float mZCoord;
    private Camera camera;
    private  void Start()
    {
        target = gameObject;
        camera = Camera.main;
    }
    private void Reset()
    {
       
    }


    private void Update()
    {

       

        OnMove();
        OnRotate();
        OnScale();
    }


    private void OnMove()
    {
        if (!enableMovevent)
            return;
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                mZCoord = camera.WorldToScreenPoint(target.transform.position).z;
                offset = target.transform.position - GetInputWorldPos();
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.magnitude > movementTolerance)
                    target.transform.position = GetInputWorldPos() + offset;
            }
        }
    }

    private void OnRotate()
    {
        if (!enableRotation)
            return;

        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);
          
            if (touch.phase == TouchPhase.Moved)
            {

                target.transform.Rotate(camera.transform.up * -touch.deltaPosition.x * rotationSpeed, Space.World);
                target.transform.Rotate(camera.transform.right * touch.deltaPosition.y * rotationSpeed, Space.World);
            }

        }
    }

    private void OnScale()
    {
        if (!enableScale)
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

            scaleValue = target.transform.localScale.x;
            scaleValue = Mathf.Clamp(scaleValue + difference * pinchSpeed, minScaleValue, maxScaleValue);
            target.transform.localScale = Vector3.one * scaleValue;
        }
    }




    public  Vector3 GetInputWorldPos()
    {
        Vector3 mousePoint = touch.position;
        mousePoint.z = mZCoord;
        return camera.ScreenToWorldPoint(mousePoint);
    }
}
