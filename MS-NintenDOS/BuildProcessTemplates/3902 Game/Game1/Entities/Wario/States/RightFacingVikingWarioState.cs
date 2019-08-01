using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    public class RightFacingVikingWarioState : WarioState
    {
        public RightFacingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightFacingVikingWarioSprite());
        }

        public override void RunLeft()
        {
            Wario.MarioState = new LeftFacingVikingWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0));
        }

        public override void RunRight()
        {
            Wario.MarioState = new RightWalkingVikingWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));
        }

        public override void SetToBig()
        {
            Wario.MarioState = new RightFacingHunterWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightFacingSmallWarioState(Wario);
        }
        public override void SetToFire()
        {
            Wario.MarioState = new RightFacingHunterToVikingWarioState(Wario);
        }

        public override void Jump()
        {
            if ((!Wario.JumpButtonReleased) && (!Wario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpBig();
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
                Wario.MarioState = new RightJumpingVikingWarioState(Wario);
            }
        }

        public override void Crouch()
        {
            Wario.MarioState = new RightCrouchingVikingWarioState(Wario);
        }

        public override void TakeDamage()
        {
            Wario.MarioState = new RightFacingVikingToSmallWarioState(Wario);
        }

        public override void SpecialAbility()
        {
            if (!Wario.SingleJump)
            {
                MarioAudioManager.PlaySfxCharge();
                Wario.SingleJump = true;
                Wario.MarioState = new RightDashingVikingWarioState(Wario);
            }
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new RightJumpingVikingWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningVikingWarioState(Wario);
        }
    }
}