using UnityEngine;

public class Door : MonoBehaviour
{
    private Quaternion _defaultRotation;

    private void Start()
    {
        _defaultRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        float dir = (transform.forward - other.transform.forward).z;
        Debug.Log(other.transform.forward);
        if (dir < 1)
        {
            transform.Rotate(Vector3.up, 90);
        }
        else
        {
            transform.Rotate(Vector3.up, -90);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        transform.rotation = _defaultRotation;
    }
}
