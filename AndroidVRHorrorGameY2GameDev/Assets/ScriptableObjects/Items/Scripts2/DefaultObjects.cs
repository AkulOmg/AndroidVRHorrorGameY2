using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Part of inventory set up
[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Default")]
public class DefaultObjects : ItemObject
{
    public void Awake()
    {
        type = ItemType.Default;
    }
}