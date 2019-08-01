using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    class LeftJumpingVikingWarioState : WarioState
    {
        private float Timer;
        public LeftJumpingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftJumpingVikingWarioSprite());
            Timer = wario.JumpTime;
        }
        public LeftJumpingVikingWarioState(Wario wario, float shortTimer) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftJumpingVikingWarioSprite());
            Timer = shortTimer;
        }
        public override void Jump()
        {
            if (!(Wario.JumpButtonReleased))
            {
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
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
            Collider = ColliderFactory.Instance.CreateCollider(marioSizeString, Wario);

            Timer--;
            if (Timer <= 0)
            {
                Wario.SetEndUpwardForce(true);
                Wario.PhysicsEngine.ForceCancel(true);
            }
        }

        public override void MoveDown()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.Gravity));
            Wario.MarioState = new LeftGroundPoundingVikingWarioState(Wario);
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
            Wario.MarioState = new LeftJumpingHunterWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new LeftJumpingSmallWarioState(Wario, Timer);         
        }
        public override void SetToFire()
        {
            Wario.MarioState = new LeftJumpingHunterToVikingWarioState(Wario);
        }

        public override void TakeDamage()
        {
            Wario.MarioState = new LeftJumpingVikingToSmallWarioState(Wario);
        }

        public override void Land()
        {
            Wario.MarioState = new LeftFacingVikingWarioState(Wario);
            Wario.ConsecutiveBounces = 0;
        }

        public override void SpecialAbility()
        {/*
            Fireball fireball = Mario.FireballFactory.CreateFireball();
            if (fireball != null)
            {
                MarioAudioManager.PlaySfxFireball();
                fireball.SetDirection(false);
                World.Instance.AddEntity(fireball);
            }
            */
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new LeftJumpingVikingWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningVikingWarioState(Wario);
        }
    }
}
