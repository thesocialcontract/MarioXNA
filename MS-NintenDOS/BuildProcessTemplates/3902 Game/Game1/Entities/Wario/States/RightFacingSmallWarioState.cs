using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightFacingSmallWarioState : WarioState
    {
        public RightFacingSmallWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightFacingSmallWarioSprite());
            
        }
        public override void RunLeft()
        {
            Wario.MarioState = new LeftFacingSmallWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0));
        }

        public override void RunRight()
        {
            Wario.MarioState = new RightWalkingSmallWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));
        }

        public override void SetToFire()
        {
            Wario.MarioState = new RightFacingSmallToVikingWarioState(Wario);
        }

        public override void SetToBig()
        {
            Wario.MarioState = new RightFacingSmallToHunterWarioState(Wario);
        }

        public override void Jump()
        {
            if ((!Wario.JumpButtonReleased) && (!Wario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpSmall();
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
                Wario.MarioState = new RightJumpingSmallWarioState(Wario);
            }
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new RightJumpingSmallWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningSmallWarioState(Wario);
        }
    }
}