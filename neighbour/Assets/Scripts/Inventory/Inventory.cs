using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private CreatorSlot _creatorSlot;
    private Slot _activeSlot;

    private void Start()
    {
        _creatorSlot = GetComponent<CreatorSlot>();
    }

    private void OnEnable()
    {
        TakingObject.Took += OnTakeItems;
        ResolutionObject.RequestItem += OnGetSlot;
        Slot.ChoiseItem += OnSetActiveItem;
    }

    private void OnDisable()
    {
        TakingObject.Took -= OnTakeItems;
        ResolutionObject.RequestItem -= OnGetSlot;
        Slot.ChoiseItem -= OnSetActiveItem;
    }

    private void OnTakeItems(List<Item> items)
    {
        foreach (Item item in items)
        {
            _creatorSlot.Create(item);
        }
    }

    private void OnSetActiveItem(Slot slot)
    {
        if (_activeSlot)
        {
            _activeSlot.Deselect();
        }
        _activeSlot = slot;
    }

    private Slot OnGetSlot()
    {
        return _activeSlot;
    }
}
