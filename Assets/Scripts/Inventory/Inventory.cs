using System;
using System.Collections.Generic;
using ItemSkills;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Transform slotsParent; 
    public ItemSkillsView slotPrefab; 
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
        ItemSkillsView slot = Instantiate(slotPrefab, slotsParent);
        slot.Init(item.icon, ()=>SkillsManager.instance.GetSkill(item.spell));
    }
}



