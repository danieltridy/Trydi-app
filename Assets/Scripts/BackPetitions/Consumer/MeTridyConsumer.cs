using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class MeTridyConsumer : MonoBehaviour
{
   
    [SerializeField]
    private int id_user;
    [SerializeField]
    private UnityEvent lookMe;
    public void TridyStart() {

        id_user = UserData.Instance.PlayerData.data.id;
        StartCoroutine(TridyPeti());
    }
    IEnumerator TridyPeti()
    {
        var service = new MeTridyServiceData(id_user);
        yield return service.SendAsync(response);
    }
    private void response(string response)
    {
        try
        {
            //TridyData.Instance.TridysData.data.Clear();
            MeTridyData.Instance.TridysData = JsonConvert.DeserializeObject<MeTridys>(response);
            if (MeTridyData.Instance.TridysData.success)
            {
                lookMe.Invoke();
            }
            else {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No Tienes Tridys");
                InAppNotification.Instance.ShowNotication(notification);
            }
        }
        catch (Exception E)
        {
            ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No se pudo conectar al servidor");
            InAppNotification.Instance.ShowNotication(notification);
        }
    }
}
