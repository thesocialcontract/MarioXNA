using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    public class LeftFacingFireMarioState : MarioState
    {
        public LeftFacingFireMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftFacingFireMarioSprite());
        }

        public override void RunLeft()
        {
            Mario.MarioState = new LeftRunningFireMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));
        }

        public override void RunRight()
        {
            Mario.MarioState = new RightFacingFireMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));
        }
        
        public override void SetToBig()
        {
            Mario.MarioState = new LeftFacingBigMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new LeftFacingSmallMarioState(Mario);
        }

        public override void Jump()
        {
            if ((!Mario.JumpButtonReleased) && (!Mario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpBig();
                Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
                Mario.MarioState = new LeftJumpingFireMarioState(Mario);
            }
        }

        public override void Crouch()
        {
            Mario.MarioState = new LeftCrouchingFireMarioState(Mario);
        }

        public override void TakeDamage()
        {
            Mario.MarioState = new LeftFacingFireToSmallMarioState(Mario);
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