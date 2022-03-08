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

    private string name;
    private double latitude, longitude;
    private int user_id, likes;
    [SerializeField]
    private TMP_InputField name1;
    [SerializeField]
    private TridyConsumer tridyConsumer;
    [SerializeField]
    private UnityEvent registerTridy;
    [SerializeField]
    private Text text;

    private void Update1()
    {
        text.text = $" player lat : {TridyDataRegisters.Instance.TridysData.data.latitude} y lon: {TridyDataRegisters.Instance.TridysData.data.longitude}";

    }
    public void TridyStart()
    {
        name = name1.text;
        latitude = LocationProvider.Instance.GetCurrentLocation().x;
        longitude = LocationProvider.Instance.GetCurrentLocation().y;
        user_id = UserData.Instance.PlayerData.data.id;
        likes = 0;
        StartCoroutine(TridyPeti());

    }
    IEnumerator TridyPeti()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null);
        InAppNotification.Instance.ShowNotication(notification);
        var service = new RegisterTridyData(name, latitude, longitude, user_id, likes);
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
                tridyConsumer.TridyStart();
                registerTridy.Invoke();
                Update1();
             
            }
          
        }
        catch (Exception E)
        {
            if (!TridyData.Instance.TridysData.success)
            {
                ClassnNotification notification1 = new ClassnNotification(EnumNotification.ButtonOk, $"No tiene nombre o ya esta en uso");
                InAppNotification.Instance.ShowNotication(notification1);

            }
            else {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No se pudo conectar al servidor");
                InAppNotification.Instance.ShowNotication(notification);
            }
        
        }
    }
}
