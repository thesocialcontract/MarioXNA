using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    public class RightWalkingVikingWarioState : WarioState
    {
        public RightWalkingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightWalkingVikingWarioSprite());
        }

        public override void RunLeft()
        {
            Wario.MarioState = new RightFacingVikingWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0));
        }
        public override void RunRight()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));
        }

        public override void SetToFire()
        {
            Wario.MarioState = new RightWalkingVikingWarioState(Wario);
        }

        public override void SetToBig()
        {
            Wario.MarioState = new RightWalkingVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightWalkingSmallWarioState(Wario);
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
        public override void Stand()
        {
            Wario.MarioState = new RightFacingVikingWarioState(Wario);
            Wario.PhysicsEngine.ForceCancel(false);
        }

        public override void TakeDamage()
        {
            Wario.MarioState = new RightWalkingVikingToSmallWarioState(Wario);
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