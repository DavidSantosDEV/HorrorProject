using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSwitcher : MonoBehaviour
{
    [SerializeField]
    private House mainHouse=null;
    [SerializeField]
    private int floor = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mainHouse?.ChangeFloor(floor);
    }
}
