using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightRunningBigMarioState : MarioState
    {
        public RightRunningBigMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightRunningBigMarioSprite());
        }

        public override void RunLeft()
        {
            Mario.MarioState = new RightFacingBigMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));
        }
        public override void RunRight()
        {
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));

        }

        public override void SetToFire()
        {
            Mario.MarioState = new RightRunningBigToFireMarioState(Mario);
        }
        
        public override void SetToSmall()
        {
            Mario.MarioState = new RightRunningSmallMarioState(Mario);
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
        public override void Stand()
        {
            Mario.MarioState = new RightFacingBigMarioState(Mario);
            Mario.PhysicsEngine.ForceCancel(false);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Mario.MarioState = new RightRunningBigToSmallMarioState(Mario);
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