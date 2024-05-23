
using UnityEngine.AI;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    private NavMeshAgent _agent;
    private float _maxDistanceToDistination = 1f;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.stoppingDistance = _maxDistanceToDistination;

        transform.tag = Tags.Player;
        gameObject.layer = LayerMask.NameToLayer(Layers.VisionNeighbour);
    }

    public bool IsReachedDestination()
    {
        return (_agent.destination - transform.position).magnitude <= _maxDistanceToDistination;
    }

    public void MoveTo(Vector3 destination, float speed)
    {
        _agent.speed = speed;
        _agent.destination = destination;
    }
}
