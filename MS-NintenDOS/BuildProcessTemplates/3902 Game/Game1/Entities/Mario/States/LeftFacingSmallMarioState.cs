using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftFacingSmallMarioState : MarioState
    {
        public LeftFacingSmallMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftFacingSmallMarioSprite());
        }

        public override void RunLeft()
        {
            Mario.MarioState = new LeftRunningSmallMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));

        }

        public override void RunRight()
        {
            Mario.MarioState = new RightFacingSmallMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));

        }

        public override void SetToFire()
        {
            Mario.MarioState = new LeftFacingSmallToFireMarioState(Mario);
        }

        public override void SetToBig()
        {
            Mario.MarioState = new LeftFacingSmallToBigMarioState(Mario);
        }

        public override void Jump()
        {
            if ((!Mario.JumpButtonReleased) && (!Mario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpSmall();
                Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
                Mario.MarioState = new LeftJumpingSmallMarioState(Mario);
            }
        }

        public override void Die()
        {
            Mario.MarioState = new DeadMarioState(Mario);
        }
        public override void EnemyJump()
        {
            Mario.PhysicsEngine.ForceCancel(true);
            Mario.SetEndUpwardForce(false);
            Mario.MarioState = new LeftJumpingSmallMarioState(Mario, 15);
            Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningSmallMarioState(Mario);
        }
    }
}