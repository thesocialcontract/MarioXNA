using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    class RightGroundPoundingVikingWarioState : WarioState
    {
        
        public RightGroundPoundingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightGroundPoundingVikingWarioSprite());
            
        }
        
        public override void Jump()
        {
           
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
            Wario.MarioState = new RightJumpingHunterWarioState(Wario, 0);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightJumpingSmallWarioState(Wario, 0);         
        }
        

        public override void TakeDamage()
        {
            Wario.MarioState = new RightJumpingVikingToSmallWarioState(Wario);
        }

        public override void Land()
        {
            Wario.MarioState = new RightFacingVikingWarioState(Wario);
            Wario.ConsecutiveBounces = 0;
        }

        public override void SpecialAbility()
        {
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
