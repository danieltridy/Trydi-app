using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMeshEditor : MonoBehaviour
{
    IFocusable focusable;
    void Start()
    {
        SelectionManager.Instance.OnFocusableSet += Instance_OnFocusableSet;
    }

    private void Instance_OnFocusableSet(IFocusable obj)
    {
        focusable=obj;
    }

   
}
