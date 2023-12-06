using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public Heart instance;
    [SerializeField] private float RotationSpeed = 60f;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.HP += 10;
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
    }
}
