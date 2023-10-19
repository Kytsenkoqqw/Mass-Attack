namespace Weapon
{
    public class PoisonSphereWeapon : Weapon<PoisonSphere>
    {

        public override WeaponType Type => WeaponType.Poison;
        protected override float DefaultDamage => 30f;
        protected override float DelayShoot { get; set; } = 2f;
        
    }
}
