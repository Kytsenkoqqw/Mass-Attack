namespace Weapon
{
    public class ManaSphereBulletWeapon : BulletWeapon <ManaSphere>
    {
        public override WeaponType Type => WeaponType.Mana;
        protected override float DelayShoot { get; set; } = 0.5f;
    }
}
