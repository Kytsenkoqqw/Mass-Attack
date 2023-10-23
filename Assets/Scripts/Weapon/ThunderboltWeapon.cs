using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Weapon;

public class ThunderboltWeapon : MonoBehaviour
{
    public float radius = 10.0f; // Радиус падения молнии
    public float height = 50.0f; // Высота, на которой молния появляется

    public void SpawnAtPosition(Vector3 position)
    {
        // Задайте позицию молнии
        transform.position = new Vector3(position.x, height, position.z);

        // Генерируйте случайные координаты в пределах радиуса
        float randomX = Random.Range(-radius, radius);
        float randomZ = Random.Range(-radius, radius);

        // Добавьте случайные смещения к позиции молнии
        transform.position += new Vector3(randomX, 0, randomZ);
    }
}
