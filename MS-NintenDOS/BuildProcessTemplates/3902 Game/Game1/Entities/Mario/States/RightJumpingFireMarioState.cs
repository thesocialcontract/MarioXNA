using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    public class RightJumpingFireMarioState : MarioState
    {
        private float Timer;
        public RightJumpingFireMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightJumpingFireMarioSprite());
            Timer = mario.JumpTime;
        }
        public RightJumpingFireMarioState(Mario mario, float shortTimer) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightJumpingFireMarioSprite());
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




        public override void SetToBig()
        {
            Mario.MarioState = new RightJumpingBigMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new RightJumpingSmallMarioState(Mario, Timer);
        }
        
        
        

        public override void TakeDamage()
        {
            Mario.MarioState = new RightJumpingFireToSmallMarioState(Mario);
        }

        public override void SpecialAbility()
        {
            Fireball fireball = Mario.FireballFactory.CreateFireball();
            if (fireball != null)
            {
                MarioAudioManager.PlaySfxFireball();
                fireball.SetDirection(true);
                World.Instance.AddEntity(fireball);
            }
        }
        public override void Land()
        {
            Mario.MarioState = new RightFacingFireMarioState(Mario);
            Mario.ConsecutiveBounces = 0;
        }
        public override void EnemyJump()
        {
            Mario.PhysicsEngine.ForceCancel(true);
            Mario.SetEndUpwardForce(false);
            Mario.MarioState = new RightJumpingFireMarioState(Mario, 15);
            Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningFireMarioState(Mario);
        }
    }
}