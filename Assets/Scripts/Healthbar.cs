using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    private float HP = 100f;
    public Image Border;
  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HP -= 5;
            Border.fillAmount = HP / 100; 
        }
    }   
}
