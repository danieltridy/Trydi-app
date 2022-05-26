using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup text;
    [SerializeField]
    private CanvasGroup meshEditor;
    [SerializeField]
    private CanvasGroup panelColor;
    [SerializeField]
    private CanvasGroup texture;
    [SerializeField]
    private GameObject textb;
    [SerializeField]
    private GameObject meshEditorb;
    [SerializeField]
    private GameObject panelColorb;
    [SerializeField]
    private GameObject textureb;
    public void ButtonsControl()
    {

        if (text.alpha == 1)
        {
            textb.SetActive(true);

        }
        else if (meshEditor.alpha == 1)
        {
            meshEditorb.SetActive(true);
        }
        else if (panelColor.alpha == 1)
        {
            panelColorb.SetActive(true);
        }
        else if (texture.alpha == 1)
        {
            textureb.SetActive(true);
        }
    }

}
