using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewNotification : MonoBehaviour
{

    public static NewNotification Instance { get; private set; }

    [SerializeField]
    private GameObject buttonX;
    [SerializeField]
    private TMP_Text informationNotification;
    [SerializeField]
    private ElementIdentifier Show;




    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void ShowNotication(ClassnNotification clase)
    {
        buttonX.SetActive(true);
        informationNotification.text = clase.textInformation;
        informationNotification.gameObject.SetActive(true);

        InterfaceManager.Instance.ShowScreen(Show);
    }

    public void HideNotication()
    {
        InterfaceManager.Instance.HideScreen(Show);
    }



}


