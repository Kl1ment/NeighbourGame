
using UnityEngine;

public abstract class FsmState
{
    protected readonly FSM Fsm;
    protected readonly Animator Animator;
    protected readonly Clicker Clicker;
    protected readonly PlayerMovement PlayerMovement;

    public FsmState(FSM fsm, Animator animator, Clicker clicker, PlayerMovement playerMovement)
    {
        Fsm = fsm;
        Animator = animator;
        Clicker = clicker;
        PlayerMovement = playerMovement;
    }

    public FsmState(FSM fsm, Animator animator)
    {
        Fsm = fsm;
        Animator = animator;
    }

    public abstract void Enter();
    public abstract void Exit();

    public abstract void Update();
}
