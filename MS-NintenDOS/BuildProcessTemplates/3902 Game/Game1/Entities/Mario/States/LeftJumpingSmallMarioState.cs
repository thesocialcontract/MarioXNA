using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftJumpingSmallMarioState : MarioState
    {
        private float Timer;
        public LeftJumpingSmallMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite());
            Timer = mario.JumpTime;
        }
        public LeftJumpingSmallMarioState(Mario mario, float shortTimer) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftJumpingSmallMarioSprite());
            Timer = shortTimer;
        }
        public override void Update()
        {
            base.Update();
            Timer--;
            if (Timer <= 0)
            {
                Mario.SetEndUpwardForce(true);
                Mario.PhysicsEngine.ForceCancel(true);
            }
        }

        public override void Jump()
        {
            if (!(Mario.JumpButtonReleased))
            {
                Mario.PhysicsEngine.ApplyForce(new Vector2(0, -7));
            }
        }

        public override void RunLeft()
        {
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));

        }

        public override void RunRight()
        {
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));

        }




        

        public override void SetToBig()
        {
            Mario.MarioState = new LeftJumpingSmallToBigMarioState(Mario);
        }

        public override void SetToFire()
        {
            Mario.MarioState = new LeftJumpingSmallToFireMarioState(Mario);
        }
        
        public override void Land()
        {
            Mario.MarioState = new LeftFacingSmallMarioState(Mario);
            Mario.ConsecutiveBounces = 0;
        }
        public override void EnemyJump()
        {
            Mario.PhysicsEngine.ForceCancel(true);
            Mario.SetEndUpwardForce(false);
            Mario.MarioState = new LeftJumpingSmallMarioState(Mario, 15);
            Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningSmallMarioState(Mario);
        }
    }
}