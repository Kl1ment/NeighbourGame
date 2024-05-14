using UnityEngine;

public class ResolutionObject : InteractiveObject
{
    [SerializeField] private Item _combination;

    public delegate Slot Request();
    public static event Request RequestItem;

    public override void Interactive()
    {
        Slot inventorySlot = RequestItem?.Invoke();
        if (inventorySlot && inventorySlot.GetItem() == _combination)
        {
            Debug.Log($"Использовано {inventorySlot.GetItem().Name}");
            inventorySlot.ResolutionItem();
        }
        else
        {
            Debug.Log($"Не могу это применить сюда :(");
        }
    }
}
