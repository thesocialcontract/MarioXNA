using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class LeftDashingHunterWarioState : WarioState
    {
        float Timer;

        public LeftDashingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateLeftDashingHunterWarioSprite());
            Timer = (Wario.JumpTime * 1.5f);
            Wario.isInvulnerable = true;
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MaxRunSpeed, -Wario.Gravity));
        }

        public override void Update()
        {
            base.Update();
            Timer--;
            if(Timer <= 0)
            {
                SpecialAbilityFinish();
            }
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MaxRunSpeed, 0));
        }
        public override void RunRight()
        {
            Wario.PhysicsEngine.ForceCancel(false);
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.isInvulnerable = false;
            Wario.MarioState = new LeftFacingHunterWarioState(Wario);
            
        }

        public override void RunLeft()
        {
           

        }

        public override void SetToFire()
        {
            Wario.isInvulnerable = false;
            Wario.MarioState = new LeftWalkingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.isInvulnerable = false;
            Wario.MarioState = new LeftWalkingSmallWarioState(Wario);
        }

        public override void Jump()
        {
            
                MarioAudioManager.PlaySfxJumpBig();
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
                Wario.MarioState = new LeftDashJumpingHunterWarioState(Wario);
            


        }
        public override void SpecialAbilityFinish()
        {
            Wario.isInvulnerable = false;
            Wario.PhysicsEngine.ForceCancel(false);
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.MarioState = new LeftFacingHunterWarioState(Wario);
        }
        public override void Crouch()
        {
            
        }
        public override void Stand()
        {
            
        }

        public override void TakeDamage()
        {
            
        }
        public override void EnemyJump()
        {
            
        }
        public override void Win()
        {
            Wario.isInvulnerable = false;
            Wario.MarioState = new LeftWinningHunterWarioState(Wario);
        }
    }
}