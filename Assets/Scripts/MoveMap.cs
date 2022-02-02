using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMap : MonoBehaviour
{
    
    [SerializeField]
    private Camera viewCam;
    private Vector3 targetPos;
    private Vector3 delta;
    private Vector3 origin;
    private bool canDrag;
    // Start is called before the first frame update
    void Start()
    {
       
    }
   
    private void Update()
    {
        if(Input.touchCount == 1)
        {
            targetPos = Input.GetTouch(0).position;
            targetPos.z = viewCam.transform.localPosition.y;
            delta = viewCam.ScreenToWorldPoint(targetPos) - viewCam.transform.localPosition;
            if (!canDrag)
            {
                canDrag = true;
                origin = viewCam.ScreenToWorldPoint(targetPos);
            }
            transform.localPosition = (origin - delta);
          

        }else
        {
            canDrag = false;
        }
    }
}
