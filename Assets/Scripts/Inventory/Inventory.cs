using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public Transform slotsParent; // Родительский объект для слотов в интерфейсе
    public GameObject slotPrefab; // Префаб слота в интерфейсе

    private void Start()
    {
        CreateSlots();
    }

    private void CreateSlots()
    {
        for (int i = 0; i < items.Count; i++)
        {
            GameObject slot = Instantiate(slotPrefab, slotsParent);
            UpdateSlot(slot, items[i]);
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        GameObject slot = Instantiate(slotPrefab, slotsParent);
        UpdateSlot(slot, item);
    }

    private void UpdateSlot(GameObject slot, Item item)
    {
        Image slotImage = slot.GetComponent<Image>();
        if (slotImage != null)
        {
            slotImage.sprite = item.Icon; // Предполагается, что у Item есть свойство icon
        }

        // Дополните этот метод, чтобы обрабатывать другие аспекты предмета в слоте, например, текстовые метки и дополнительные данные
    }
}



