namespace Weapon
{
    public class ManaSphereWeapon : Weapon <ManaSphere>
    {
        public override WeaponType Type => WeaponType.Mana;
        protected override float DelayShoot { get; set; } = 0.5f;
        
    }
}
