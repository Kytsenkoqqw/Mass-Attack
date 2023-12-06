using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BowSpell : MonoBehaviour
{
    public float arrowFallSpeed = 10f;

    void Update()
    {
        // Запускаем стрелу вниз с заданной скоростью.
        transform.Translate(Vector3.down * arrowFallSpeed * Time.deltaTime);

        // Проверяем столкновение стрелы с врагами.
        CheckCollision();
    }

    void CheckCollision()
    {
        // Создаем луч в направлении движения стрелы.
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        // Проверяем столкновение луча с объектами врагов.
        if (Physics.Raycast(ray, out hit, arrowFallSpeed * Time.deltaTime))
        {
            // Если объект врага, уничтожаем стрелу и вызываем метод для обработки попадания.
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(gameObject);
                
            }
        }
    }
}
