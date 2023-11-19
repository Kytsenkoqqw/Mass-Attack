using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            Item item = GetComponent<Item>();

            if (inventory != null && item != null)
            {
                inventory.AddItem(item);
            }
        }
    }
}
