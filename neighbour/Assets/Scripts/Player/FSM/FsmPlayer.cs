
using UnityEngine;

[RequireComponent (typeof(Clicker), typeof(PlayerMovement))]
public class FsmPlayer : MonoBehaviour
{
    private FSM _fsm;
    [SerializeField] private Animator _animator;
    private Clicker _clicker;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _fsm = new FSM();
        _clicker = GetComponent<Clicker>();
        _playerMovement = GetComponent<PlayerMovement>();

        _fsm.AddState(new StateIdle(_fsm, _animator, _clicker, _playerMovement));
        _fsm.AddState(new StateWalk(_fsm, _animator, _clicker, _playerMovement));
        _fsm.AddState(new StateDialog(_fsm, _animator));

        _fsm.SetState<StateIdle>();
    }

    private void LateUpdate()
    {
        _fsm.Update();
    }
}
