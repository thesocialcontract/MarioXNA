using Game1.Rendering;

namespace Game1.Entities.Mario.States.Transitions
{
    class RightFacingVikingToSmallWarioState : WarioState
    {
        private int Timer;
        private ISprite FireSprite { get; set; }
        private ISprite SmallSprite { get; set; }
        private bool SpriteSwitcher { get; set; }
        public RightFacingVikingToSmallWarioState(Wario wario) : base(wario)
        {
            FireSprite = WarioSpriteFactory.Instance.CreateRightFacingVikingWarioSprite();
            SmallSprite = WarioSpriteFactory.Instance.CreateRightFacingSmallWarioSprite();
            base.SetSprite(SmallSprite);
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
                Wario.MarioState = new RightFacingSmallWarioState(Wario);
                
            }
            SpriteSwitcher = Timer % 5 == 0;
            if (SpriteSwitcher)
            {
                base.SetSprite(SmallSprite);
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
