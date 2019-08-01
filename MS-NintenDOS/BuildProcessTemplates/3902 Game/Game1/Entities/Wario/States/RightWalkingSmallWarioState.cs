using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightWalkingSmallWarioState : WarioState
    {
        public RightWalkingSmallWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightWalkingSmallWarioSprite());
        }

        public override void RunLeft()
        {
            Wario.MarioState = new RightFacingSmallWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0));
        }
        public override void RunRight()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));
        }

        public override void SetToFire()
        {
            Wario.MarioState = new RightWalkingSmallToVikingWarioState(Wario);
        }

        public override void SetToBig()
        {
            Wario.MarioState = new RightWalkingSmallToHunterWarioState(Wario);
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
        public override void Stand()
        {
            Wario.MarioState = new RightFacingSmallWarioState(Wario);
            Wario.PhysicsEngine.ForceCancel(false);
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