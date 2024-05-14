using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _prefab;


    public string Name => _name;
    public Sprite Icon => _icon;
    public GameObject Prefab => _prefab;
}
