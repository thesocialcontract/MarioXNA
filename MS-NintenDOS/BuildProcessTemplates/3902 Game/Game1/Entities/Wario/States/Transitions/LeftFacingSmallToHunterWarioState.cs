﻿using Game1.Rendering;

namespace Game1.Entities.Mario.States.Transitions
{
    class LeftFacingSmallToHunterWarioState : WarioState
    {
        private int Timer;
        private ISprite SmallSprite { get; set; }
        private ISprite BigSprite { get; set; }
        private bool SpriteSwitcher { get; set; }
        public LeftFacingSmallToHunterWarioState(Wario wario) : base(wario)
        {
            SmallSprite = WarioSpriteFactory.Instance.CreateLeftFacingSmallWarioSprite();
            BigSprite = WarioSpriteFactory.Instance.CreateLeftFacingHunterWarioSprite();
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
            if( Timer <= 0)
            {
                Wario.PhysicsEngine.SetPauseState(false);
                Wario.MarioState = new LeftFacingHunterWarioState(Wario);
               
            }
            SpriteSwitcher = Timer % 5 == 0;
            if(SpriteSwitcher)
            {
                base.SetSprite(BigSprite);
            } 
            else
            {
                base.SetSprite(SmallSprite);
            }
            base.Sprite.Update();
            Collider = ColliderFactory.Instance.CreateCollider("SmallWario", Wario);
        }
    }
}
