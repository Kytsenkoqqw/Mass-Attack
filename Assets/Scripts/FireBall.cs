using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class FireBall : MonoBehaviour
    {
        public GameObject fireballPrefab;
        public Transform fireballSpawnPoint;
        public float fireballSpeed;
        private bool canShoot = true;
        public float detectionRadius = 10f;
        private Transform target;
        
        
        void Update()
        {
            if (target != null)
            {
                StartCoroutine(ShootDelay());
            }
            
            Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.CompareTag("Enemy"))
                {
                    target = collider.transform;
                    break; 
                }
            }
        }

        void ShootFireball()
        {
            if (canShoot)
            {
                GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
                Rigidbody rb = fireball.GetComponent<Rigidbody>();
                rb.velocity = (target.position - fireballSpawnPoint.position).normalized * fireballSpeed;
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
