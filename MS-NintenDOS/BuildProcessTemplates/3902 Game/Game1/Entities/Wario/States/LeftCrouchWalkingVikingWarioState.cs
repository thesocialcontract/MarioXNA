using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftCrouchWalkingVikingWarioState : WarioState
    {
        public LeftCrouchWalkingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftCrouchWalkingVikingWarioSprite());
        }
        public override void RunRight()
        {
            Wario.MarioState = new LeftCrouchingVikingWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));
        }

        public override void RunLeft()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2((-Wario.MoveIncrement+1f), 0));
            
        }

        public override void SetToFire()
        {
            
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new LeftWalkingSmallWarioState(Wario);
        }

        public override void Jump()
        {

            Wario.MarioState = new LeftWalkingVikingWarioState(Wario);

        }

        public override void Crouch() { }
        public override void Stand()
        {
            Wario.MarioState = new LeftCrouchingVikingWarioState(Wario);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new LeftWalkingVikingToSmallWarioState(Wario);
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