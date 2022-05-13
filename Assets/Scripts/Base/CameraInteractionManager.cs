using Mapbox.Unity.Map;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CameraInteractionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent OnInterpolationStart;
    public UnityEvent OnInterpolationToTargetComplete;
    public UnityEvent OnInterpolationToOriginComplete;

    [SerializeField]
    private float SpeedMovment;
    private bool isCameraZoom;
    private bool isCenterMap;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 playerOrigin;
    private Vector3 targetOrigin;
    private Vector3 targetPos;
    private Vector3 Delta;
    private Vector2 LastPosition;
    private Vector2 CurrentPosition;

    public bool IsCenterMap { get => isCenterMap; set => isCenterMap = value; }

    void Start()
    {
        playerOrigin = transform.localPosition;
    }

    private void Update()
    {
        if (!ButtonColor.Instance.color)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //print("Click");
                    OnInterpolationStart.Invoke();
                    StopAllCoroutines();
                    LastPosition = (Input.mousePosition);
                    // First touch
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    //release
                    if (!isCameraZoom)
                        StartCoroutine(WaitForUpdatePos());
                }
                else if (Input.GetMouseButton(0))
                {
                    // drag
                    CurrentPosition = (Input.mousePosition);
                    MoveCamera();

                }
            }
        }
    }


    public void MoveCamera()
    {
        Delta = CurrentPosition - LastPosition;
        Vector3 pos = transform.localPosition + new Vector3(-Delta.x, 0, -Delta.y);
        pos.y = playerOrigin.y;
        float distance = Delta.magnitude;
        if (distance > 1.8f)
            transform.localPosition = Vector3.Lerp(transform.localPosition, pos, Time.deltaTime * SpeedMovment);

        LastPosition = CurrentPosition;

    }
    [EasyButtons.Button]
    public void LerpToTarget(Transform target)
    {
        OnInterpolationStart.Invoke();
        isCameraZoom = true;
        targetPos = new Vector3(target.position.x + offset.x, target.position.y + offset.y, target.position.z + offset.z);
        Hashtable hashtable = new Hashtable();
        hashtable.Add("position", targetPos);
        hashtable.Add("time", 1);
        hashtable.Add("oncomplete", "CompleteInterpolationToTarget");
        Hashtable hashtableRot = new Hashtable();
        hashtableRot.Add("y", (transform.parent.localEulerAngles.y)*-1);
        hashtableRot.Add("islocal", true);
        hashtableRot.Add("time", 1);
        iTween.MoveTo(gameObject, hashtable);
        iTween.RotateTo(gameObject, hashtableRot);
    }
    [EasyButtons.Button]
    public void LerpToOrigin()
    {
        OnInterpolationStart.Invoke();
        Hashtable hashtable = new Hashtable();
        hashtable.Add("islocal", true);
        hashtable.Add("position", playerOrigin);
        hashtable.Add("time", 1);
        hashtable.Add("oncomplete", "CompleteInterpolationToOrigin");

        transform.localEulerAngles = Vector3.zero;
        iTween.MoveTo(gameObject, hashtable);
    }
    public void CompleteInterpolationToTarget()
    {
        OnInterpolationToTargetComplete.Invoke();

    }
    public void CompleteInterpolationToOrigin()
    {
        if(!isCenterMap)
        {
            OnInterpolationToOriginComplete.Invoke();
        }
        isCameraZoom = false;
    }
 
    private IEnumerator WaitForUpdatePos()
    {

        yield return new WaitForSeconds(3);
        //print("Back to center");
        LerpToOrigin();
    }
}
