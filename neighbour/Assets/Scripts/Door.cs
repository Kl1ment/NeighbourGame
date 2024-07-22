using UnityEngine;

public class Door : InteractiveObject
{
    [SerializeField] private GameObject _door;
    private Quaternion _defaultRotation;

    private GameObject _passer;

    private void Start()
    {
        _defaultRotation = _door.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        _passer = other.gameObject;
        
        if (_passer.tag != Tags.Player)
        {
            Open();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _door.transform.rotation = _defaultRotation;
    }

    public override void Interactive()
    {
        Open();
    }

    private void Open()
    {
        float dir = (transform.forward + _passer.transform.forward).magnitude;
        if (dir > 1)
        {
            _door.transform.Rotate(Vector3.up, 90);
        }
        else
        {
            _door.transform.Rotate(Vector3.up, -90);
        }
    }
}
