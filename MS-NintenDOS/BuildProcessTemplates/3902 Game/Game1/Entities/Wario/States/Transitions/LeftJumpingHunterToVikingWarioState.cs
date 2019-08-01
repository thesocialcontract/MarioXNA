using Game1.Rendering;

namespace Game1.Entities.Mario.States.Transitions
{
    class LeftJumpingHunterToVikingWarioState : WarioState
    {
        private int Timer;
        private ISprite FireSprite { get; set; }
        private ISprite BigSprite { get; set; }
        private bool SpriteSwitcher { get; set; }
        public LeftJumpingHunterToVikingWarioState(Wario wario) : base(wario)
        {
            FireSprite = WarioSpriteFactory.Instance.CreateLeftJumpingVikingWarioSprite();
            BigSprite = WarioSpriteFactory.Instance.CreateLeftJumpingHunterWarioSprite();
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
                Wario.MarioState = new LeftJumpingVikingWarioState(Wario);
                
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
