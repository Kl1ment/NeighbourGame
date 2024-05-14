using UnityEngine;
using UnityEngine.UI;

public class CreatorSlot : MonoBehaviour
{

    public void Create(Item item)
    {
        GameObject slotImage = new GameObject("Slot");
        slotImage.AddComponent<Image>().sprite = item.Icon;
        Slot newSlot = slotImage.AddComponent<Slot>();
        newSlot.SetItem(item);
        slotImage.transform.SetParent(transform);
        slotImage.transform.localScale = Vector3.one;
    }
}
