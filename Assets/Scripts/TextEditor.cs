using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextEditor : MonoBehaviour
{
    public static TextEditor Instance = null;
    public event Action OnTextSelected;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        SelectionManager.Instance.OnFocusableSet += Instance_OnFocusableSet;
    }

    private void Instance_OnFocusableSet(IFocusable obj)
    {
        if (obj.GetFocusableType() == ObjectType.Text)
            OnTextSelected?.Invoke();
       
    }

}
