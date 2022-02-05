using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemInteractor : MonoBehaviour
{
    public UnityEvent OnItemInteract;// Event To Interact
    public static ItemInteractor Instance = null;
    [SerializeField]
    private ItemDistancePopUp displayDistance;
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask ItemLayer;
    private Ray ray;
    private RaycastHit hit;
    IDistanceViewer distanceViewer;
    private void Start()
    {
        distanceViewer = displayDistance.GetComponent<IDistanceViewer>();
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Delay()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        // when touch Screen
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ItemLayer) && cam.isActiveAndEnabled)
            {
                if (hit.collider != null)
                {
                    Item itmeHit = hit.collider.GetComponent<Item>();
                    if (distanceViewer == null) return;
                    distanceViewer.ShowDistance(itmeHit.GetCurrentDistance());
                    OnItemInteract.Invoke();
                    print("Item Name: " + hit.collider.name);
                }
            }
        }
    }

}
