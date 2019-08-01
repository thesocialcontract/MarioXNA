using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    class LeftDashJumpingVikingWarioState : WarioState
    {
        private float Timer;
        

        public LeftDashJumpingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftDashJumpingVikingWarioSprite());
            Timer = wario.JumpTime;
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MaxRunSpeed, (Wario.JumpPower)));
        }
                
        public override void Jump()
        {
            
        }
        public override void Update()
        {
            base.Update();
            Timer--;
            if(Timer <= 0)
            {
                Wario.SetEndUpwardForce(true);
                Wario.PhysicsEngine.ForceCancel(true);
                Wario.isInvulnerable = false;
                Wario.MarioState = new LeftJumpingVikingWarioState(Wario, 0);
                
            }
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MaxRunSpeed, 0));
        }

        public override void RunLeft()
        {
            

        }

        public override void RunRight()
        {
            

        }

        

        public override void SetToFire()
        {
            Wario.isInvulnerable = false;
            Wario.MarioState = new LeftJumpingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.isInvulnerable = false;
            Wario.MarioState = new LeftJumpingSmallWarioState(Wario, Timer);
        }

        
        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new LeftJumpingHunterToSmallWarioState(Wario);
        }
        public override void Land()
        {
            Wario.isInvulnerable = false;
            Wario.MarioState = new LeftFacingVikingWarioState(Wario);
            Wario.ConsecutiveBounces = 0;
        }
        public override void EnemyJump()
        {
            Wario.isInvulnerable = false;
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new LeftJumpingVikingWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.isInvulnerable = false;
            Wario.MarioState = new LeftWinningVikingWarioState(Wario);
        }
    }
}
