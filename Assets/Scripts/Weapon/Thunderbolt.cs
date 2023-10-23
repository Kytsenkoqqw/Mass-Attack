using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunderbolt : MonoBehaviour
{
    public ThunderboltWeapon ThunderboltPrefab; // Префаб объекта молнии
    public Transform HeroTransform; // Трансформ героя

    private void SpawnThunderbolt()
    {
        // Создайте экземпляр молнии
        ThunderboltWeapon thunderboltPrefab = Instantiate(ThunderboltPrefab);

        // Вызовите метод для настройки позиции молнии
        ThunderboltPrefab.SpawnAtPosition(HeroTransform.position);
    }
}
