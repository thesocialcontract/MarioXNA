using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Globals;

namespace Game1.Entities.Mario
{
    internal class InvisibleWinMario : Player, IMario
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
        public FireballFactory FireballFactory
        {
            get => DecoratedMario.FireballFactory;
            set => DecoratedMario.FireballFactory = value;
        }
        public int ConsecutiveBounces { get; set; }

        public new Vector2 WorldLocation
        {
            get => DecoratedMario.WorldLocation;
            set => DecoratedMario.WorldLocation = value;
        }
        public new Collider Collider
        {
            get => DecoratedMario.Collider;
            set => DecoratedMario.Collider = value;
        }
        public bool isCrouching
        {
            get => DecoratedMario.isCrouching;
            set => DecoratedMario.isCrouching = value;
        }

        private float timeTilReset;

        public InvisibleWinMario(Mario mario)
        {
            isStarMario = true;
            DecoratedMario = mario;
            MarioState = DecoratedMario.MarioState;
            XPos = DecoratedMario.XPos;
            YPos = DecoratedMario.YPos;
            PhysicsEngine = DecoratedMario.PhysicsEngine;
            DecoratedMario.PhysicsEngine.ForceCancel(false);
            DecoratedMario.PhysicsEngine.ForceCancel(true);
            isInvulnerable = DecoratedMario.isInvulnerable;
            timeTilReset = 3.5f;
        }
        public void Crouch()
        {
            
        }

        public void Die()
        {
            
        }

        public void Disappear()
        {
            
        }

        public override void Draw()
        {
            
        }

        public void EnemyJump()
        {
            
        }

        public void Jump()
        {
            
        }

        public void Land()
        {
            
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
            timeTilReset -= GameGlobals.dt;
            if (timeTilReset <= 0.0f)
                WorldLoading.World.Instance.NextLevel();

        }

        public void Win()
        {
            
        }
    }
}