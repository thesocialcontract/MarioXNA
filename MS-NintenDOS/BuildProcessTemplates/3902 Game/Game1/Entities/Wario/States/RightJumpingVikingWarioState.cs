using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    public class RightJumpingVikingWarioState : WarioState
    {
        private float Timer;
        public RightJumpingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightJumpingVikingWarioSprite());
            Timer = wario.JumpTime;
        }
        public RightJumpingVikingWarioState(Wario wario, float shortTimer) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightJumpingVikingWarioSprite());
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
        public override void MoveDown()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.Gravity));
            Wario.MarioState = new RightGroundPoundingVikingWarioState(Wario);
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
            Wario.MarioState = new RightJumpingHunterWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightJumpingSmallWarioState(Wario, Timer);
        }
        public override void SetToFire()
        {
            Wario.MarioState = new LeftJumpingHunterToVikingWarioState(Wario);
        }



        public override void TakeDamage()
        {
            Wario.MarioState = new RightJumpingVikingToSmallWarioState(Wario);
        }

        public override void SpecialAbility()
        {
        }
        public override void Land()
        {
            Wario.MarioState = new RightFacingVikingWarioState(Wario);
            Wario.ConsecutiveBounces = 0;
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new RightJumpingVikingWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningVikingWarioState(Wario);
        }
    }
}