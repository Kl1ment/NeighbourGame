using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ViewInventory : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Transform _inventory;
    private Vector3 _closePos;
    private Vector3 _openPos;
    private Vector3 _curPos;
    private RectTransform _inventoryRectTransform;
    private float _widthInventory;

    private bool _isClosing;
    private bool _isOpening;
    private bool _isTaking = false;


    private void Start()
    {
        _inventory = transform.GetChild(0);
        _inventoryRectTransform = _inventory.GetComponent<RectTransform>();
        _widthInventory = _inventoryRectTransform.rect.width;
        _closePos = _inventoryRectTransform.anchoredPosition;
        _openPos = _closePos + new Vector3(-_widthInventory, 0, 0);
    }

    private void OnEnable()
    {
        TakingObject.Took += OnTakeItem;
    }

    private void OnDisable()
    {
        TakingObject.Took -= OnTakeItem;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isOpening = true;
        _isTaking = false;
        _isClosing = false;
        StartCoroutine(OpenInvetory());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isOpening = false;
        _isTaking = false;
        _isClosing = true;
        StartCoroutine(CloseInvetory());
    }

    private void OnTakeItem(List<Item> items)
    {
        _isOpening = true;
        _isTaking = true;
        _isClosing = false;
        StartCoroutine(OpenInvetory());
    }

    private IEnumerator OpenInvetory()
    {
        _inventoryRectTransform.anchoredPosition = new Vector3(Mathf.Lerp(_curPos.x, _openPos.x, 0.2f), 0, 0);
        _curPos = _inventoryRectTransform.anchoredPosition;

        yield return new WaitForSeconds(0.05f);
        if ((_curPos - _openPos).magnitude > 1f)
        {
            if (_isOpening)
                StartCoroutine(OpenInvetory());
        }
        else if (_isTaking)
        {
            _isOpening = false;
            _isTaking = true;
            _isClosing = true;
            StartCoroutine(CloseInvetory());
        }
    }

    private IEnumerator CloseInvetory()
    {
        _inventoryRectTransform.anchoredPosition = new Vector3(Mathf.Lerp(_curPos.x, _closePos.x, 0.2f), 0, 0);
        _curPos = _inventoryRectTransform.anchoredPosition;

        yield return new WaitForSeconds(0.05f);
        if ((_curPos - _closePos).magnitude > 1f)
        {
            if (_isClosing)
                StartCoroutine(CloseInvetory());
        }
    }
}
