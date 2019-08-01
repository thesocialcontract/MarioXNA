﻿using Game1.Rendering;

namespace Game1.Entities.Mario.States.Transitions
{
    class RightJumpingSmallToFireMarioState : MarioState
    {
        private int Timer;
        private ISprite FireSprite { get; set; }
        private ISprite SmallSprite { get; set; }
        private bool SpriteSwitcher { get; set; }
        public RightJumpingSmallToFireMarioState(Mario mario) : base(mario)
        {
            FireSprite = MarioSpriteFactory.Instance.CreateRightJumpingFireMarioSprite();
            SmallSprite = MarioSpriteFactory.Instance.CreateRightJumpingSmallMarioSprite();
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
                Mario.MarioState = new RightJumpingFireMarioState(Mario);
                Mario.PhysicsEngine.SetPauseState(false);
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
            Collider = ColliderFactory.Instance.CreateCollider("BigMario", Mario);
        }
    }
}
