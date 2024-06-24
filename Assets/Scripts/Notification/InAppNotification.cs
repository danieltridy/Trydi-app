using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InAppNotification : MonoBehaviour
{

    public static InAppNotification Instance { get; private set; }

    [SerializeField]
    private GameObject buttonX;
    [SerializeField]
    private GameObject buttonOk;
    [SerializeField]
    private Image load;
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

        switch (clase.state)
        {
            case EnumNotification.ButtonOk:
                buttonX.SetActive(false);
                buttonOk.SetActive(true);
                load.gameObject.SetActive(false);
                informationNotification.text = clase.textInformation;
                informationNotification.gameObject.SetActive(true);

                break;

             case EnumNotification.Buttonx:
                buttonX.SetActive(true);
                buttonOk.SetActive(false);
                load.gameObject.SetActive(false);
                informationNotification.gameObject.SetActive(true);
                informationNotification.text = clase.textInformation;
                break;


            case EnumNotification.Load:
                buttonX.SetActive(false);
                buttonOk.SetActive(false);
                load.gameObject.SetActive(true);
                informationNotification.gameObject.SetActive(false);
                break;
        }

        InterfaceManager.Instance.ShowScreen(Show);
    }

    public void HideNotication()
    {
        InterfaceManager.Instance.HideScreen(Show);
    }



}


