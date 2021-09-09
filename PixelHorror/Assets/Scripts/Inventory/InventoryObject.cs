using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombineResults
{
    public ItemObject Item1;
    public ItemObject Item2;
    public ItemObject result;
}
public class Tuple<T1, T2>
{
    private T1 _Item1;
    private T2 _Item2;
    public T1 Item1 { get=>_Item1;}
    public T2 Item2 { get => _Item2;}

    public Tuple(T1 item1, T2 item2)
    {
        _Item1 = item1;
        _Item2 = item2;
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int ammount;



    public InventorySlot( ItemObject _Item, int _ammount)
    {
        item=_Item;
        ammount = _ammount;
    }

    public void AddAmmount(int _ammount)
    {
        ammount += ammount;
    }
}

[CreateAssetMenu(fileName ="New Inventory",menuName = "Inventory System / Inventory")]
public class InventoryObject : ScriptableObject
{
    [SerializeField]
    private List<ItemObject> myItems= new List<ItemObject>();
    [SerializeField]
    private int maxSlots;

    [SerializeField]
    private CombineResults[] combinationResults;

    private Dictionary<Tuple<ItemObject,ItemObject>, ItemObject> combinationBook = new Dictionary<Tuple<ItemObject, ItemObject>, ItemObject>();

    private void Awake()
    {
        foreach(CombineResults combine in combinationResults)
        {
            combinationBook.Add(new Tuple<ItemObject, ItemObject>( combine.Item1,  combine.Item2), combine.result);
        }
    }

    public void Combine(ItemObject item1,ItemObject item2)
    {

        if((item1.Combinable && item2.Combinable) && (item2.Type==item1.Type) )
        {
            if (item1.Type == ItemType.Ammo)
            {
                int newAm = item1.CurrentAmmount + item2.CurrentAmmount;
                int excess = Mathf.Clamp(item1.MaxAmmount-newAm,0,int.MaxValue);
                newAm -= excess;
                item1.CurrentAmmount = newAm;
                if (excess > 0)
                {
                    item2.CurrentAmmount = excess;
                }
                else
                {
                    //Destroy item 2
                }
            }
            else
            {
                if (combinationBook.TryGetValue(new Tuple<ItemObject, ItemObject>(item1, item2), out ItemObject value))
                {
                    //Spawn object and vanish the 2
                }
                else
                {
                    if (combinationBook.TryGetValue(new Tuple<ItemObject, ItemObject>(item2, item1), out ItemObject _value))
                    {
                        //Spawn object and vanish the 2
                    }
                }
            }
            
        }
    }
}
