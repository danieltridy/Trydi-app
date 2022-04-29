using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTridys : MonoBehaviour
{
    private int i=0;

    public void OnClick(int n)
    {
        if (MeTridyData.Instance.TridysData.data != null) {
        var s = MeTridyData.Instance.TridysData.data[i];
        CreateARObject.Instance.AddInformation(s.estructura);
        SceneViewManagers.Instance.ViewManagerItemM.ViewSpecificItemM(s);
        i= i+n;
        if (i == MeTridyData.Instance.TridysData.data.Count) {
            i = 0;
        }
        else if (i<0) {
            i = MeTridyData.Instance.TridysData.data.Count - 1;
        }
    }
    }
}
