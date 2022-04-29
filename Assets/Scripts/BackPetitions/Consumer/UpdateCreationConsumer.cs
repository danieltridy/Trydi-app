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
    private string estructura;
    [SerializeField]
    private ItemsCreator meshEditor;
    [SerializeField]
    private RegisterCreationConsumer register;
    [SerializeField]
    private TMP_Text name, description, autor;
    [SerializeField]
    private TMP_Text name1, description1, autor1;

    public void UpdateTexts() {
        name.text = name1.text;
        description.text = description1.text;
        autor.text = autor1.text;
    }
    public void TridyStart()
    {
        meshEditor.SaveJson();
        estructura = meshEditor.JsonString;
        StartCoroutine(TridyPeti());
    }
    IEnumerator TridyPeti()
    {
        ClassnNotification notification = new ClassnNotification(EnumNotification.Load, null);
        InAppNotification.Instance.ShowNotication(notification);
        var service = new UpdateTridyData(viewManager.item.id, estructura);
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
