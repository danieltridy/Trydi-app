using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LikesConsumer : MonoBehaviour
{
    private int user_id;
    private int tridy_id;
    [SerializeField]
    private ViewManagerItem viewManagerItem;
    public void LikesandDislike()
    {
        user_id = UserData.Instance.PlayerData.data.id;
        tridy_id = viewManagerItem.id;
        StartCoroutine(TridyPeti());

    }

    IEnumerator TridyPeti()
    {

        var service = new RegisterDataLikes(user_id,tridy_id);
        yield return service.SendAsync(response);

    }
    private void response(string response)
    {
        try
        {
            TridyDataOnly.Instance.Likes = JsonConvert.DeserializeObject<Likes>(response);
            if (TridyDataOnly.Instance.Likes.success)
            {
          

            }

        }
        catch (Exception E)
        {
            if (!TridyDataOnly.Instance.Likes.success)
            {
                ClassnNotification notification1 = new ClassnNotification(EnumNotification.ButtonOk, $"No tiene nombre o ya esta en uso");
                InAppNotification.Instance.ShowNotication(notification1);

            }
            else
            {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No se pudo conectar al servidor");
                InAppNotification.Instance.ShowNotication(notification);
            }

        }
    }
}
