using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightDashingHunterWarioState : WarioState
    {
        float Timer;

        public RightDashingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightDashingHunterWarioSprite());
            Timer = (Wario.JumpTime * 1.5f);
            Wario.isInvulnerable = true;
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MaxRunSpeed, -Wario.Gravity));
        }

        public override void Update()
        {
            base.Update();
            Timer--;
            if(Timer <= 0)
            {
                Wario.isInvulnerable = false;
                Wario.PhysicsEngine.ForceCancel(true);
                Wario.MarioState = new RightFacingHunterWarioState(Wario);
            }
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MaxRunSpeed, 0));
        }
        public override void RunLeft()
        {
            Wario.PhysicsEngine.ForceCancel(false);
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.isInvulnerable = false;
            Wario.MarioState = new RightFacingHunterWarioState(Wario);
            
        }
        public override void SpecialAbilityFinish()
        {
            Wario.PhysicsEngine.ForceCancel(false);
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.MarioState = new RightFacingHunterWarioState(Wario);
        }
        public override void RunRight()
        {
           

        }

        public override void SetToFire()
        {
            Wario.isInvulnerable = false;
            Wario.MarioState = new RightWalkingHunterToVikingWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.isInvulnerable = false;
            Wario.MarioState = new RightWalkingSmallWarioState(Wario);
        }

        public override void Jump()
        {
            
                MarioAudioManager.PlaySfxJumpBig();
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
                Wario.MarioState = new RightDashJumpingHunterWarioState(Wario);
            


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
            Wario.MarioState = new RightWinningHunterWarioState(Wario);
        }
    }
}