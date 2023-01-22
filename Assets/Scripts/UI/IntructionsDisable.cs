using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntructionsDisable : MonoBehaviour
{
    public void OnEnable()
    {
        Invoke("DisableObject",3);
    }
    private void DisableObject() {
        transform.gameObject.SetActive(false);
    }
}
