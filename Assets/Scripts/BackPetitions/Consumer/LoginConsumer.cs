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
    [EasyButtons.Button]
    public void StartLogin()
    {
        if (Email.text == "" || pass.text == "")
        {
            ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"Todos los campos son obligatorios");
            NewNotification.Instance.ShowNotication(notification);
        }
        else {
            mail = Email.text;
            pass1 = pass.text;
            StartCoroutine(LoginPetition());
        }
        
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("mail"))
        {
            mail = PlayerPrefs.GetString("mail");
            pass1 = PlayerPrefs.GetString("pass");
            StartCoroutine(LoginPetition());
        }

    }
    IEnumerator LoginPetition()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null);
        InAppNotification.Instance.ShowNotication(notification);
        var service = new LoginServiceData(mail,pass1);
        yield return service.SendAsync(response);

    }

    private void response(string response)
    {
        InAppNotification.Instance.HideNotication();

        try
        {
            UserData.Instance.PlayerData = JsonConvert.DeserializeObject<PlayerData>(response);
            if (UserData.Instance.PlayerData.message == "Login exitoso")
            {
                LoginCompleted();
                PlayerPrefs.SetString("mail", mail);
                PlayerPrefs.SetString("pass", pass1);

            }


            //else
            //{
            //    ClassnNotification notification1 = new ClassnNotification(EnumNotification.ButtonOk, "Contraseña Incorrecta");
            //    InAppNotification.Instance.ShowNotication(notification1);
            //}
            else
            {
                    ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"{UserData.Instance.PlayerData.message}");
                    NewNotification.Instance.ShowNotication(notification);
            }
        }
         
        catch (Exception E)
        {

            TridyErrors.Instance.Errors = JsonConvert.DeserializeObject<ErrorsData>(response);
            VerifyNull();
            if (!TridyErrors.Instance.Errors.success) {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"{TridyErrors.Instance.Errors.data.email[0]}{TridyErrors.Instance.Errors.data.password[0]}");
                NewNotification.Instance.ShowNotication(notification);
            }

            else {
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
        Invoke("TridyWait",1f);

    }

    private void VerifyNull()
    {

        if (TridyErrors.Instance.Errors.data.email.Count == 0)
        {
            TridyErrors.Instance.Errors.data.email.Add("");
        }
        if (TridyErrors.Instance.Errors.data.password.Count == 0)
        {
            TridyErrors.Instance.Errors.data.password.Add("");
        }
    }

    private void TridyWait() {
        tridyConsumer.TridyStart();
    }
}
