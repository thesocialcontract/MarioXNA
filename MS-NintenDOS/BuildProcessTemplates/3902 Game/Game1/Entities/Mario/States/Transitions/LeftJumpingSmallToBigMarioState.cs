using Game1.Rendering;

namespace Game1.Entities.Mario.States.Transitions
{
    class LeftJumpingSmallToBigMarioState: MarioState
    {
        private int Timer;
        private ISprite SmallSprite { get; set; }
        private ISprite BigSprite { get; set; }
        private bool SpriteSwitcher { get; set; }
        public LeftJumpingSmallToBigMarioState(Mario mario) : base(mario)
        {
            SmallSprite = MarioSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite();
            BigSprite = MarioSpriteFactory.Instance.CreateLeftJumpingBigMarioSprite();
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
                Mario.MarioState = new LeftJumpingBigMarioState(Mario);
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
            Collider = ColliderFactory.Instance.CreateCollider("SmallMario", Mario);
            base.Sprite.Update();
        }
    }
}
