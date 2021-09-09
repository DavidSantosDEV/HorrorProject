using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Key,
    Heal,
    Ammo,
    Weapon,
    Default
}

public enum CombinationType
{
    Add,
    Upgrade,
    Default
}

public abstract class ItemObject : ScriptableObject
{
    [Header("Basic Item Settings",order = 0)]
    [SerializeField]
    protected GameObject prefab;
    [SerializeField]
    protected ItemType type;
    [SerializeField]
    protected string itemName;
    [SerializeField][TextArea(15, 20)]
    protected string description;
    [SerializeField]
    protected int maxAmmount;
    [SerializeField]
    protected bool combinable;

    protected int currentAmmount;

    public GameObject Prefab=>prefab;
    public ItemType Type => type;
    public string ItemName => itemName;
    public string Description => description;
    public int MaxAmmount => maxAmmount;
    public int CurrentAmmount {
        get => currentAmmount;
        set => currentAmmount = value;
    }
    
    public bool Combinable => combinable;

    public void Delete()
    {
        Destroy(this);
    }

}
