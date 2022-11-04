using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Player Inventory Script (Collect items)

public class Player : MonoBehaviour
{
    public InventoryObject inventory;

    //object added to inventory is destroyed after being added 
    private void OnTriggerEnter3D(Collider collision)
    {
        var item = collision.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(collision.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        /*inventory.Container.Clear();*/
    }

    // calls on the save / load script  to execute
    /*public void SavePlayer()
    {
        SaveGame.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveGame.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;
    }*/
}
