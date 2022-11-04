using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<Key> KeysInInventory = new List<Key>();

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider collision)
    {
        Key possiblyKey = collision.GetComponent<Key>();

        if (possiblyKey != null)
        {
            KeysInInventory.Add(possiblyKey);

            possiblyKey.gameObject.SetActive(false);
        }
    }


}
