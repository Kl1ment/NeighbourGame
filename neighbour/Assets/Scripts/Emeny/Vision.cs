using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(StateWizard))]
public class Vision : MonoBehaviour
{

    private float _maxAngle = 80;
    private float _distance = 10;
    private int _visionLayer;
    private StateWizard _stateWizard;

    private void Start()
    {
        _visionLayer = LayerMask.GetMask(Layers.VisionNeighbour);
        _stateWizard = GetComponent<StateWizard>();
    }

    private void Update()
    {
        List<string> visionObject = InFieldOfView();

        if (visionObject.Contains(Tags.Player) && _stateWizard.CurState != StateWizard.State.Attack)
        {
            _stateWizard.Enter(StateWizard.State.Attack);
        }
        else if (_stateWizard.CurState == StateWizard.State.Attack)
            _stateWizard.Enter(StateWizard.State.Walk);
    }

    private List<string> InFieldOfView()
    {
        List<string> result = new List<string>();

        Collider[] colliders = Physics.OverlapSphere(transform.position, _distance, _visionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 direction = colliders[i].transform.position - transform.position;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == colliders[i])
                {
                    if (Vector3.Angle(transform.forward, direction) <= _maxAngle)
                    {
                        result.Add(hit.transform.tag);

                        //if (colliders[i].tag == Tags.Player)
                        //{
                        //    Debug.DrawLine(transform.position, hit.collider.transform.position, Color.red);
                        //    transform.LookAt(hit.transform.position);
                        //    isVisionPlayer = true;
                        //}

                        //if (colliders[i].tag == Tags.VisionTrigger)
                        //{
                        //    Debug.DrawLine(transform.position, hit.collider.transform.position, Color.green);
                        //    isVisionTriggerObject = true;
                        //}
                    }
                }
            }
        }

        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _distance);

        Gizmos.color = Color.yellow;
        float angle = Mathf.Deg2Rad * (_maxAngle + transform.rotation.eulerAngles.y);
        Vector3 target = new Vector3(Mathf.Sin(angle) * _distance, 0, Mathf.Cos(angle) * _distance);
        Gizmos.DrawLine(transform.position, transform.position + target);

        angle = Mathf.Deg2Rad * (-_maxAngle + transform.rotation.eulerAngles.y);
        target = new Vector3(Mathf.Sin(angle) * _distance, 0, Mathf.Cos(angle) * _distance);
        Gizmos.DrawLine(transform.position, transform.position + target);
    }
}
