using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;

    private Vector3 _startPos;
    private float _sensetive = 20f;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector2 zoom = Input.mouseScrollDelta;
        if (zoom.y != 0)
        {
            _camera.transform.position += _camera.transform.forward * zoom.y;
        }

        MoveFromMouseWheel();

    }

    private void MoveFromMouseWheel()
    {
        if (Input.GetMouseButtonDown(2))
        {
            _startPos = Input.mousePosition;
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 offset = (_startPos - Input.mousePosition) / _sensetive;
            Vector3 pos = _camera.transform.position;
            pos.x += offset.x;
            pos.z += offset.y;
            _camera.transform.position = pos;
            _startPos = Input.mousePosition;
        }

        //if (Input.GetMouseButtonDown(2))
        //{
        //    _startPos = _camera.ScreenToViewportPoint(Input.mousePosition);
        //}

        //if (Input.GetMouseButton(2))
        //{
        //    Vector3 offset = (_startPos - _camera.ScreenToViewportPoint(Input.mousePosition));
        //    Vector3 pos = _camera.transform.position;
        //    pos.x += offset.x;
        //    pos.z += offset.y;
        //    _camera.transform.position = pos;
        //}
    }
}
