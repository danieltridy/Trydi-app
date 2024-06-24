using UnityEngine;

public class Compass : MonoBehaviour
{
    void Update()
    {
        // Orient an object to point to magnetic north.
        transform.localRotation = Quaternion.Euler(0, 0, LocationProvider.Instance.GetUserHeading());

    }
}