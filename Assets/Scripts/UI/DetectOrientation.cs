using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DetectOrientation : MonoBehaviour
{
    public UnityEvent OnCorrectOrientation;
    [SerializeField]
    private float tolerance = 0.6f;
    private void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
        Input.gyro.enabled = true;
    }
    private void OnEnable()
    {
        Invoke("Wait",5f);
    }

    private void Wait() {
        StartCoroutine(WaitForDetectOrientation());
    }
    private void OnDisable()
    {
      StopAllCoroutines();
    }
    private IEnumerator WaitForDetectOrientation()
    {
        yield return new WaitUntil(() => CanActivate());
        OnCorrectOrientation.Invoke();
    }
    [EasyButtons.Button]
    private void ForceInvoke()
    {
        OnCorrectOrientation.Invoke();
    }

    private bool CanActivate()
    {
        return (Input.deviceOrientation == DeviceOrientation.Portrait && Input.acceleration.z > tolerance  );
    }
}
