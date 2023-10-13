using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaSphereShooter : Weapon <ManaSphere>
{
    public static ManaSphereShooter instance;

    protected override float DelayShoot { get; set; } = 0.5f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    
}
