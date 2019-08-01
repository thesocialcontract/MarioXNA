using Game1.Rendering;

namespace Game1.Entities.Mario.States.Transitions
{
    class RightJumpingSmallToBigMarioState : MarioState
    {
        private int Timer;
        private ISprite SmallSprite { get; set; }
        private ISprite BigSprite { get; set; }
        private bool SpriteSwitcher { get; set; }
        public RightJumpingSmallToBigMarioState(Mario mario) : base(mario)
        {
            SmallSprite = MarioSpriteFactory.Instance.CreateRightJumpingSmallMarioSprite();
            BigSprite = MarioSpriteFactory.Instance.CreateRightJumpingBigMarioSprite();
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
                Mario.MarioState = new RightJumpingBigMarioState(Mario);
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
            Collider = ColliderFactory.Instance.CreateCollider("SmallMario", Mario);
        }
    }
    
}
