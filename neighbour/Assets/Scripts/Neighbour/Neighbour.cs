using UnityEngine;
using UnityEngine.AI;

public class Neighbour : MonoBehaviour
{
    [SerializeField] private GameObject _wayPoints;
    private Way _way;
    private NavMeshAgent _agent;
    private Vector3 _target;

    private float _minDistToNextPoint = 1.5f;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();


        _way = _wayPoints.GetComponent<Way>();
        _target = _way.GetNextPoint();
        transform.position = _target;
    }

    private void Update()
    {
        MoveTo();
    }

    private void MoveTo()
    {
        if ((transform.position - _target).magnitude <= _minDistToNextPoint)
        {
            _target = _way.GetNextPoint();
            _agent.destination = _target;
        }
    }
}
