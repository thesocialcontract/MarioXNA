using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    class LeftJumpingFireMarioState : MarioState
    {
        private float Timer;
        public LeftJumpingFireMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftJumpingFireMarioSprite());
            Timer = mario.JumpTime;
        }
        public LeftJumpingFireMarioState(Mario mario, float shortTimer) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftJumpingFireMarioSprite());
            Timer = shortTimer;
        }
        public override void Jump()
        {
            if (!(Mario.JumpButtonReleased))
            {
                Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
            }
        }

        public override void Update()
        {
            Sprite.Update();
            string marioSizeString;
            if (GetType().Name.Contains("Small"))
            {
                marioSizeString = "SmallMario";
            }
            else if (GetType().Name.Contains("Big"))
            {
                marioSizeString = "BigMario";
            }
            else if (GetType().Name.Contains("Fire"))
            {
                marioSizeString = "FireMario";
            }
            else
            {
                marioSizeString = "DeadMario";
            }
            Collider = ColliderFactory.Instance.CreateCollider(marioSizeString, Mario);

            Timer--;
            if (Timer <= 0)
            {
                Mario.SetEndUpwardForce(true);
                Mario.PhysicsEngine.ForceCancel(true);
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
            Mario.MarioState = new LeftJumpingBigMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new LeftJumpingSmallMarioState(Mario, Timer);         
        }
        

        public override void TakeDamage()
        {
            Mario.MarioState = new LeftJumpingFireToSmallMarioState(Mario);
        }

        public override void Land()
        {
            Mario.MarioState = new LeftFacingFireMarioState(Mario);
            Mario.ConsecutiveBounces = 0;
        }

        public override void SpecialAbility()
        {
            Fireball fireball = Mario.FireballFactory.CreateFireball();
            if (fireball != null)
            {
                MarioAudioManager.PlaySfxFireball();
                fireball.SetDirection(false);
                World.Instance.AddEntity(fireball);
            }
        }
        public override void EnemyJump()
        {
            Mario.PhysicsEngine.ForceCancel(true);
            Mario.SetEndUpwardForce(false);
            Mario.MarioState = new LeftJumpingFireMarioState(Mario, 15);
            Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
        }
        public override void Win()
        {
            Mario.MarioState = new LeftWinningFireMarioState(Mario);
        }
    }
}
