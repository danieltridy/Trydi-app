using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LoginConsumer : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField Email, pass;
    [SerializeField]
    private TMP_Text WelcomeTxt;
    [SerializeField]
    private UnityEvent OnLoginCompleted;
    private string mail, pass1;
    [SerializeField]
    private TridyConsumer tridyConsumer;
    [SerializeField]
    private GameObject noTocuh;
    [EasyButtons.Button]
    public void StartLogin()
    {
        if (Email.text == "" || pass.text == "")
        {
            ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"Todos los campos son obligatorios");
            NewNotification.Instance.ShowNotication(notification);
        }
        else
        {
            mail = Email.text;
            pass1 = pass.text;
            StartCoroutine(LoginPetition());
        }

    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("mail"))
        {
            noTocuh.SetActive(true);
            mail = PlayerPrefs.GetString("mail");
            pass1 = PlayerPrefs.GetString("pass");
            StartCoroutine(LoginPetition());

        }

    }
    IEnumerator LoginPetition()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null);
        InAppNotification.Instance.ShowNotication(notification);
        var service = new LoginServiceData(mail, pass1);
        yield return service.SendAsync(response);

    }

    private void response(string response)
    {
        InAppNotification.Instance.HideNotication();


        UserData.Instance.PlayerData = JsonConvert.DeserializeObject<PlayerData>(response);
        if (UserData.Instance.PlayerData.message == "Login exitoso")
        {
            LoginCompleted();
            PlayerPrefs.SetString("mail", mail);
            PlayerPrefs.SetString("pass", pass1);
            ItemsCreator.Instance.Init();
            noTocuh.SetActive(false);
        }

        //else
        //{
        //        ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"{UserData.Instance.PlayerData.message}");
        //        NewNotification.Instance.ShowNotication(notification);
        //}
        else
        {
            TridyErrors.Instance.Errors = JsonConvert.DeserializeObject<ErrorsData>(response);
            VerifyNull();
            if (!TridyErrors.Instance.Errors.success)
            {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"Datos Incorrectos");
                NewNotification.Instance.ShowNotication(notification);
            }

            else
            {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No se pudo conectar al servidor");
                InAppNotification.Instance.ShowNotication(notification);
            }
        }


    }

    public void LoginCompleted()
    {
        OnLoginCompleted.Invoke();
        ClassAlert alertMessage = new ClassAlert(EnumAlert.message, $"Hola un gusto verte de nuevo {UserData.Instance.PlayerData.data.name}");
        AlertMessage.Instance.ShowNotication(alertMessage);
        Invoke("TridyWait", 1f);

    }

    private void VerifyNull()
    {
    }

    private void TridyWait()
    {
        tridyConsumer.TridyStart();
    }
}
