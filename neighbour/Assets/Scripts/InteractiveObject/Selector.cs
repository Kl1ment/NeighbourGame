using UnityEngine;

public class Selector : MonoBehaviour
{
    private SelectedObject _currentSelectable;

    private void Update()
    {
        RaycastHit hit = MouseRay.ReleaseRay();
        if (hit.transform)
        {
            Select(hit);
        }
        else if (_currentSelectable)
        {
            _currentSelectable.Deselect();
            _currentSelectable = null;
        }
    }

    private void Select(RaycastHit hit)
    {
        SelectedObject selectable = hit.collider.gameObject.GetComponent<SelectedObject>();
        if (selectable)
        {
            if (_currentSelectable && _currentSelectable != selectable)
            {
                _currentSelectable.Deselect();
            }
            _currentSelectable = selectable;
            _currentSelectable.Select();

        }
        else if (_currentSelectable)
        {
            _currentSelectable.Deselect();
            _currentSelectable = null;
        }
    }
}
