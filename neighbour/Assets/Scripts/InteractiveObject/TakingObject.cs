using System.Collections.Generic;
using UnityEngine;

public class TakingObject : InteractiveObject
{
    [SerializeField] private List<Item> _storage;

    public delegate void Inventory(List<Item> items);
    public static event Inventory Took;

    public override void Interactive()
    {
        Took?.Invoke(_storage);
        _storage = new List<Item>();
    }
}
