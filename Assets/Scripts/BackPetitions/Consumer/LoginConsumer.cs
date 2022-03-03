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
    [EasyButtons.Button]
    public void StartLogin()
    {
        StartCoroutine(LoginPetition());
    }

    IEnumerator LoginPetition()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null);
        InAppNotification.Instance.ShowNotication(notification);
        var service = new LoginServiceData(Email.text,pass.text);
        yield return service.SendAsync(response);

    }

    private void response(string response)
    {
        InAppNotification.Instance.HideNotication();

        try
        {
            UserData.Instance.PlayerData = JsonConvert.DeserializeObject<PlayerData>(response);
            if (UserData.Instance.PlayerData.success)
            {
                LoginCompleted();
            }
          
        }
        catch (Exception E)
        {
            if (!UserData.Instance.PlayerData.success)
            {
                ClassnNotification notification1 = new ClassnNotification(EnumNotification.ButtonOk, "Datos Incorrectos");
                InAppNotification.Instance.ShowNotication(notification1);
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
    }

}
