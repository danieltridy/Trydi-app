using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private GameObject currentItem;

    [SerializeField]
    private Text debug;
    public void CreateItem()
    {
       
        Vector3 cameraPoint = cam.transform.position + cam.transform.forward * frontDistance;
        cameraPoint.y = cameraPoint.y + heightOffset;
        currentItem = Instantiate(prefab, cameraPoint, Quaternion.identity);
      
    }

    private void Update()
    {
        debug.text = "Cam pos: " + cam.transform.position;
    }

    public void DestroyItem()
    {
        Destroy(currentItem);
    }



}
