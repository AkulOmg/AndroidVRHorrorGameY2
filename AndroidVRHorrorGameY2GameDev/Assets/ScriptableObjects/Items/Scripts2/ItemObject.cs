using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Default //Type of item type asset that stores in "inventory" that can be created (scriptable object type)
}
public abstract class ItemObject : ScriptableObject
{
    //What is found in inspector of object
    public GameObject prefab;
    public ItemType type;
    [TextArea(15, 20)]
    public string description;
}
