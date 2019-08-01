using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightJumpingHunterWarioState : WarioState
    {
        private float Timer;
        public RightJumpingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightJumpingHunterWarioSprite());
            Timer = wario.JumpTime;
        }
        public RightJumpingHunterWarioState(Wario wario, float shortTimer) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightJumpingHunterWarioSprite());
            Timer = shortTimer;
        }

        public override void Update()
        {
            base.Update();
            Timer--;
            if (Timer <= 0)
            {
                Wario.SetEndUpwardForce(true);
                Wario.PhysicsEngine.ForceCancel(true);
            }
        }

        public override void Jump()
        {
            if (!(Wario.JumpButtonReleased))
            {
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
            }
        }
        public override void RunLeft()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0));

        }

        public override void RunRight()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));

        }

        public override void SetToFire()
        {
            Wario.MarioState = new RightJumpingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightJumpingSmallWarioState(Wario, Timer);
        }

        

        

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new RightJumpingHunterToSmallWarioState(Wario);
        }
        public override void Land()
        {
            Wario.MarioState = new RightFacingHunterWarioState(Wario);
            Wario.ConsecutiveBounces = 0;
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
            Wario.MarioState = new LeftWinningHunterWarioState(Wario);
        }
    }
}