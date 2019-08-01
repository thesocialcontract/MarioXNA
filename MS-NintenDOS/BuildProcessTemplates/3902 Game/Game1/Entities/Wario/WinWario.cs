using Microsoft.Xna.Framework;
using Game1.Entities.Items;

namespace Game1.Entities.Mario
{
    class WinWario : Player, IMario
    {
        // Player meta score
        public int Score { get; set; }
        public int Lives { get; set; }
        public int Coins { get; set; }
        private IMario DecoratedMario { get; set; }
        public bool isDead { get; set; }
        public bool isStarMario { get; set; }
        public bool isInvulnerable { get; set; }
        public bool isInHitStun { get; set; }
        public float XPos { get; set; }
        public float YPos { get; set; }
        public FireballFactory FireballFactory {
            get => DecoratedMario.FireballFactory;
            set => DecoratedMario.FireballFactory = value;
        }
        public int ConsecutiveBounces { get; set; }

        public new Vector2 WorldLocation {
            get => DecoratedMario.WorldLocation;
            set => DecoratedMario.WorldLocation = value;
        }
        public new Collider Collider {
            get => DecoratedMario.Collider;
            set => DecoratedMario.Collider = value;
        }
        public bool isCrouching
        {
            get => DecoratedMario.isCrouching;
            set => DecoratedMario.isCrouching = value;
        }

        private int Timer;
        public WinWario(IMario wario)
        {
            isStarMario = true;
            DecoratedMario = wario;
            MarioState = DecoratedMario.MarioState;
            XPos = DecoratedMario.XPos;
            YPos = DecoratedMario.YPos;
            PhysicsEngine = DecoratedMario.PhysicsEngine;
            Timer = 0;
            DecoratedMario.PhysicsEngine.ForceCancel(false);
            DecoratedMario.PhysicsEngine.ForceCancel(true);
            isInvulnerable = DecoratedMario.isInvulnerable;
        }

        public void Crouch()
        {
            
        }

        public void Die()
        {
            
        }

        public override void Draw()
        {
            DecoratedMario.Draw();
        }

        public void EnemyJump()
        {
            
        }


        public void Jump()
        {
            
        }

        public void Land()
        {
            DecoratedMario.Land();
        }

        public void MoveDown()
        {
            
        }

        public void MoveLeft()
        {
            
        }

        public void MoveRight()
        {
            
        }

        public void RunLeft()
        {
            
        }

        public void RunRight()
        {

        }

        public void SetBig()
        {
            
        }

        public void SetEndUpwardForce(bool Up)
        {
            
        }

        public void SetFire()
        {
            
        }

        public void SetSingleJump(bool OneJump)
        {
            
        }

        public void SetSmall()
        {
            
        }

        public void SetStar()
        {
            
        }

        public void SpeedButtonPress(bool Button)
        {
            
        }

        public void Stand()
        {
            DecoratedMario.Stand();
        }

        public void SuperJump()
        {
            
        }

        public void TakeDamage()
        {
            
        }

        public void SpecialAbility()
        {
            
        }
        public void SpecialAbilityFinish() { }
        public override void Update()
        {
            Timer++;
            if (Timer < 70)
            {
                DecoratedMario.MoveDown();
            }
            else if (Timer == 70)
            {
                DecoratedMario.MoveRight();
                DecoratedMario.WorldLocation = new Vector2(WorldLocation.X + 20, WorldLocation.Y);
            }
            else if (Timer > 80)
            {
                DecoratedMario.MoveRight();
            }
        }

        public void Win()
        {
            
        }

        public void Disappear()
        {
            DecoratedMario.Disappear();
        }
    }
}
