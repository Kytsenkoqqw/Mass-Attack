using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

public class AxeAttack : MonoBehaviour, IDamageGiver
{
    public float Damage { get; }
    public float rotationSpeed = 30f;
    public float Radius = 5.0f;
    private float BaseAngle = 30f;
    private float _angle = 0.0f;

    private void Update()
    {
        RotateAxe();
    }

    private void RotateAxe()
    {
        // Увеличиваем угол для вращения.
        _angle += rotationSpeed * Time.deltaTime;

        // Вычисляем новую позицию сферы вокруг героя.
        float x = PlayerController.instance.transform.position.x + Mathf.Cos(_angle + BaseAngle) * Radius;
        float z = PlayerController.instance.transform.position.z + Mathf.Sin(_angle + BaseAngle) * Radius;

        // Устанавливаем новую позицию сферы.
        transform.position = new Vector3(x, transform.position.y, z);
    }

    
}
