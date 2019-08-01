using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightFacingSmallMarioState : MarioState
    {
        public RightFacingSmallMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightFacingSmallMarioSprite());
            
        }
        public override void RunLeft()
        {
            Mario.MarioState = new LeftFacingSmallMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));
        }

        public override void RunRight()
        {
            Mario.MarioState = new RightRunningSmallMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));
        }

        public override void SetToFire()
        {
            Mario.MarioState = new RightFacingSmallToFireMarioState(Mario);
        }

        public override void SetToBig()
        {
            Mario.MarioState = new RightFacingSmallToBigMarioState(Mario);
        }

        public override void Jump()
        {
            if ((!Mario.JumpButtonReleased) && (!Mario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpSmall();
                Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
                Mario.MarioState = new RightJumpingSmallMarioState(Mario);
            }
        }
        public override void EnemyJump()
        {
            Mario.PhysicsEngine.ForceCancel(true);
            Mario.SetEndUpwardForce(false);
            Mario.MarioState = new RightJumpingSmallMarioState(Mario, 15);
            Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningSmallMarioState(Mario);
        }
    }
}