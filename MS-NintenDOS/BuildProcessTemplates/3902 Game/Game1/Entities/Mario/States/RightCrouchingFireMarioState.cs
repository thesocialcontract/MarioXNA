using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    class RightCrouchingFireMarioState : MarioState
    {
        public RightCrouchingFireMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightCrouchingFireMarioSprite());
        }

        public override void SetToBig()
        {
            Mario.MarioState = new RightCrouchingBigMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new RightFacingSmallMarioState(Mario);
        }

        public override void Jump()
        {
            Mario.MarioState = new RightFacingFireMarioState(Mario);
        }
        public override void Stand()
        {
            Mario.MarioState = new RightFacingFireMarioState(Mario);
        }

        public override void TakeDamage()
        {
            Mario.MarioState = new RightCrouchingFireToSmallMarioState(Mario);
        }

        public override void SpecialAbility()
        {
            Fireball fireball = Mario.FireballFactory.CreateFireball();
            if (fireball != null)
            {
                MarioAudioManager.PlaySfxFireball();
                fireball.SetDirection(true);
                World.Instance.AddEntity(fireball);
            }
        }
        public override void RunLeft()
        {
            Mario.MarioState = new LeftCrouchingFireMarioState(Mario);
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningFireMarioState(Mario);
        }
    }
}
