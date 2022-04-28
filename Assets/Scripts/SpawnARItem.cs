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
    [SerializeField]
    private Transform init;
    [SerializeField]
    private TextItem text;

    private GameObject currentItem;
    public void CreateItem()
    {
        Vector3 cameraPoint = cam.transform.position + cam.transform.forward * frontDistance;
        cameraPoint.y = cameraPoint.y + heightOffset;
        currentItem = Instantiate(prefab, cameraPoint,new Quaternion(Quaternion.identity.x, Quaternion.identity.y +45, Quaternion.identity.z, Quaternion.identity.w));
        currentItem.transform.parent = init;
        TextItem newText = Instantiate(text);
        newText.transform.parent = init;
        init.gameObject.SetActive(true);
        hide.Invoke();
    }

    public void DestroyItem()
    {
        Destroy(currentItem);
    }



}
