using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AlertMessage : MonoBehaviour
{
    [SerializeField]
    private GameObject images;
    [SerializeField]
    private GameObject Message;
    [SerializeField]
    private TMP_Text informationNotification;
    [SerializeField]
    private TMP_Text informationNotification1;
    [SerializeField]
    private ElementIdentifier Show;
    public static AlertMessage Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
        }
        else
            Destroy(gameObject);
    }

    public void ShowNotication(ClassAlert clase)
    {

        switch (clase.state)
        {
            case EnumAlert.message:
      
                informationNotification.text = clase.textInformation;
                informationNotification.gameObject.SetActive(true);
                images.SetActive(false);
                Message.SetActive(true);
                Invoke("HideNotication",3);
                break;

            case EnumAlert.messageIm:

                informationNotification1.gameObject.SetActive(true);
                informationNotification1.text = clase.textInformation;
                images.SetActive(true);
                Message.SetActive(false);
                Invoke("HideNotication",3);
                break;
        }

        InterfaceManager.Instance.ShowScreen(Show);
    }

    public void HideNotication()
    {
        InterfaceManager.Instance.HideScreen(Show);
    }


}
