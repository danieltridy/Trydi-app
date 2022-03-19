

using UnityEngine;

public interface ITransformInteract
{
    public void OnMove(IFocusable focusable, Camera camera);
    public void OnRotate(IFocusable focusable, Camera camera);
    public void OnScale(IFocusable focusable);

}
