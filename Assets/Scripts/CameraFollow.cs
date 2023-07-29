using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 2f, -5f); 

   

    private void LateUpdate()
    {
        if (target != null)
        {
          
            Vector3 newPosition = target.position + offset;

          
            transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * 5f);
        }
    }
}
