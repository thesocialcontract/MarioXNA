using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightJumpingBigMarioState : MarioState
    {
        private float Timer;
        public RightJumpingBigMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightJumpingBigMarioSprite());
            Timer = mario.JumpTime;
        }
        public RightJumpingBigMarioState(Mario mario, float shortTimer) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightJumpingBigMarioSprite());
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
                Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
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

        public override void SetToFire()
        {
            Mario.MarioState = new RightJumpingBigToFireMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new RightJumpingSmallMarioState(Mario, Timer);
        }

        

        

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Mario.MarioState = new RightJumpingBigToSmallMarioState(Mario);
        }
        public override void Land()
        {
            Mario.MarioState = new RightFacingBigMarioState(Mario);
            Mario.ConsecutiveBounces = 0;
        }
        public override void EnemyJump()
        {
            Mario.PhysicsEngine.ForceCancel(true);
            Mario.SetEndUpwardForce(false);
            Mario.MarioState = new RightJumpingBigMarioState(Mario, 15);
            Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningBigMarioState(Mario);
        }
    }
}