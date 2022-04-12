using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;
    public event Action<IFocusable> OnFocusableSet;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask interactLayer;
    private ITransformInteract transformInteract;
    private Ray ray;
    private RaycastHit hit;
    private IFocusable currentFocusable;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

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
                OnFocusableSet?.Invoke(currentFocusable);
                print("CurrentFocusable Set");
            }
        }

        if (currentFocusable == null)
            return;
           // throw new Exception("currentFocusable Is Null");

        transformInteract.OnScale(currentFocusable);
        transformInteract.OnMove(currentFocusable, cam);
        transformInteract.OnRotate(currentFocusable, cam);
    }
}
