using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightCrouchWalkingHunterWarioState : WarioState
    {
        public RightCrouchWalkingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightCrouchWalkingHunterWarioSprite());
        }
        public override void RunRight()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2((Wario.MoveIncrement-0.5f), 0));
        }

        public override void RunLeft()
        {
            Wario.MarioState = new LeftCrouchingHunterWarioState(Wario);

        }

        public override void SetToFire()
        {
            Wario.MarioState = new RightWalkingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightWalkingSmallWarioState(Wario);
        }

        public override void Jump()
        {
            Wario.MarioState = new RightWalkingHunterWarioState(Wario);
        }

        public override void Crouch(){ }
        public override void Stand()
        {
            Wario.MarioState = new RightCrouchingHunterWarioState(Wario);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new RightWalkingHunterToSmallWarioState(Wario);
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new RightJumpingHunterWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new RightWinningHunterWarioState(Wario);
        }
    }
}