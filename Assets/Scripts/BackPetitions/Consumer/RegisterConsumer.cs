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

    public void StartRegister()
    {
        StartCoroutine(RegisterPetition());
    }

    IEnumerator RegisterPetition()
    {
        var service = new RegisterServiceData(Nick.text,Email.text, pass.text);
        yield return service.SendAsync(response);
    }

    private void response(string response)
    {
        try
        {
            UserData.Instance.PlayerData = JsonConvert.DeserializeObject<PlayerData>(response);

            if (UserData.Instance.PlayerData.success)
            {
                RegisterCompleted();
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
        ClassnNotification notification = new ClassnNotification(EnumNotification.Buttonx, $"Hola {UserData.Instance.PlayerData.data.name}es hora de crear TRIDY antes de empezar te queremos contar un poco acerca de nosotros...");
        InAppNotification.Instance.ShowNotication(notification);
        OnRegisterCompleted.Invoke();
    }

}
