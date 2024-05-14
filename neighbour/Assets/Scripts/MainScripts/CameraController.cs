using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    private float _cameraSpeed = 5f;
    private float _widthScreen;
    private float _heightScreen;

    private Vector3 _startPos;
    private float _sensetive = 20f;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _widthScreen = Screen.width;
        _heightScreen = Screen.height;
    }

    private void Update()
    {
        Vector2 zoom = Input.mouseScrollDelta;
        if (zoom.y != 0)
        {
            _camera.transform.position += _camera.transform.forward * zoom.y;
        }

        //MoveCamera();
        MoveFromScroll();

    }

    private void MoveFromScroll()
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
    }

    private void MoveCamera()
    {
        Vector3 direction = Vector3.zero;

        if (Input.mousePosition.x / _widthScreen <= 0)
            direction += Vector3.left;
        if (Input.mousePosition.x / _widthScreen >= 1)
            direction += Vector3.right;
        if (Input.mousePosition.y / _heightScreen <= 0)
            direction += Vector3.back;
        if (Input.mousePosition.y / _heightScreen >= 1)
            direction += Vector3.forward;

        _camera.transform.position += direction * _cameraSpeed * Time.deltaTime;
    }
}
