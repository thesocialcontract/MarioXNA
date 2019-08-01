using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    class LeftCrouchingVikingWarioState : WarioState
    {
        public LeftCrouchingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftCrouchingVikingWarioSprite());
        }
        
        public override void Jump()
        {
            Wario.MarioState = new LeftFacingVikingWarioState(Wario);
        }

        public override void SetToBig()
        {
            Wario.MarioState = new LeftCrouchingHunterWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new LeftFacingSmallWarioState(Wario);
        }
        public override void Stand()
        {
            Wario.MarioState = new LeftFacingVikingWarioState(Wario);
        }

        public override void TakeDamage()
        {
            Wario.MarioState = new LeftCrouchingVikingToSmallWarioState(Wario);
        }
        
        
        public override void RunRight()
        {
            Wario.MarioState = new RightCrouchingVikingWarioState(Wario);
        }
        public override void RunLeft()
        {
            Wario.MarioState = new LeftCrouchWalkingVikingWarioState(Wario);
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningVikingWarioState(Wario);
        }
    }
}
