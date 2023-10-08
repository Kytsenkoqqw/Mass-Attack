using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //[SerializeField] private GameObject FireBallPrefab;
    //private GameObject _fireBall;
    //public float speed; 
    
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;
    public float fireballSpeed;
    public float damage = 1;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        // Создаем огненный шар из префаба
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
    
        // Добавляем скорость движения огненному шару (может потребоваться настроить скорость)
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * fireballSpeed;
    }


}
