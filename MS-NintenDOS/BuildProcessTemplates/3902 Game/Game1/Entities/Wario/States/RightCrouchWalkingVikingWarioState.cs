using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightCrouchWalkingVikingWarioState : WarioState
    {
        public RightCrouchWalkingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightCrouchWalkingVikingWarioSprite());
        }
        public override void RunRight()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2((Wario.MoveIncrement-0.5f), 0));
        }

        public override void RunLeft()
        {
            Wario.MarioState = new LeftCrouchingVikingWarioState(Wario);

        }

        public override void SetToFire()
        {
            
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightWalkingSmallWarioState(Wario);
        }

        public override void Jump()
        {
            Wario.MarioState = new RightWalkingVikingWarioState(Wario);
        }

        public override void Crouch(){ }
        public override void Stand()
        {
            Wario.MarioState = new RightCrouchingVikingWarioState(Wario);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new RightWalkingVikingToSmallWarioState(Wario);
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
            Wario.MarioState = new RightWinningVikingWarioState(Wario);
        }
    }
}