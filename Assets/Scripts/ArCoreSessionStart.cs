#if UNITY_ANDROID
//using GoogleARCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Class to Detect the ARCore Session Start
public class ArCoreSessionStart : MonoBehaviour
{
    public UnityEvent OnSessionStart;
    private bool justOne = true;

    private void Start()
    {
        StartCoroutine(StartSession());
    }

    private IEnumerator StartSession()
    {
        yield return new WaitForSeconds(2f);
        OnSessionStart.Invoke();
    }
}
#endif
