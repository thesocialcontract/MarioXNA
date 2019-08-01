using Game1.Rendering;

namespace Game1.Entities.Mario.States.Transitions
{
    class RightRunningBigToSmallMarioState : MarioState
    {
        private int Timer;
        private ISprite SmallSprite { get; set; }
        private ISprite BigSprite { get; set; }
        private bool SpriteSwitcher { get; set; }
        public RightRunningBigToSmallMarioState(Mario mario) : base(mario)
        {
            SmallSprite = MarioSpriteFactory.Instance.CreateRightRunningSmallMarioSprite();
            BigSprite = MarioSpriteFactory.Instance.CreateRightRunningBigMarioSprite();
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
                Mario.MarioState = new RightFacingSmallMarioState(Mario);
                Mario.PhysicsEngine.SetPauseState(false);
            }
            SpriteSwitcher = Timer % 5 == 0;
            if (SpriteSwitcher)
            {
                base.SetSprite(BigSprite);
            }
            else
            {
                base.SetSprite(SmallSprite);
            }
            base.Sprite.Update();
            Collider = ColliderFactory.Instance.CreateCollider("BigMario", Mario);
        }
    }
}
