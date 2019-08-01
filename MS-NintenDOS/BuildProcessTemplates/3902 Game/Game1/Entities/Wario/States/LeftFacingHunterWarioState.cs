using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    class LeftFacingHunterWarioState : WarioState
    {
        
        public LeftFacingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftFacingHunterWarioSprite());
            
        }

        public override void RunLeft()
        {

            Wario.MarioState = new LeftWalkingHunterWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0));
        }

        public override void RunRight()
        {
            Wario.MarioState = new RightFacingHunterWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));

        }
        public override void SpecialAbility()
        {
            if (!Wario.SingleJump)
            {
                MarioAudioManager.PlaySfxCharge();
                Wario.SingleJump = true;
                Wario.MarioState = new LeftDashingHunterWarioState(Wario);
            }
        }
        

        public override void SetToFire()
        {
            Wario.MarioState = new LeftFacingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new LeftFacingSmallWarioState(Wario);
        }

        public override void Jump()
        {
            if ((!Wario.JumpButtonReleased) && (!Wario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpBig();
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
                Wario.MarioState = new LeftJumpingHunterWarioState(Wario);
            }

        }
        
        public override void Crouch()
        {
            Wario.MarioState = new LeftCrouchingHunterWarioState(Wario); 
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new LeftFacingHunterToSmallWarioState(Wario);
        }

        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new LeftJumpingHunterWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningHunterWarioState(Wario);
        }
    }
}
