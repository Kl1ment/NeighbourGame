

using System;
using UnityEngine;

public class StateWizard : MonoBehaviour
{ 
    public enum State
    {
        Idle,
        Walk,
        Attack
    }

    [SerializeField] private Animator _animatior;
    private State _curState = State.Walk;
    public State CurState => _curState;

    public Action ChangeState;

    public void Enter(State state)
    {
        _animatior.SetBool(_curState.ToString(), false);
        _curState = state;
        _animatior.SetBool(_curState.ToString(), true);

        ChangeState?.Invoke();
    }
}
