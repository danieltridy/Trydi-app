using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RegisterConsumer : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField Nick,Email, pass;

    [SerializeField]
    private UnityEvent OnRegisterCompleted;
    [SerializeField]
    private TridyConsumer tridyConsumer;
    public void StartRegister()
    {
        StartCoroutine(RegisterPetition());
    }

    IEnumerator RegisterPetition()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null);
        InAppNotification.Instance.ShowNotication(notification);
        var service = new RegisterServiceData(Nick.text,Email.text, pass.text);
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
                RegisterCompleted();
                PlayerPrefs.SetString("mail", Email.text);
                PlayerPrefs.SetString("pass", pass.text);
            }
            
        }
        catch (Exception E)
        {
            if (!UserData.Instance.PlayerData.success)
            {
                ClassnNotification notification1 = new ClassnNotification(EnumNotification.ButtonOk, "Ingresar Datos o Email ya esta en uso");
                InAppNotification.Instance.ShowNotication(notification1);
            }
            else {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No se pudo conectar al servidor");
                InAppNotification.Instance.ShowNotication(notification);
            }
           
        }
    }

    public void RegisterCompleted()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Buttonx, $"Hola {UserData.Instance.PlayerData.data.name} Bienvenido a Tridy");
        InAppNotification.Instance.ShowNotication(notification);
        OnRegisterCompleted.Invoke();
        Invoke("TridyWait", 1f);
    }
    private void TridyWait()
    {
        tridyConsumer.TridyStart();
    }
}
