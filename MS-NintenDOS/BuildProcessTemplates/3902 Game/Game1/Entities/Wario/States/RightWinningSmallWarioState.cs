using System;

namespace Game1.Entities.Mario.States
{
    class RightWinningSmallWarioState : WarioState
    {
        public RightWinningSmallWarioState(Wario wario) : base(wario)
        {
            
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightWinningSmallWarioSprite());
            
        }
        public override void RunRight()
        {
            
            Wario.MarioState = new RightWalkingSmallWarioState(Wario);

        }
        public override void Update()
        {
            
            base.Update();
        }

    }
}