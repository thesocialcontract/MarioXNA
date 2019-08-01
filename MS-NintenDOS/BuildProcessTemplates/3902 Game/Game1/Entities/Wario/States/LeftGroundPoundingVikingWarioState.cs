using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    class LeftGroundPoundingVikingWarioState : WarioState
    {
        
        public LeftGroundPoundingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftGroundPoundingVikingWarioSprite());
            
        }
        
        public override void Jump()
        {
            
        }

        public override void Update()
        {
            Sprite.Update();
            string warioSizeString;
            if (GetType().Name.Contains("Small"))
            {
                warioSizeString = "SmallWario";
            }
            else if (GetType().Name.Contains("Crouch"))
            {
                warioSizeString = "CrouchWario";
            }
            else if (GetType().Name.Contains("Hunter"))
            {
                warioSizeString = "BigWario";
            }

            else if (GetType().Name.Contains("Viking"))
            {
                warioSizeString = "BigWario";
            }else
            {
                warioSizeString = "DeadWario";
            }
            Collider = ColliderFactory.Instance.CreateCollider(warioSizeString, Wario);

            
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
            Wario.MarioState = new LeftJumpingHunterWarioState(Wario, 0);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new LeftJumpingSmallWarioState(Wario, 0);         
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
