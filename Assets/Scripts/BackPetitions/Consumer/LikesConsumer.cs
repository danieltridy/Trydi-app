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

    public void Looks(Tridy tridy)
    {
        tridy_id = tridy.id;
        StartCoroutine(TridyPeti1());
    }
    public void LooksMe(MTridys tridy)
    {
        tridy_id = tridy.id;
        StartCoroutine(TridyPeti1());
    }
    IEnumerator TridyPeti1()
    {

        var service = new RegisterDataLooks(tridy_id);
        yield return service.SendAsync(response);

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
            Debug.Log("ignorar");

        }
    }
}
