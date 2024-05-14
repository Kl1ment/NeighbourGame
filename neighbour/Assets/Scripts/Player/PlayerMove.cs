using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private StatePlayer _statePlayer;


    private void Start()
    {
        _statePlayer = GetComponent<StatePlayer>();

        _agent = GetComponent<NavMeshAgent>();

        transform.tag = Tags.Player;
        gameObject.layer = LayerMask.NameToLayer(Layers.VisionNeighbour);
    }

    private void Update()
    {
        if (_statePlayer.CurState == StatePlayer.State.Walk)
        {
            if ((_agent.destination - transform.position).magnitude <= 1f)
            {
                _statePlayer.Enter(StatePlayer.State.Idle);
            }
        }
    }

    public void MoveTo(Vector3 destination, float speed)
    {
        _agent.speed = speed;
        _statePlayer.Enter(StatePlayer.State.Walk);
        _agent.destination = destination;
    }
}
