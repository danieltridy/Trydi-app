using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColor : MonoBehaviour
{
    public static ButtonColor Instance { get; private set; }

    public bool color;
    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void ToolColor() {
        if (!color)
        {
            color = true;
        }
        else {
            color = false;
        }
    }
}
