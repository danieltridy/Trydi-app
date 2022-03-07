using UnityEngine;

public class Compass : MonoBehaviour
{

    private void Start()
    {
        Input.location.Start();
    }
    void Update()
    {
        // Orient an object to point to magnetic north.
        transform.localRotation = Quaternion.Euler(0, 0, -Input.compass.trueHeading);

        Debug.Log(-Input.compass.trueHeading);
    }
}