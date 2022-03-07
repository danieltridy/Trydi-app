using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SpawnARItem : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private float frontDistance;
    [SerializeField]
    private float heightOffset;
    [SerializeField]
    private UnityEvent hide;

    private GameObject currentItem;
    public void CreateItem()
    {
        Vector3 cameraPoint = cam.transform.position + cam.transform.forward * frontDistance;
        cameraPoint.y = cameraPoint.y + heightOffset;
        currentItem = Instantiate(prefab, cameraPoint, Quaternion.identity);
        hide.Invoke();
    }

    public void DestroyItem()
    {
        Destroy(currentItem);
    }



}
