using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;
    public event Action<IFocusable> OnFocusableSet;
    [SerializeField]
    public Camera cam;
    [SerializeField]
    private LayerMask interactLayer;
    private Ray ray;
    private RaycastHit hit;
    private IFocusable currentFocusable;

    public IFocusable CurrentFocusable { get => currentFocusable; set => currentFocusable = value; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

   
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 100, interactLayer))
            {
                currentFocusable = hit.transform.parent.GetComponent<IFocusable>();
                OnFocusableSet?.Invoke(currentFocusable);
                print("CurrentFocusable Set: "+currentFocusable.GetCurrentFocusedTransform().name);
            }
        }
    }
}
