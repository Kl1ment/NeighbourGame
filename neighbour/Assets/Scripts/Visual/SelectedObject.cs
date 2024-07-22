using UnityEngine;

public class SelectedObject : MonoBehaviour
{
    private Outline _outline;

    private void Awake()
    {
        _outline = gameObject.AddComponent<Outline>();

        _outline.enabled = false;
        _outline.OutlineColor = Color.white;
        _outline.OutlineWidth = 7;
    }

    public void Select()
    {
        _outline.enabled = true;
    }

    public void Deselect()
    {
        _outline.enabled = false;
    }
}
