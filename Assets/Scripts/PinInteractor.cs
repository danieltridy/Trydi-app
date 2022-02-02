using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinInteractor : MonoBehaviour
{
    public UnityEvent PinARInteract;// Event To Interact
    public UnityEvent Pin3DInteract;// Event To Interact bORRAR DESPUES
    public static PinInteractor Instance = null;
    [SerializeField]
    private Camera camAR;
    [SerializeField]
    private Camera CamWorld;
    [SerializeField]
    private LayerMask layer3dInteract, layerARInteract; // Create a Layer
    [SerializeField]
    private LayerMask layerUI; // Create a Layer
    
    private RaycastHit hit;
    Ray ray;


    private void Start()
    {
        layerUI = LayerMask.NameToLayer("UI");
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        // when touch Screen
        {
            ray = camAR.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerARInteract) && camAR.isActiveAndEnabled)
            {
                if (hit.collider != null)
                {
                    print("Pin Name: " + hit.collider.name);
                    //PinAR pinAR = hit.collider.GetComponent<PinAR>();
                    //if (pinAR)
                    //{
                    //    PinARInteract.Invoke();
                    //    pinAR.InteractStart();
                    //}

                    Handheld.Vibrate();

                }
            }

            ray = CamWorld.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer3dInteract) && CamWorld.isActiveAndEnabled)
            {
                if (hit.collider != null)
                {
                    //print("Pin Name: " + hit.collider.name);
                    //Pin3D pin3D = hit.collider.GetComponent<Pin3D>();

                    //if (pin3D)
                    //{
                    //    cameraInteractionManager.LerpToTarget(hit.collider.transform);
                    //    //Pin3DInteract.Invoke();
                    //    pin3D.InteractStart();
                    //}
                }
            }
        }
    }
}
