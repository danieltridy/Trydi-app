using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAppearanceManager : MonoBehaviour
{
    [SerializeField]
    private Color colorDebug;
    [SerializeField]
    private Texture textureDebug;
    IFocusable focusable;
    Item currentItem;

    // Start is called before the first frame update
    private void Start()
    {
        SelectionManager.Instance.OnFocusableSet += OnFocusableSet;
    }

    private void OnFocusableSet(IFocusable current)
    {
        focusable = current;
        if (focusable == null)
            throw new Exception("focusable Is Null");

        currentItem = focusable.GetCurrentFocusableReference();
    }

    private bool ImplementIColorFocusableInterface()
    {
       
        if(currentItem.GetComponent<IColorFocusable>()!=null)
            return true;

        return false;
    }

    private bool ImplementIMaterialFocusableInterface()
    {
        if (currentItem.GetComponent<IMaterialFocusable>() != null)
            return true;

            return false;
    }

    public void UpdateItemColor(Color color)
    {
        if (!ImplementIColorFocusableInterface())
            return;

        currentItem.GetComponent<IColorFocusable>().OnColorChanged(color);

    }

    public void UpdateItemTexture(Texture texture)
    {
        if (!ImplementIMaterialFocusableInterface())
            return;

        currentItem.GetComponent<IMaterialFocusable>().OnTextureChanged(texture);
    }
   [EasyButtons.Button]
    public void OnColorDebug()
    {
        UpdateItemColor(colorDebug);
    }
    [EasyButtons.Button]
    public void OnTextureDebug()
    {
        UpdateItemTexture(textureDebug);
    }
}
