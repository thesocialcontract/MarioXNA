using Game1.Entities.Items;
using Game1.Entities.Mario.States.Transitions;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States
{
    class RightCrouchingVikingWarioState : WarioState
    {
        public RightCrouchingVikingWarioState(Wario wario) : base(wario)
        {
            base.SetSprite(WarioSpriteFactory.Instance.CreateRightCrouchingVikingWarioSprite());
        }

        public override void SetToBig()
        {
            Wario.MarioState = new RightCrouchingHunterWarioState(Wario);
        }

        public override void SetToSmall()
        {
            Wario.MarioState = new RightFacingSmallWarioState(Wario);
        }

        public override void Jump()
        {
            Wario.MarioState = new RightFacingVikingWarioState(Wario);
        }
        public override void Stand()
        {
            Wario.MarioState = new RightFacingVikingWarioState(Wario);
        }

        public override void TakeDamage()
        {
            Wario.MarioState = new RightCrouchingVikingToSmallWarioState(Wario);
        }

        public override void SpecialAbility()
        {/*
            Fireball fireball = Mario.FireballFactory.CreateFireball();
            if (fireball != null)
            {
                MarioAudioManager.PlaySfxFireball();
                fireball.SetDirection(true);
                World.Instance.AddEntity(fireball);
            }
            */
        }
        public override void RunLeft()
        {
            Wario.MarioState = new LeftCrouchingVikingWarioState(Wario);
        }
        public override void RunRight()
        {
            Wario.MarioState = new RightCrouchWalkingVikingWarioState(Wario);
        }
        public override void Win()
        {
            Wario.MarioState = new RightWinningVikingWarioState(Wario);
        }
    }
}
