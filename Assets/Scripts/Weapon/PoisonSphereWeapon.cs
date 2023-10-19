using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonSphereWeapon : Weapon<PoisonSphere>
{
    public static PoisonSphereWeapon instance;
    protected override float DefaultDamage => 30f;

    protected override float DelayShoot { get; set; } = 2f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

}
