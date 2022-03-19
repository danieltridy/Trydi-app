using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask interactLayer;
    private ITransformInteract transformInteract;
    private Ray ray;
    private RaycastHit hit;
    private IFocusable currentFocusable;
  


    private void Start()
    {
        transformInteract = GetComponent<ITransformInteract>();

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, interactLayer))
            {
                currentFocusable = hit.transform.parent.GetComponent<IFocusable>();
                print("CurrentFocusable Set");
            }
        }

        if (currentFocusable != null)
        {
            transformInteract.OnScale(currentFocusable);
            transformInteract.OnMove(currentFocusable, cam);
            transformInteract.OnRotate(currentFocusable, cam);
        }
    }
}
