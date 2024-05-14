using UnityEngine;

public static class MouseRay
{
    private static Camera _camera = Camera.main;

    public static RaycastHit ReleaseRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit;
    }
}
