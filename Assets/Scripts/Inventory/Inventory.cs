using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Transform slotsParent; 
    public GameObject slotPrefab; 
    public List<Item> items = new List<Item>();

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        gameObject.SetActive(false);
        if (slotsParent == null)
        {
            GameObject defaultParent = new GameObject("SlotsParent");
            slotsParent = defaultParent.transform;
        }
        
        foreach (Item item in items)
        {
            AddItem(item);
        }
    }
    
    public void AddItem(Item item)
    {
        GameObject slot = Instantiate(slotPrefab, slotsParent);
        UpdateSlot(slot, item);
    }

    private void UpdateSlot(GameObject slot, Item item)
    {
        Image slotImage = slot.GetComponent<Image>();
        if (slotImage != null)
        {
            slotImage.sprite = item.icon; 
        }
    }
}



