using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(StateWizard))]
public class EnemyMove : MonoBehaviour
{
    private StateWizard _stateWizard;

    [SerializeField] private GameObject _wayPoints;
    private Way _way;
    private NavMeshAgent _agent;
    private Vector3 _target;

    private float _minDistToNextPoint = 1.5f;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _stateWizard = GetComponent<StateWizard>();

        _way = _wayPoints.GetComponent<Way>();
    }

    private void Start()
    {
        _target = _way.GetNextPoint();
        transform.position = _target;
    }

    private void OnEnable()
    {
        _stateWizard.ChangeState += OnCheckState;
    }

    private void OnDisable()
    {
        _stateWizard.ChangeState -= OnCheckState;
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

    private void OnCheckState()
    {
        if (_stateWizard.CurState == StateWizard.State.Walk)
        {
            _agent.destination = _target;
        }
        else
        {
            _agent.destination = transform.position;
        }
    }
}
