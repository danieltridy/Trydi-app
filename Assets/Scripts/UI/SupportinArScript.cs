using ARSupportCheck;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

public class SupportinArScript : MonoBehaviour
{
    [SerializeField]
    private bool supporting;
    [SerializeField]
    private UnityEvent InvokeNoSupporting;
    void Start()
    {
        supporting = ARSupportChecker.IsSupported();
        if (!supporting)
        {
            Invoke("WaitSupportingAr", 1f);
        }
    }

    private void WaitSupportingAr() {
        ClassnNotification notification = new ClassnNotification(EnumNotification.ButtonOk, $"Tu Dispositivo no es compatible con AR");
        NewNotification.Instance.ShowNotication(notification);
        InvokeNoSupporting.Invoke();
    }

}
