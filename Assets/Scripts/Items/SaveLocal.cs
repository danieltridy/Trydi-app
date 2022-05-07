using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLocal : MonoBehaviour
{
    private bool check;

    public void SaveLocalItem(string name, string description, string estructura)
    {
        int i = 0;
        while (!check)
        {
            if (PlayerPrefs.HasKey($"name{i}"))
            {
                i++;
            }
            else {
                var newItem = new MTridys();
                newItem.name = name;
                PlayerPrefs.SetString($"name{i}",name);
                newItem.description = description;
                PlayerPrefs.SetString($"Description{i}",description);
                newItem.estructura = estructura;
                PlayerPrefs.SetString($"estructura{i}", estructura);
                newItem.local = true;
                MeTridyData.Instance.TridysData.data.Add(newItem);
                check = true;
            }
        }
        check = false;

    }
    private void Start()
    {
        StartLocal();
    }
    public void StartLocal()
    {
        MeTridyData.Instance.TridysData.data.Clear();
        int i = 0;
        while (!check)
        {
            if (PlayerPrefs.HasKey($"name{i}"))
            {
                var newItem = new MTridys();
                newItem.name = PlayerPrefs.GetString($"name{i}");
                newItem.description = PlayerPrefs.GetString($"Description{i}");
                newItem.estructura =PlayerPrefs.GetString($"estructura{i}");
                newItem.local = true;
                MeTridyData.Instance.TridysData.data.Add(newItem);
                i++;
            }
            else
            {
                check = true;

            }
        }
        check = false;

    }
}
