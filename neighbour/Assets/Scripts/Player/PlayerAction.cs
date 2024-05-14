using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private InteractiveObject _currentInteraction;
    private PlayerMove _playaerMove;
    private Clicker _clicker;

    private float _minDistInterective = 3f;

    private float _speedWalk = 5;
    private float _speedRun = 10;

    private void Start()
    {
        _playaerMove = GetComponent<PlayerMove>();
        _clicker = GetComponent<Clicker>();
    }

    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            float moveSpead = _speedWalk;
            if (_clicker.IsRightDoubleClick)
                moveSpead = _speedRun;

            RaycastHit hit = MouseRay.ReleaseRay();
            if (hit.transform)
            {
                _playaerMove.MoveTo(hit.point, moveSpead);
                _currentInteraction = null;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            float moveSpead = _speedWalk;
            if (_clicker.IsLeftDoubleClick)
                moveSpead = _speedRun;

            RaycastHit hit = MouseRay.ReleaseRay();
            if (hit.transform)
            {
                InteractiveObject interactive = hit.transform.GetComponent<InteractiveObject>();
                if (interactive != null)
                {
                    _currentInteraction = interactive;
                    _playaerMove.MoveTo(_currentInteraction.transform.position, moveSpead);
                }
            }
        }

        

        if (_currentInteraction != null &&
            (transform.position - _currentInteraction.transform.position).magnitude <= _minDistInterective)
        {
            _currentInteraction.Interactive();
            _currentInteraction = null;
        }
    }
}
