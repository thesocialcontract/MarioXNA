using Game1.Entities.Mario.States.Transitions;
namespace Game1.Entities.Mario.States
{
    class RightCrouchingBigMarioState : MarioState
    {
        public RightCrouchingBigMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightCrouchingBigMarioSprite());
        }

        public override void SetToFire()
        {
            Mario.MarioState = new RightCrouchingBigToFireMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new RightFacingSmallMarioState(Mario);
        }

        public override void Jump()
        {
            Mario.MarioState = new RightFacingBigMarioState(Mario);
        }

        public override void Stand()
        {
            Mario.MarioState = new RightFacingBigMarioState(Mario);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Mario.MarioState = new RightCrouchingBigToSmallMarioState(Mario);
        }
        public override void RunLeft()
        {
            Mario.MarioState = new LeftCrouchingBigMarioState(Mario);
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningBigMarioState(Mario);
        }
    }
}
