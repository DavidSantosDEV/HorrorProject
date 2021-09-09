using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletType{

}


[CreateAssetMenu(fileName = "New Ammo Object", menuName = "Inventory System/Items/Ammo")]
public class AmmoObject : ItemObject
{
    [SerializeField]
    protected int numberOfBullets;
    [SerializeField]
    protected BulletType typeOfBullet;

    private void Awake()
    {
        type = ItemType.Ammo;
    }
}
