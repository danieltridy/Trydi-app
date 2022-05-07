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
    [SerializeField]
    private List<MTridys> listLocalItem = new List<MTridys>();
    public void TridyStart()
    {

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
            listLocalItem.Clear();
            foreach (var s in MeTridyData.Instance.TridysData.data)
            {
                if (s.local)
                {
                    listLocalItem.Add(s);
                }
            }
            MeTridyData.Instance.TridysData.data.Clear();
            if (JsonConvert.DeserializeObject<MeTridys>(response).success) {
                MeTridyData.Instance.TridysData = JsonConvert.DeserializeObject<MeTridys>(response);
            }
            if (MeTridyData.Instance.TridysData.success || listLocalItem.Count > 0)
            {
                if (listLocalItem.Count > 0) { 
                foreach (var s in listLocalItem)
                {
                    MeTridyData.Instance.TridysData.data.Add(s);
                }
                }
                lookMe.Invoke();
               
            }


            else
            {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No Tienes Tridys");
                InAppNotification.Instance.ShowNotication(notification);
            }
        }
        catch (Exception E)
        {
            ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No se pudo conectar al servidor");
            InAppNotification.Instance.ShowNotication(notification);
            Debug.Log($"es este{E}");
        }
    }
}
