using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    public class LeftRunningFireMarioState : MarioState
    {
        public LeftRunningFireMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateLeftRunningFireMarioSprite());
        }

        public override void RunRight()
        {
            Mario.MarioState = new LeftFacingFireMarioState(Mario);
            Mario.PhysicsEngine.ApplyForce(new Vector2(Mario.MoveIncrement, 0));
        }
        public override void RunLeft()
        {
            Mario.PhysicsEngine.ApplyForce(new Vector2(-Mario.MoveIncrement, 0));
        }

        public override void SetToBig()
        {
            Mario.MarioState = new LeftRunningBigMarioState(Mario);
        }

        public override void SetToSmall()
        {
            Mario.MarioState = new LeftRunningSmallMarioState(Mario);
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

        public override void Stand()
        {
            Mario.MarioState = new LeftFacingFireMarioState(Mario);
            Mario.PhysicsEngine.ForceCancel(false);
        }

        public override void TakeDamage()
        {
            Mario.MarioState = new LeftRunningFireToSmallMarioState(Mario);
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