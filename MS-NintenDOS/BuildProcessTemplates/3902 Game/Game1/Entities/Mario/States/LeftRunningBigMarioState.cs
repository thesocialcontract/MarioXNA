using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftRunningBigMarioState : MarioState
    {
        public LeftRunningBigMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftRunningBigMarioSprite());
        }
        public override void RunRight()
        {
            Mario.MarioState = new LeftFacingBigMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));
        }

        public override void RunLeft()
        {
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));

        }

        public override void SetToFire()
        {
            Mario.MarioState = new LeftRunningBigToFireMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new LeftRunningSmallMarioState(Mario);
        }

        public override void Jump()
        {
            if ((!Mario.JumpButtonReleased) && (!Mario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpBig();
                Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
                Mario.MarioState = new LeftJumpingBigMarioState(Mario);
            }


        }

        public override void Crouch()
        {
            Mario.MarioState = new LeftCrouchingBigMarioState(Mario);
        }
        public override void Stand()
        {
            Mario.MarioState = new LeftFacingBigMarioState(Mario);
            Mario.PhysicsEngine.ForceCancel(false);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Mario.MarioState = new LeftRunningBigToSmallMarioState(Mario);
        }
        public override void EnemyJump()
        {
            Mario.PhysicsEngine.ForceCancel(true);
            Mario.SetEndUpwardForce(false);
            Mario.MarioState = new LeftJumpingBigMarioState(Mario, 15);
            Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningBigMarioState(Mario);
        }
    }
}