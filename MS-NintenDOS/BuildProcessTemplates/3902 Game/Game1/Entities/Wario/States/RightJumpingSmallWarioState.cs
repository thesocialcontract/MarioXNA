using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightJumpingSmallWarioState : WarioState
    {
        private float Timer;
        public RightJumpingSmallWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightJumpingSmallWarioSprite());
            Timer = wario.JumpTime;
        }
        public RightJumpingSmallWarioState(Wario wario, float shortTimer) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightJumpingSmallWarioSprite());
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
            Wario.MarioState = new RightJumpingSmallToVikingWarioState(Wario);
        }

        public override void SetToBig()
        {
            Wario.MarioState = new RightJumpingSmallToHunterWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightJumpingSmallWarioState(Wario);
        }
        
        
                
        public override void Land()
        {
            Wario.MarioState = new RightFacingSmallWarioState(Wario);
            Wario.ConsecutiveBounces = 0;
        }

        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new RightJumpingSmallWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningSmallWarioState(Wario);
        }
    }
}