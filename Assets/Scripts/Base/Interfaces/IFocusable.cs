

using UnityEngine;

public interface IFocusable
{
  
    public Transform GetCurrentFocusedTransform();

    public GameObject GetCurrentFocusableObject();

    public Vector3 GetCurrentRGBFocusable();

    public string GetfocusableTextureName();

}
