using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftCrouchingBigMarioState : MarioState
    {
        public LeftCrouchingBigMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftCrouchingBigMarioSprite());
        }
        
        public override void SetToFire()
        {
            Mario.MarioState = new LeftCrouchingBigToFireMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new LeftFacingSmallMarioState(Mario);
        }

        public override void Jump()
        {
            Mario.MarioState = new LeftFacingBigMarioState(Mario);
        }
        public override void Stand()
        {
            Mario.MarioState = new LeftFacingBigMarioState(Mario);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Mario.MarioState = new LeftCrouchingBigToSmallMarioState(Mario);
        }
        public override void RunRight()
        {
            Mario.MarioState = new RightCrouchingBigMarioState(Mario);
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningBigMarioState(Mario);
        }
    }
}