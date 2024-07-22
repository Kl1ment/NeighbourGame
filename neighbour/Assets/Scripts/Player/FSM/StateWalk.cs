
using UnityEngine;

public class StateWalk : FsmState
{
    private float _speedWalk = 5f;
    private float _speedRun = 10f;
    private InteractiveObject _currentInteraction;

    public StateWalk(
        FSM fsm,
        Animator animator,
        Clicker clicker,
        PlayerMovement playerMovement
        ) : base(fsm, animator, clicker, playerMovement)
    {
    }

    public override void Enter()
    {
        Animator.SetBool("Walk", true);

        RaycastHit hit = MouseRay.ReleaseRay();

        if (Input.GetMouseButtonDown(1))
        {
            PlayerMovement.MoveTo(hit.point, _speedWalk);
        }
        else
        {
            _currentInteraction = hit.transform.GetComponent<InteractiveObject>();
            PlayerMovement.MoveTo(_currentInteraction.transform.position, _speedWalk);
        }
    }

    public override void Exit()
    {
        Animator.SetBool("Walk", false);
    }

    public override void Update()
    {
        float speed = _speedWalk;

        if (Clicker.IsRightDoubleClick || Clicker.IsLeftDoubleClick)
        {
            speed = _speedRun;
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit = MouseRay.ReleaseRay();
            if (hit.transform)
            {
                _currentInteraction = null;
                PlayerMovement.MoveTo(hit.point, speed);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = MouseRay.ReleaseRay();
            if (hit.transform)
            {
                InteractiveObject interactive = hit.transform.GetComponent<InteractiveObject>();
                if (interactive != null)
                {
                    _currentInteraction = interactive;
                    PlayerMovement.MoveTo(_currentInteraction.transform.position, speed);
                }
            }
        }

        if (PlayerMovement.IsReachedDestination())
        {
            Fsm.SetState<StateIdle>();
            if (_currentInteraction != null)
            {
                _currentInteraction.Interactive();
                _currentInteraction = null;
            }
        }
    }
}
