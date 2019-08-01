using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftCrouchingHunterWarioState : WarioState
    {
        public LeftCrouchingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftCrouchingHunterWarioSprite());
        }
        
        public override void SetToFire()
        {
            Wario.MarioState = new LeftCrouchingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new LeftFacingSmallWarioState(Wario);
        }
        public override void RunLeft()
        {
            Wario.MarioState = new LeftCrouchWalkingHunterWarioState(Wario);
        }

        public override void Jump()
        {
            Wario.MarioState = new LeftFacingHunterWarioState(Wario);
        }
        public override void Stand()
        {
            Wario.MarioState = new LeftFacingHunterWarioState(Wario);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new LeftCrouchingHunterToSmallWarioState(Wario);
        }
        public override void RunRight()
        {
            Wario.MarioState = new RightCrouchingHunterWarioState(Wario);
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningHunterWarioState(Wario);
        }
    }
}