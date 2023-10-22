using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapon;

public class ExortSphere : MonoBehaviour, IDamageGiver
{
    public Transform Player; // Ссылка на объект героя.
    [SerializeField ]private float rotationSpeed = 30.0f; // Скорость вращения сферы.
    [SerializeField] private float radius = 5.0f; // Радиус вращения вокруг героя.
    private float _angle = 0.0f;
    public float Damage { get; set; }

    private void Update()
    {
        RotateSphere();
    }

    private void RotateSphere()
    {
        // Увеличиваем угол для вращения.
        _angle += rotationSpeed * Time.deltaTime;

        // Вычисляем новую позицию сферы вокруг героя.
        float x = Player.position.x + Mathf.Cos(_angle) * radius;
        float z = Player.position.z + Mathf.Sin(_angle) * radius;

        // Устанавливаем новую позицию сферы.
        transform.position = new Vector3(x, transform.position.y, z);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(Damage);
        }
    }

   
}
