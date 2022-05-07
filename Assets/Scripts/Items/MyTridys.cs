using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTridys : MonoBehaviour
{
    private int i = 0;

    [SerializeField]
    private GameObject button;
    [SerializeField]
    private InformationItemLocal registerCreation;
    public void OnClick(int n)
    {
        if (MeTridyData.Instance.TridysData.data.Count > 0)
        {
            var s = MeTridyData.Instance.TridysData.data[i];
            if (s.local)
            {
                button.SetActive(true);
            }
            else
            {
                button.SetActive(false);
            }
            CreateARObject.Instance.AddInformation(s.estructura);
            SceneViewManagers.Instance.ViewManagerItemM.ViewSpecificItemM(s);
            i = i + n;
            if (i == MeTridyData.Instance.TridysData.data.Count)
            {
                i = 0;
            }
            else if (i < 0)
            {
                i = MeTridyData.Instance.TridysData.data.Count - 1;
            }
        }
    }

    public void RegisterTridyLocal()
    {
        int num = 0;
        for (int n = 0; n <MeTridyData.Instance.TridysData.data.Count; n++) {
            if (MeTridyData.Instance.TridysData.data[i] == MeTridyData.Instance.TridysData.data[n])
            {
             
            }
            else {
                if (MeTridyData.Instance.TridysData.data[n].local)
                {
                    num++;
                }
            }
        }
        registerCreation.AddInformation(num,i);
    }
}
