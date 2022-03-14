using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RegisterCreationConsumer : MonoBehaviour
{

    private string name, description;
    private double latitude, longitude;
    private int user_id, likes;
    [SerializeField]
    private TMP_InputField name1, description1;
    [SerializeField]
    private TridyConsumer tridyConsumer;
    [SerializeField]
    private UnityEvent registerTridy;
    [SerializeField]
    private ElementIdentifier Show;


    public void TridyStart()
    {
        name = name1.text;
        latitude = LocationProvider.Instance.GetCurrentLocation().x;
        longitude = LocationProvider.Instance.GetCurrentLocation().y;
        user_id = UserData.Instance.PlayerData.data.id;
        likes = 0;
        description = description1.text;
        StartCoroutine(TridyPeti());

    }
    IEnumerator TridyPeti()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null);
        InAppNotification.Instance.ShowNotication(notification);
        var service = new RegisterTridyData(name, latitude, longitude, user_id, likes, description);
        yield return service.SendAsync(response);

    }
    private void response(string response)
    {
        InAppNotification.Instance.HideNotication();
        try
        {
            TridyDataRegisters.Instance.TridysData = JsonConvert.DeserializeObject<TridyDataRegister>(response);
            if (TridyData.Instance.TridysData.success)
            {
                registerTridy.Invoke();
                InterfaceManager.Instance.HideScreen(Show);
                Invoke("ResetItems", 2f);
            }

        }
        catch (Exception E)
        {
            TridyErrors.Instance.Errors = JsonConvert.DeserializeObject<ErrorsData>(response);

            if (!TridyErrors.Instance.Errors.success)
            {
                ClassnNotification notification1 = new ClassnNotification(EnumNotification.ButtonOk, $"{TridyErrors.Instance.Errors.data.name[0]}");
                InAppNotification.Instance.ShowNotication(notification1);

            }
            else {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No se pudo conectar al servidor");
                InAppNotification.Instance.ShowNotication(notification);
            }
        
        }
    }

    private void ResetItems() {
        tridyConsumer.TridyStart();
    }
}
