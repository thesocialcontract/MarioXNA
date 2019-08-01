using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftFacingSmallWarioState : WarioState
    {
        public LeftFacingSmallWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftFacingSmallWarioSprite());
        }

        public override void RunLeft()
        {
            Wario.MarioState = new LeftWalkingSmallWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0));

        }

        public override void RunRight()
        {
            Wario.MarioState = new RightFacingSmallWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));

        }

        public override void SetToFire()
        {
            Wario.MarioState = new LeftFacingSmallToVikingWarioState(Wario);
        }

        public override void SetToBig()
        {
            Wario.MarioState = new LeftFacingSmallToHunterWarioState(Wario);
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

        public override void Die()
        {
            Wario.MarioState = new DeadWarioState(Wario);
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