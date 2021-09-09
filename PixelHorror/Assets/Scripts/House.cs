using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Floor
{
    public SpriteMask FloorMask;
    public GameObject[] Objects;
}

public class House : MonoBehaviour
{
    [SerializeField]
    private Floor[] floors;

    private int currentActiveIndex=0;


    private void SetActiveObjects(int index, bool boolVal)
    {
        foreach (GameObject obj in floors[index].Objects)
        {
            obj?.SetActive(boolVal);
        }
    }

    private void ActivateFloor(int index)
    {
        currentActiveIndex = index;
        SetActiveObjects(index, true);
        if(floors[index].FloorMask)
        floors[index].FloorMask.enabled = true;
    }

    private void DeactivateFloor(int index)
    {
        SetActiveObjects(index, false);
        if(floors[index].FloorMask)
        floors[index].FloorMask.enabled = false;
    }

    public void ChangeFloor(int index)
    {
        if (index == currentActiveIndex) return;
        if (floors.Length>index)
        {
            DeactivateFloor(currentActiveIndex);
            ActivateFloor(index);
        }
    }

    public void DeactivateAllFloors()
    {

    }
}
