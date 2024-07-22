using UnityEngine;

public class Way : MonoBehaviour
{
    private Transform[] _points;
    private int _curPoint = -1;

    private void Awake()
    {
        _points = new Transform[transform.childCount];
        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = transform.GetChild(i).transform;
            if (_points[i].GetComponent<InteractiveObject>() == null)
            {
                _points[i].gameObject.SetActive(false);
            }
        }
    }

    public Vector3 GetNextPoint()
    {
        _curPoint = (_curPoint + 1) % _points.Length;
        return _points[_curPoint].transform.position;
    }

    private void OnDrawGizmos()
    {
        Transform[] points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i).transform;
        }

        for (int i = 0; i < points.Length; i++)
        {
            int nextPoint = (i + 1) % points.Length;
            Gizmos.DrawLine(points[i].transform.position, points[nextPoint].transform.position);
        }
    }
}
