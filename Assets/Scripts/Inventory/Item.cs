using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName; // Название предмета
    public Sprite icon; // Изображение предмета (для отображения в инвентаре)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory.instance.AddItem(this);
            gameObject.SetActive(false); // Скрываем объект предмета после подбора
           
        }
    }
}