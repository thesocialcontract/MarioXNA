using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    class RightFacingBigMarioState : MarioState
    {
        
        public RightFacingBigMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightFacingBigMarioSprite());
        }
        public override void RunLeft()
        {
            Mario.MarioState = new LeftFacingBigMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));

        }
        public override void RunRight()
        {
            Mario.MarioState = new RightRunningBigMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));


        }
        public override void SetToFire()
        {
            Mario.MarioState = new RightFacingBigToFireMarioState(Mario);
        }
        public override void SetToSmall()
        {
            Mario.MarioState = new RightFacingSmallMarioState(Mario);
        }
        public override void Jump()
        {
            if ((!Mario.JumpButtonReleased) && (!Mario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpBig();
                Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
                Mario.MarioState = new RightJumpingBigMarioState(Mario);
            }
        }
        public override void Crouch()
        {
            Mario.MarioState = new RightCrouchingBigMarioState(Mario);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Mario.MarioState = new RightFacingBigToSmallMarioState(Mario);
        }

        public override void EnemyJump()
        {
            Mario.PhysicsEngine.ForceCancel(true);
            Mario.SetEndUpwardForce(false);
            Mario.MarioState = new RightJumpingBigMarioState(Mario, 15);
            Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningBigMarioState(Mario);
        }
    }
}
