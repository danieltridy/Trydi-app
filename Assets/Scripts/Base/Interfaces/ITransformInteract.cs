

using UnityEngine;

public interface ITransformInteract
{
    public void OnMove(IFocusable focusable);
    public void OnRotate(IFocusable focusable);
    public void OnScale(IFocusable focusable);

}
