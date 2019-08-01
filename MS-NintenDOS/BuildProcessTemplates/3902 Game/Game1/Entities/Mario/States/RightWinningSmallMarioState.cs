using System;

namespace Game1.Entities.Mario.States
{
    class RightWinningSmallMarioState : MarioState
    {
        public RightWinningSmallMarioState(Mario mario) : base(mario)
        {
            
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightWinningSmallMarioSprite());
            
        }
        public override void RunRight()
        {
            
            Mario.MarioState = new RightRunningSmallMarioState(Mario);

        }
        public override void Update()
        {
            
            base.Update();
        }

    }
}