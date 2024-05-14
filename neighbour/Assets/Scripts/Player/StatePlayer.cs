using UnityEngine;


public class StatePlayer : MonoBehaviour
{
    public enum State
    {
        Idle,
        Walk,
        Take,
        Drop,
        Run
    }

    [SerializeField] private Animator _animatior;
    private State _curState = State.Idle;
    public State CurState => _curState;

    public void Enter(State state)
    {
        _animatior.SetBool(_curState.ToString(), false);
        _curState = state;
        _animatior.SetBool(_curState.ToString(), true);
    }
}
