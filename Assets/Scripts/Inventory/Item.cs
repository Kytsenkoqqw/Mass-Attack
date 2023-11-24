using System.Collections;
using System.Collections.Generic;
using ItemSkills;
using UnityEngine;

public class Item : MonoBehaviour
{
   
    public Sprite icon;
    public ItemSpell spell;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.instance.AddItem(this);
            gameObject.SetActive(false);
        }
    }
}
