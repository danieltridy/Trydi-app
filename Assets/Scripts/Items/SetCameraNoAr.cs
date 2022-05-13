using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCameraNoAr : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private ItemsCreator itemsCreator;
    [SerializeField]
    private TouchInput touchInput;

    private void OnEnable()
    {
        itemsCreator.EditorCam = camera;
        touchInput.Camera = camera;
        SelectionManager.Instance.cam = camera;
    }
}
