using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFireBall : MonoBehaviour
{
    private bool _firsDie= false;
    private void Start()
    {
        StartCoroutine(FirstDieFireBall());
    }

    private void Update()
    {
        StartCoroutine(TimeDieFireBall());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Pizda");
        }
    }

    IEnumerator TimeDieFireBall()
    {
        if (_firsDie == true)
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject); 
        }
    }

    IEnumerator FirstDieFireBall()
    {
        yield return  new WaitForSeconds(4f);
        Destroy(gameObject);
        _firsDie = true;
    }
}
