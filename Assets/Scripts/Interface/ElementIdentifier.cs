
using DoozyUI;
using UnityEngine;

public class ElementIdentifier : MonoBehaviour
{
    public string category;
    public string nameElement;

    private void Reset()
    {
        category = GetComponent<UIElement>().elementCategory;
        nameElement = GetComponent<UIElement>().elementName;
    }
}
