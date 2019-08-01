using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftCrouchWalkingHunterWarioState : WarioState
    {
        public LeftCrouchWalkingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftCrouchWalkingHunterWarioSprite());
        }
        public override void RunRight()
        {
            Wario.MarioState = new LeftCrouchingHunterWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));
        }

        public override void RunLeft()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2((-Wario.MoveIncrement+1f), 0));

        }

        public override void SetToFire()
        {
            Wario.MarioState = new LeftWalkingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new LeftWalkingSmallWarioState(Wario);
        }

        public override void Jump()
        {

            Wario.MarioState = new LeftWalkingHunterWarioState(Wario);

        }

        public override void Crouch() { }
        public override void Stand()
        {
            Wario.MarioState = new LeftCrouchingHunterWarioState(Wario);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new LeftWalkingHunterToSmallWarioState(Wario);
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new LeftJumpingHunterWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningHunterWarioState(Wario);
        }
    }
}