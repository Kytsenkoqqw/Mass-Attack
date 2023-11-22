using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropController : MonoBehaviour
{
    public GameObject[] dropItems; // Массив префабов предметов
    public float dropRate = 0.5f; // Вероятность выпадения предмета (от 0 до 1)

    private void OnEnable()
    {
        // Подписываемся на событие при смерти врага
        Enemy.OnEnemyDeath += HandleEnemyDeath;
    }

    private void OnDisable()
    {
        // Отписываемся от события при выключении объекта
        Enemy.OnEnemyDeath -= HandleEnemyDeath;
    }

    private void HandleEnemyDeath(GameObject enemy)
    {
        // Проверяем выпадение предмета по вероятности
        if (Random.value <= dropRate)
        {
            DropItem(enemy.transform.position);
        }
    }

    private void DropItem(Vector3 position)
    {
        // Выбираем случайный предмет из массива
        int randomIndex = Random.Range(0, dropItems.Length);
        GameObject itemPrefab = dropItems[randomIndex];

        // Создаем экземпляр предмета
        GameObject newItem = Instantiate(itemPrefab, position, Quaternion.identity);

        // Можно добавить дополнительные действия для нового предмета, например, запустить анимацию и т.д.
    }
}
