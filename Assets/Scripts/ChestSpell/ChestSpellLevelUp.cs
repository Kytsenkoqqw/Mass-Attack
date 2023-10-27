using System.Collections;
using System.Collections.Generic;
using Extention;
using UnityEngine;
using Weapon;

public class ChestSpellLevelUp : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            var weapons = new List<IWeapon>(WeaponManager.instance.ActiveWeapons); 
            weapons.Shuffle();
            GameManager.instance.ShowChest(weapons[0]);
            weapons[0].LevelUp();
            Destroy(gameObject);
        }
    }
}
