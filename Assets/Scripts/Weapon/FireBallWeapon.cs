    public class FireBallWeapon : Weapon <FireBall>
    {
        public static FireBallWeapon instance;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }
    }
