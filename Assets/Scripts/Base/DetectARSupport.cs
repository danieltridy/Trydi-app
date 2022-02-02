using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using GoogleARCore;
using UnityEngine.Events;

public class DetectARSupport : MonoBehaviour
{

    public UnityEvent OnSupport, OnNotSupport;

    private void OnEnable()
    {
        OnSupport.Invoke();
        //#if UNITY_ANDROID
        //        OnSupport.Invoke();
        //        //StartCoroutine(ARSupport());
        //#endif
        //#if UNITY_IOS || UNITY_EDITOR
        //        OnSupport.Invoke();
        //#endif

    }
    //private IEnumerator ARSupport()
    //{
    //    AsyncTask<ApkAvailabilityStatus> checkTask = Session.CheckApkAvailability();
    //    CustomYieldInstruction customYield = checkTask.WaitForCompletion();
    //    yield return customYield;
    //    ApkAvailabilityStatus result = checkTask.Result;
    //    switch (result)
    //    {
    //        case ApkAvailabilityStatus.SupportedApkTooOld:
    //            print("Supported Device");
    //            OnSupport.Invoke();
    //            break;
    //        default:
    //            print("Unsupported Device Not Capable");
    //            OnNotSupport.Invoke();
    //            break;
    //    }
    //}

}
