using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class TridyConsumer : MonoBehaviour
{
    
    [SerializeField]
    private ItemCreatorManager item;
    [SerializeField]
    private double lat, lon;

    public void Start()
    {
        Invoke("Wait",2);
    }

    private void Wait() {
        StartCoroutine(TridyPeti());

    }
    IEnumerator TridyPeti()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null);
        InAppNotification.Instance.ShowNotication(notification);
        var service = new TridyServiceData(lat, lon);
        yield return service.SendAsync(response);

    }
    private void response(string response)
    {
        InAppNotification.Instance.HideNotication();

        try
        {
            TridyData.Instance.TridysData = JsonConvert.DeserializeObject<TridysData>(response);
            if (TridyData.Instance.TridysData.success)
            {                Debug.Log($"si enbtro {TridyData.Instance.TridysData.data[0].name}");

                item.GetTridys(TridyData.Instance.TridysData);
            }
            else {
                Debug.Log($"si enbtro {TridyData.Instance.TridysData.message}");

            }
        }
        catch (Exception E)
        {
            Debug.Log(E);
            ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No se pudo conectar al servidor");
            InAppNotification.Instance.ShowNotication(notification);
        }
    }
}
