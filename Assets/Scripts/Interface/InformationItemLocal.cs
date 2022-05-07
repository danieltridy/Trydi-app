using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InformationItemLocal : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField name1, description1;
    int i, u;
    public bool confirmation;

    public void AddInformation(int i, int u ) {
        name1.text = PlayerPrefs.GetString($"name{i}");
        description1.text = PlayerPrefs.GetString($"Description{i}");
        this.i = i;
        this.u = u;
        confirmation = true;
    }

    public void ConfirmationTridy() {
        if (confirmation) {
            PlayerPrefs.DeleteKey($"name{i}");
            PlayerPrefs.DeleteKey($"Description{i}");
            PlayerPrefs.DeleteKey($"estructura{i}");
            MeTridyData.Instance.TridysData.data.RemoveAt(u);
            confirmation = false;
        }
    }

    public void ConfirmationOff() {
        confirmation = false;
    }

}
