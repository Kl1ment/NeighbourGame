using UnityEngine;

public class Clicker : MonoBehaviour
{
    private float _lastRightClick = 0;
    private float _lastLeftClick = 0;
    private float _clickDelay = 0.5f;

    private bool _isRightDoubleClick = false;
    private bool _isLeftDoubleClick = false;

    public bool IsRightDoubleClick => _isRightDoubleClick;
    public bool IsLeftDoubleClick => _isLeftDoubleClick;

    private void Update()
    {
        if (Time.time - _lastLeftClick > _clickDelay)
            _isLeftDoubleClick = false;
        
        if (Time.time - _lastRightClick > _clickDelay)
            _isRightDoubleClick = false;

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time - _lastLeftClick <= _clickDelay)
                _isLeftDoubleClick = true;

            _lastLeftClick = Time.time;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Time.time - _lastRightClick <= _clickDelay)
                _isRightDoubleClick = true;

            _lastRightClick = Time.time;
        }
    }
}
