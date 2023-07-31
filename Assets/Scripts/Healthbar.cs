using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public static float HP = 100f;
    public Image hpBar;
  
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HP -= 10;
        }
        else if (collision.gameObject.tag == "Player")
        {
            HP += 10;
            Destroy(gameObject);
        }

        HP = Mathf.Clamp(HP, 0, 100);
        hpBar.fillAmount = HP / 100;
    }
}
