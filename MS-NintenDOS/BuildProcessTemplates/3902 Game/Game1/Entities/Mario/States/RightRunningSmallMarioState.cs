using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightRunningSmallMarioState : MarioState
    {
        public RightRunningSmallMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightRunningSmallMarioSprite());
        }

        public override void RunLeft()
        {
            Mario.MarioState = new RightFacingSmallMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));
        }
        public override void RunRight()
        {
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));
        }

        public override void SetToFire()
        {
            Mario.MarioState = new RightRunningSmallToFireMarioState(Mario);
        }

        public override void SetToBig()
        {
            Mario.MarioState = new RightRunningSmallToBigMarioState(Mario);
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
        public override void Stand()
        {
            Mario.MarioState = new RightFacingSmallMarioState(Mario);
            Mario.PhysicsEngine.ForceCancel(false);
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