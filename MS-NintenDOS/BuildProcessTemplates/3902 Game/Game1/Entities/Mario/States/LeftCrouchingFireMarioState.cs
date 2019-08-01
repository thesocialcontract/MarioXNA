using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    class LeftCrouchingFireMarioState : MarioState
    {
        public LeftCrouchingFireMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftCrouchingFireMarioSprite());
        }
        
        public override void Jump()
        {
            Mario.MarioState = new LeftFacingFireMarioState(Mario);
        }

        public override void SetToBig()
        {
            Mario.MarioState = new LeftCrouchingBigMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new LeftFacingSmallMarioState(Mario);
        }
        public override void Stand()
        {
            Mario.MarioState = new LeftFacingFireMarioState(Mario);
        }

        public override void TakeDamage()
        {
            Mario.MarioState = new LeftCrouchingFireToSmallMarioState(Mario);
        }
        
        public override void SpecialAbility()
        {
            Fireball fireball = Mario.FireballFactory.CreateFireball();
            if (fireball != null)
            {
                MarioAudioManager.PlaySfxFireball();
                fireball.SetDirection(false);
                World.Instance.AddEntity(fireball);
            }
        }
        public override void RunRight()
        {
            Mario.MarioState = new RightCrouchingFireMarioState(Mario);
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningFireMarioState(Mario);
        }
    }
}
