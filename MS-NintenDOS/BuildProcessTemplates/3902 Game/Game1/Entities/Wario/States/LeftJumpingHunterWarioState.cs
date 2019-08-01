using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    class LeftJumpingHunterWarioState : WarioState
    {
        private float Timer;
        

        public LeftJumpingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftJumpingHunterWarioSprite());
            Timer = wario.JumpTime;
        }

        public LeftJumpingHunterWarioState(Wario wario, float shortTimer) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftJumpingHunterWarioSprite());
            Timer = shortTimer;
        }
        public override void Jump()
        {
            if(!(Wario.JumpButtonReleased))
            {
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
            }
        }
        public override void Update()
        {
            base.Update();
            Timer--;
            if(Timer <= 0)
            {
                Wario.SetEndUpwardForce(true);
                Wario.PhysicsEngine.ForceCancel(true);
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
            Wario.MarioState = new LeftJumpingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new LeftJumpingSmallWarioState(Wario, Timer);
        }

        
        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new LeftJumpingHunterToSmallWarioState(Wario);
        }
        public override void Land()
        {
            Wario.MarioState = new LeftFacingHunterWarioState(Wario);
            Wario.ConsecutiveBounces = 0;
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
