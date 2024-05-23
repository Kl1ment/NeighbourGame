using UnityEngine;

public class StateDialog : FsmState
{
    public StateDialog(FSM fsm, Animator animator) : base(fsm, animator)
    {
        Dialog.EndDialog += OnExitDialog;
    }

    public override void Enter()
    {
        Animator.SetBool("Idle", true);
    }

    private void OnExitDialog()
    {
        Fsm.SetState<StateIdle>();
    }

    public override void Exit()
    {
        
    }

    public override void Update()
    {

    }
}
