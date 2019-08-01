using Game1.Rendering;

namespace Game1.Entities.Mario.States.Transitions
{
    class LeftCrouchingBigToFireMarioState : MarioState
    {
        private int Timer;
        private ISprite FireSprite { get; set; }
        private ISprite BigSprite { get; set; }
        private bool SpriteSwitcher { get; set; }
        public LeftCrouchingBigToFireMarioState(Mario mario) : base(mario)
        {
            FireSprite = MarioSpriteFactory.Instance.CreateLeftCrouchingFireMarioSprite();
            BigSprite = MarioSpriteFactory.Instance.CreateLeftCrouchingBigMarioSprite();
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
                Mario.MarioState = new LeftCrouchingFireMarioState(Mario);
                Mario.PhysicsEngine.SetPauseState(false);
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
            Collider = ColliderFactory.Instance.CreateCollider("BigMario", Mario);
        }
    }
}
