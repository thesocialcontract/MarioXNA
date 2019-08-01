using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    public class LeftFacingVikingWarioState : WarioState
    {
        public LeftFacingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftFacingVikingWarioSprite());
        }

        public override void RunLeft()
        {
            Wario.MarioState = new LeftWalkingVikingWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0));
        }

        public override void RunRight()
        {
            Wario.MarioState = new RightFacingVikingWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));
        }
        public override void SetToFire()
        {
            Wario.MarioState = new LeftFacingHunterToVikingWarioState(Wario);
        }

        public override void SetToBig()
        {
            Wario.MarioState = new LeftFacingVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new LeftFacingSmallWarioState(Wario);
        }

        public override void Jump()
        {
            if ((!Wario.JumpButtonReleased) && (!Wario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpBig();
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
                Wario.MarioState = new LeftJumpingVikingWarioState(Wario);
            }
        }

        public override void Crouch()
        {
            Wario.MarioState = new LeftCrouchingVikingWarioState(Wario);
        }

        public override void TakeDamage()
        {
            Wario.MarioState = new LeftFacingVikingToSmallWarioState(Wario);
        }

        public override void SpecialAbility()
        {
            if (!Wario.SingleJump)
            {
                MarioAudioManager.PlaySfxCharge();
                Wario.SingleJump = true;
                Wario.MarioState = new LeftDashingVikingWarioState(Wario);
            }
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new LeftJumpingVikingWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningVikingWarioState(Wario);
        }
    }
}