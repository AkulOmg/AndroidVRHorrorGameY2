using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//Where the inventory data is saved (save paths)
[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    // Adds to the Inventory UI showing the item in the canvas and updates the number of items shown.
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject item_, int amount_)
    {
        bool hasItem = false;
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == item_)
            {
                Container[i].AddAmount(amount_);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            Container.Add(new InventorySlot(item_, amount_));
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject item_, int amount_)
    {
        item = item_;
        amount = amount_;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}


