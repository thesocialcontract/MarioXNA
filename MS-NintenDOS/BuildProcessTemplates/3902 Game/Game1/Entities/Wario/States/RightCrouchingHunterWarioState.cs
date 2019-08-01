using Game1.Entities.Mario.States.Transitions;
namespace Game1.Entities.Mario.States
{
    class RightCrouchingHunterWarioState : WarioState
    {
        public RightCrouchingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightCrouchingHunterWarioSprite());
        }
        public override void RunRight()
        {
            Wario.MarioState = new RightCrouchWalkingHunterWarioState(Wario);
        }
        public override void SetToFire()
        {
            Wario.MarioState = new RightCrouchingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightFacingSmallWarioState(Wario);
        }

        public override void Jump()
        {
            Wario.MarioState = new RightFacingHunterWarioState(Wario);
        }

        public override void Stand()
        {
            Wario.MarioState = new RightFacingHunterWarioState(Wario);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new RightCrouchingHunterToSmallWarioState(Wario);
        }
        public override void RunLeft()
        {
            Wario.MarioState = new LeftCrouchingHunterWarioState(Wario);
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningHunterWarioState(Wario);
        }
    }
}
