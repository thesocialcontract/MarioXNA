using Game1.Rendering;

namespace Game1.Entities.Mario.States.Transitions
{
    class RightWalkingHunterToVikingWarioState : WarioState
    {
        private int Timer;
        private ISprite FireSprite { get; set; }
        private ISprite BigSprite { get; set; }
        private bool SpriteSwitcher { get; set; }
        public RightWalkingHunterToVikingWarioState(Wario wario) : base(wario)
        {
            FireSprite = WarioSpriteFactory.Instance.CreateRightWalkingVikingWarioSprite();
            BigSprite = WarioSpriteFactory.Instance.CreateRightWalkingHunterWarioSprite();
            base.SetSprite(BigSprite);
            SpriteSwitcher = false;
            Timer = 50;
        }
        public override void TakeDamage()
        {

        }
        public override void Update()
        {

            Timer--;
            if (Timer <= 0)
            {
                Wario.PhysicsEngine.SetPauseState(false);
                Wario.MarioState = new RightFacingVikingWarioState(Wario);
                
            }
            SpriteSwitcher = Timer % 5 == 0;
            if (SpriteSwitcher)
            {
                base.SetSprite(BigSprite);
            }
            else
            {
                base.SetSprite(FireSprite);
            }
            base.Sprite.Update();
            Collider = ColliderFactory.Instance.CreateCollider("BigWario", Wario);
        }
    }
}
