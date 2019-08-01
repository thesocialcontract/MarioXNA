using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftWalkingSmallWarioState : WarioState
    {
        public LeftWalkingSmallWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftWalkingSmallWarioSprite());
        }

        public override void RunRight()
        {
            Wario.MarioState = new LeftFacingSmallWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0f));
        }
        public override void RunLeft()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0f));
        }

        public override void SetToFire()
        {
            Wario.MarioState = new LeftWalkingSmallToVikingWarioState(Wario);
        }

        public override void SetToBig()
        {
            Wario.MarioState = new LeftWalkingSmallToHunterWarioState(Wario);
        }

        public override void Jump()
        {
            if ((!Wario.JumpButtonReleased) && (!Wario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpSmall();
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
                Wario.MarioState = new LeftJumpingSmallWarioState(Wario);
            }
        }

        public override void Stand()
        {
            Wario.MarioState = new LeftFacingSmallWarioState(Wario);
            Wario.PhysicsEngine.ForceCancel(false);
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new LeftJumpingSmallWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningSmallWarioState(Wario);
        }
    }
}