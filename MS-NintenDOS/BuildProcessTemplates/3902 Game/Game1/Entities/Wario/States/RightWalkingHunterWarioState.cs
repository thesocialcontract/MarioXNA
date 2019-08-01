﻿using Microsoft.Xna.Framework;
using Game1.Entities.Mario.States.Transitions;

namespace Game1.Entities.Mario.States
{
    public class RightWalkingHunterWarioState : WarioState
    {
        public RightWalkingHunterWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightWalkingHunterWarioSprite());
        }

        public override void RunLeft()
        {
            Wario.MarioState = new RightFacingHunterWarioState(Wario);
            Wario.PhysicsEngine.ApplyForce(new Vector2(-Wario.MoveIncrement, 0));
        }
        public override void RunRight()
        {
            Wario.PhysicsEngine.ApplyForce(new Vector2(Wario.MoveIncrement, 0));

        }
        public override void SpecialAbility()
        {
            if (!Wario.SingleJump)
            {
                MarioAudioManager.PlaySfxCharge();
                Wario.SingleJump = true;
                Wario.MarioState = new RightDashingHunterWarioState(Wario);
            }
        }
        public override void SetToFire()
        {
            Wario.MarioState = new RightWalkingHunterToVikingWarioState(Wario);
        }
        
        public override void SetToSmall()
        {
            Wario.MarioState = new RightWalkingSmallWarioState(Wario);
        }

        public override void Jump()
        {
            if ((!Wario.JumpButtonReleased) && (!Wario.SingleJump))
            {
                MarioAudioManager.PlaySfxJumpBig();
                Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
                Wario.MarioState = new RightJumpingHunterWarioState(Wario);
            }
        }

        public override void Crouch()
        {
            Wario.MarioState = new RightCrouchingHunterWarioState(Wario);
        }
        public override void Stand()
        {
            Wario.MarioState = new RightFacingHunterWarioState(Wario);
            Wario.PhysicsEngine.ForceCancel(false);
        }

        public override void TakeDamage()
        {
            MarioAudioManager.PlaySfxPowerdown();
            Wario.MarioState = new RightWalkingHunterToSmallWarioState(Wario);
        }
        public override void EnemyJump()
        {
            Wario.PhysicsEngine.ForceCancel(true);
            Wario.SetEndUpwardForce(false);
            Wario.MarioState = new RightJumpingHunterWarioState(Wario, 15);
            Wario.PhysicsEngine.ApplyForce(new Vector2(0, Wario.JumpPower));
        }
        public override void Win()
        {
            Wario.MarioState = new LeftWinningHunterWarioState(Wario);
        }
    }
}