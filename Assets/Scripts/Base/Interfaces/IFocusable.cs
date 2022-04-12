

using UnityEngine;

public interface IFocusable
{
  
    public Transform GetCurrentFocusedTransform();

    public Item GetCurrentFocusableReference();
}
