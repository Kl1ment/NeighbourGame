using UnityEngine;

public class Vision : MonoBehaviour
{
    private int _numRays = 20;
    private float _maxAngle = 80;
    private float _distance = 10;
    private int _visionLayer;

    private void Start()
    {
        _visionLayer = LayerMask.GetMask(Layers.VisionNeighbour);
    }

    private void FixedUpdate()
    {
        IsVision();
    }

    private void IsVision()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _distance, _visionLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 direction = colliders[i].transform.position - transform.position;
            Vector3 startPoint = transform.position;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider == colliders[i])
                {
                    if (Vector3.Angle(transform.forward, direction) <= _maxAngle)
                    {
                        if (colliders[i].tag == Tags.Player)
                        {
                            Debug.DrawLine(startPoint, hit.collider.transform.position, Color.red);
                        }

                        if (colliders[i].tag == Tags.VisionTrigger)
                        {
                            Debug.DrawLine(startPoint, hit.collider.transform.position, Color.green);
                        }
                    }
                }
            }
        }
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

    private void CreateSector()
    {
        for (int i = 0; i < _numRays / 2; i++)
        {
            CheckVision(CreateRay(true, i));
            CheckVision(CreateRay(false, i));
        }

    }

    private void CheckVision(Ray ray)
    {
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, _distance, _visionLayer))
        {
            PlayerMove player = hit.transform.GetComponent<PlayerMove>();
            if (player != null)
            {
                Debug.Log("I see you!");
            }
        }
    }

    private Ray CreateRay(bool RightSide, int numberRay)
    {
        int dir = -1;
        if (RightSide) { dir = 1; }
            
        float angle = Mathf.Deg2Rad * (dir * _maxAngle / _numRays * numberRay + transform.rotation.eulerAngles.y);
        Vector3 target = new Vector3(Mathf.Sin(angle) * _distance, 0, Mathf.Cos(angle) * _distance);
        Vector3 direction = target - transform.position;
        return new Ray(transform.position, direction);
    }
}
