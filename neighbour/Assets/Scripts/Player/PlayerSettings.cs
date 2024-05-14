using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    private void Awake()
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            child.tag = Tags.Player;
            child.gameObject.layer = LayerMask.NameToLayer(Layers.VisionNeighbour);
        }
    }
}
