using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftRunningSmallMarioState : MarioState
    {
        public LeftRunningSmallMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftRunningSmallMarioSprite());
        }

        public override void RunRight()
        {
            Mario.MarioState = new LeftFacingSmallMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0f));
        }
        public override void RunLeft()
        {
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0f));
        }

        public override void SetToFire()
        {
            Mario.MarioState = new LeftRunningSmallToFireMarioState(Mario);
        }

        public override void SetToBig()
        {
            Mario.MarioState = new LeftRunningSmallToBigMarioState(Mario);
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

        public override void Stand()
        {
            Mario.MarioState = new LeftFacingSmallMarioState(Mario);
            Mario.PhysicsEngine.ForceCancel(false);
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