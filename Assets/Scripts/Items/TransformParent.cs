using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformParent : Item
{


    //[SerializeField]
    //private bool enableScale;


    //[Header("Pinch Scale Settings")]
    //[SerializeField]
    //private float minScaleValue;
    //[SerializeField]
    //private float maxScaleValue;
    //[SerializeField]
    //private float pinchSpeed;
    //[HideInInspector]
    //[SerializeField]
    //private float scaleValue;


    //private GameObject target;
    //private Touch touch;
    //private Vector3 offset;
    //float mZCoord;
    //private Camera camera;
    //private  void Start()
    //{
    //    //target = gameObject;
    //    //camera = Camera.main;
    //}
    public override void Start()
    {
        base.Start();

    }


    private void Reset()
    {
       
    }


    //private void Update()
    //{
    //    OnScale();
    //}


    

    //private void OnScale()
    //{
    //    if (!enableScale)
    //        return;

    //    if (Input.touchCount == 2)
    //    {
    //        Touch touchZero = Input.GetTouch(0);
    //        Touch touchOne = Input.GetTouch(1);

    //        Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
    //        Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

    //        float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
    //        float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
    //        float difference = currentMagnitude - prevMagnitude;

    //        scaleValue = target.transform.localScale.x;
    //        scaleValue = Mathf.Clamp(scaleValue + difference * pinchSpeed, minScaleValue, maxScaleValue);
    //        target.transform.localScale = Vector3.one * scaleValue;
    //    }
    //}




    //public  Vector3 GetInputWorldPos()
    //{
    //    Vector3 mousePoint = touch.position;
    //    mousePoint.z = mZCoord;
    //    return GetComponent<Camera>().ScreenToWorldPoint(mousePoint);
    //}

    public override void Init()
    {
       
    }

    public override Transform GetCurrentFocusedTransform()
    {
        return transform;
    }

    public override GameObject GetCurrentFocusableObject()
    {
        return gameObject;
    }

    public override Vector3 GetCurrentRGBFocusable()
    {
        return Vector3.zero;
    }

    public override string GetfocusableTextureName()
    {
  
        return "";

    }

    public override ObjectType GetFocusableType()
    {
        return ObjectType.ParentContent;
    }

    public override string GetFocusableTextValue()
    {
       return "";
    }

    public override string GetFocusableFontName()
    {
        return "";
    }

    public void SelectParent()
    {
        SelectionManager.Instance.SetFocusable(this);

    }

    public void UnSelectParent()
    {
        SelectionManager.Instance.SetFocusable(null);
    }
}
