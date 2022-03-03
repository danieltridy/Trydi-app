using DoozyUI;
using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    public static InterfaceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            //Destroy(gameObject);
        }
    }


    public void ShowScreen(ElementIdentifier ElementIdentifier)
    {
        UINavigation.ShowUiElement(ElementIdentifier.nameElement, ElementIdentifier.category, false);
    }
    public void HideScreen(ElementIdentifier elementIdentifier)
    {
        UINavigation.HideUiElement(elementIdentifier.nameElement, elementIdentifier.category, false);
    }
}
