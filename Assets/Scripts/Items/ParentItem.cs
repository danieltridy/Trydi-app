using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentItem : Item
{
    public override GameObject GetCurrentFocusableObject()
    {
        return gameObject;
    }

    public override Transform GetCurrentFocusedTransform()
    {
        return transform;
    }

    public override Vector3 GetCurrentRGBFocusable()
    {
        return Vector3.zero;
    }

    public override string GetfocusableTextureName()
    {
        return "";
    }

    public override void Init()
    {
        
    }

   
}
