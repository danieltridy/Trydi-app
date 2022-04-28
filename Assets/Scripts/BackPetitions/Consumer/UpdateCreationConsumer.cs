using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UpdateCreationConsumer : MonoBehaviour
{

  
    [SerializeField]
    private ViewManagerItem viewManager;
    [SerializeField]
    private string estructura,name, description;
    [SerializeField]
    private ItemsCreator meshEditor;
    [SerializeField]
    private TMP_InputField name1, description1;
    [SerializeField]
    private RegisterCreationConsumer register;
    public void TridyStart()
    {
        meshEditor.SaveJson();
        name = name1.text;
        description = description1.text;
        estructura = meshEditor.JsonString;
        StartCoroutine(TridyPeti());
    }
    IEnumerator TridyPeti()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null);
        InAppNotification.Instance.ShowNotication(notification);
        var service = new UpdateTridyData(viewManager.item.id, name, description, estructura);
        yield return service.SendAsync(response);

    }
    private void response(string response)
    {
        InAppNotification.Instance.HideNotication();
        try
        {
            TridyDataRegisters.Instance.TridysData = JsonConvert.DeserializeObject<TridyDataRegister>(response);
            if (TridyDataRegisters.Instance.TridysData.success)
            {
                register.RegisterTridy.Invoke();
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
            else
            {
                ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"No se pudo conectar al servidor");
                InAppNotification.Instance.ShowNotication(notification);
            }

        }
    }



}
