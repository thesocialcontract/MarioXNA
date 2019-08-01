using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftJumpingSmallWarioState : WarioState
    {
        private float Timer;
        public LeftJumpingSmallWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftJumpingSmallWarioSprite());
            Timer = wario.JumpTime;
        }
        public LeftJumpingSmallWarioState(Wario wario, float shortTimer) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftJumpingSmallWarioSprite());
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




        

        public override void SetToBig()
        {
            Wario.MarioState = new LeftJumpingSmallToHunterWarioState(Wario);
        }

        public override void SetToFire()
        {
            Wario.MarioState = new LeftJumpingSmallToVikingWarioState(Wario);
        }
        
        public override void Land()
        {
            Wario.MarioState = new LeftFacingSmallWarioState(Wario);
            Wario.ConsecutiveBounces = 0;
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new LeftJumpingSmallWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
           Wario.MarioState = new LeftWinningSmallWarioState(Wario);
        }
    }
}