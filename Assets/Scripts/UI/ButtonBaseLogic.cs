using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonBaseLogic : MonoBehaviour
{
    [SerializeField]
    private UnityEvent showMenu;
    [SerializeField]
    private UnityEvent hideMenu;

    private bool menu_;
    public void BaseButton() {
        if (!menu_)
        {
            showMenu.Invoke();
            menu_ = true;
        }
        else {
            hideMenu.Invoke();
            menu_ = false;
        }

    }
}
