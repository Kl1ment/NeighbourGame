
using UnityEngine;

abstract public class InteractiveObject : SelectedObject
{
    public abstract void Interactive();

    private void Start()
    {
        transform.tag = Tags.VisionTrigger;
        gameObject.layer = LayerMask.NameToLayer(Layers.VisionNeighbour);
    }
}
