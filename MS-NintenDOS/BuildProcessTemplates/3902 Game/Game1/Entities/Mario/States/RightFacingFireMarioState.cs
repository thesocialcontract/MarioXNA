using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    public class RightFacingFireMarioState : MarioState
    {
        public RightFacingFireMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateRightFacingFireMarioSprite());
        }

        public override void RunLeft()
        {
            Mario.MarioState = new LeftFacingFireMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));
        }

        public override void RunRight()
        {
            Mario.MarioState = new RightRunningFireMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));
        }

        public override void SetToBig()
        {
            Mario.MarioState = new RightFacingBigMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new RightFacingSmallMarioState(Mario);
        }

        public override void Jump()
        {
            if ((!Mario.JumpButtonReleased) && (!Mario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpBig();
                Mario.PhysicsEngine.ApplyForce(new Vector2(0, Mario.JumpPower));
                Mario.MarioState = new RightJumpingFireMarioState(Mario);
            }
        }

        public override void Crouch()
        {
            Mario.MarioState = new RightCrouchingFireMarioState(Mario);
        }

        public override void TakeDamage()
        {
            Mario.MarioState = new RightFacingFireToSmallMarioState(Mario);
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