using UnityEngine;
using System.Collections;

public class example : MonoBehaviour {

    private bool isPaint = false;
    private GameObject go;
    private Material mat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (isPaint)
        {
            mat.color = ColorPaletteController.Instance.color;
        }
    }

    void OnMouseDown()
    {
        if (isPaint)
        {
            StopPaint();
        }
        else
        {
            StartPaint();
        }
    }

    private void StartPaint()
    {
        if (ButtonColor.Instance.color) { 
        isPaint = true;
    }
    }

    private void StopPaint()
    {
        Destroy(go);
        isPaint = false;
    }
}
