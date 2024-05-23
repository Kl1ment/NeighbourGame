using UnityEngine;

public class StateIdle : FsmState
{
    public StateIdle(FSM fsm, Animator animator, Clicker clicker, PlayerMovement playerMovement) : base(fsm, animator, clicker, playerMovement)
    {
        Dialog.BeginDialog += OnEnterDialog;
    }

    public override void Enter()
    {
        Animator.SetBool("Idle", true);
    }

    public override void Exit()
    {
        Animator.SetBool("Idle", false);
    }

    public override void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit = MouseRay.ReleaseRay();
            if (hit.transform)
            {
                Fsm.SetState<StateWalk>();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit = MouseRay.ReleaseRay();
            if (hit.transform)
            {
                if (hit.transform.GetComponent<InteractiveObject>())
                {
                    Fsm.SetState<StateWalk>();
                }
            }
        }
    }

    private void OnEnterDialog()
    {
        Fsm.SetState<StateDialog>();
    }
}
