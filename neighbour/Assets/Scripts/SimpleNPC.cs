using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SimpleNPC : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _TMPro;
    [SerializeField] Canvas _canvas;

    private Camera _camera;

    [SerializeField] private List<string> _phrases;
    private int _curPhrase = 0;


    private void Start()
    {
        _camera = Camera.main;
        _canvas.enabled = false;
    }

    private void Update()
    {
        if (_camera.enabled)
        {
            _canvas.transform.LookAt(Camera.main.transform.position);
            _canvas.transform.Rotate(transform.up, 180);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            _canvas.enabled = true;
            _TMPro.text = _phrases[_curPhrase];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == Tags.Player)
        {
            _canvas.enabled = false;
            _curPhrase = (_curPhrase + 1) % _phrases.Count;
        }
    }
}
