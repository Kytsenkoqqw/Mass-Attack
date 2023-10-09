using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class FireBall : MonoBehaviour
    {
        public GameObject fireballPrefab;
        public Transform fireballSpawnPoint;
        public float fireballSpeed;
        //public float fireRate = 1.0f; 
        //private float lastFireTime = 0.0f;
        private bool canShoot = true;
        void Update()
        {
            StartCoroutine(ShootDelay());
        }

        void ShootFireball()
        {
            if (canShoot)
            {
                GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
                Rigidbody rb = fireball.GetComponent<Rigidbody>();
                rb.velocity = transform.forward * fireballSpeed;
            }
        }

        private IEnumerator ShootDelay()
        {
            if (canShoot)
            {
                ShootFireball();
                canShoot = false;
                yield return new WaitForSeconds(1f);
                canShoot = true;
            }
        }
    }
