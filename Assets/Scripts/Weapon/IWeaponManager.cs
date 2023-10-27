using System.Collections.Generic;

namespace Weapon
{
    public interface IWeaponManager
    {
        public IReadOnlyList<IWeapon> Weapons { get; }
        public IReadOnlyList<IWeapon> ActiveWeapons { get; }
        public IWeapon GetWeapon(WeaponType type);
        
        

    }
}