using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    private Item _item;
    public static Action<Slot> ChoiseItem;

    Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void SetItem(Item item)
    {
        if (_item == null)
        {
            _item = item;
        }
    }

    public Item GetItem()
    {
        return _item;
    }

    public void Deselect()
    {
        _image.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ChoiseItem?.Invoke(this);
        _image.color = Color.yellow;
    }

    public void ResolutionItem()
    {
        Destroy(gameObject);
    }
}
