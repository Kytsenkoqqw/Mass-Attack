using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

    public class FireBallShooter : Weapon <FireBall>
    {
        public static FireBallShooter instance;
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }
       
    }
