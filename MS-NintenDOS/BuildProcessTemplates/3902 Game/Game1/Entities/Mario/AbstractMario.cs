using Microsoft.Xna.Framework;
using System;
using Game1.Entities.Items;
using Game1.Entities.Mario.States;
using Game1.WorldLoading;

namespace Game1.Entities.Mario
{
    public class Mario : Player, IMario
    {
        // Player meta score
        public int Score { get; set; }
        public int Lives { get; set; }
        public int Coins { get; set; }

        // States Variables that would ideally be refactored but realistically won't be.
        public bool isStarMario { get; set; }
        public bool isInvulnerable { get; set; }
        public bool isInHitStun { get; set; }
        public bool isDead { get; set; }
        public bool JumpButtonReleased { get; set; }
        public bool SingleJump { get; set; }

        // Factories
        public FireballFactory FireballFactory { get; set; }
        
        // Physics
        private float CurrentMaxSpeed = 3f;
        private readonly float MaxRunSpeed = 5f;
        private readonly float MaxWalkSpeed = 3f;
        private readonly float Gravity = 3f;

        private readonly float SuperJumpPower = -6f;
        private float PreviousYPosition;
        public float MoveIncrement { get; set; }
        public float JumpPower { get; set; }

        public float JumpTime { get; set; }
        public float XPos
        {
            get { return (int)Math.Floor(WorldLocation.X); }
            set { WorldLocation = new Vector2(value, WorldLocation.Y); }
        }
        public float YPos
        {
            get { return (int)Math.Floor(WorldLocation.Y); }
            set { WorldLocation = new Vector2(WorldLocation.X, value); }
        }
        
        public int ConsecutiveBounces { get; set; }
        public bool isCrouching { get; set; }

        public Mario(Vector2 location)
        {
            isStarMario = false;
            isDead = false;
            isCrouching = false;
            JumpButtonReleased = false;
            SingleJump = false;
            JumpTime = 35f;
            XPos = (int)Math.Floor(location.X); 
            YPos = (int)Math.Floor(location.Y);
            MarioState = new LeftFacingSmallMarioState(this);
            PhysicsEngine = new GenericObjectPhysicsEngine2();
            PreviousYPosition = YPos;
            MoveIncrement = 2f;
            JumpPower = -5f;
            isInvulnerable = false;
        }

        public override void Update()
        {
            MarioState.Update();
            CalculateMovement();
            
            
        }
        public void RunLeft()
        {
            MarioState.RunLeft();
            
        }
        public void RunRight()
        {
            MarioState.RunRight();
        }
        public void Stand()
        {
            isCrouching = false;
            MarioState.Stand();
        }
        public void Land()
        {
            MarioState.Land();
        }
        public void SetFire()
        {
            MarioState.SetToFire();
            MarioAudioManager.PlaySfxPowerup();
            FireballFactory = new FireballFactory(this);
        }
        public void SpecialAbilityFinish() { }
        public void SetBig()
        {
            MarioState.SetToBig();
            MarioAudioManager.PlaySfxPowerup();
        }
        public void TakeDamage()
        {
            MarioState.TakeDamage();
        }
        public void SuperJump()
        {
            MarioState.SuperJump();
        }
        public void Crouch()
        {
            isCrouching = true;
            MarioState.Crouch();
        }
        public void Die()
        {
            MarioState.Die();
            isDead = true;
        }
        public void Jump()
        {
            MarioState.Jump();
            
        }
        public void MoveDown()
        {
            MarioState.MoveDown();            
        }
        public void MoveLeft()
        {
            MarioState.RunLeft();

        }
        public void MoveRight()
        {
            MarioState.RunRight();
        }
        public void SetStar()
        {
            World.Instance.Player = new StarMario(this);
            isStarMario = true;
        }
        public void SpecialAbility()
        {
            MarioState.SpecialAbility();
        }
        public void SpeedButtonPress(bool Button)
        {
            if (Button)
            {
                CurrentMaxSpeed = MaxRunSpeed;
            }
            if (!Button)
            {
                CurrentMaxSpeed = MaxWalkSpeed;
            }
        }
        public void SetEndUpwardForce(bool EndUpwardForce)
        {
            JumpButtonReleased = EndUpwardForce;
            if (EndUpwardForce)
            {
                PhysicsEngine.ForceCancel(true);
            }
        }
        private static bool Equals(float inputValue, float equalValue)
        {
            bool Equality = false;
            if ((inputValue <= (equalValue + 0.1f)) && (inputValue >= (equalValue - 0.1f)))
            {
                Equality = true;
            }
            return Equality;
        }
        public void CalculateMovement()
        {
            PreviousYPosition = YPos;
            Vector2 MoveDistance = PhysicsEngine.Update();
            float ChangeXValue = MoveDistance.X;
            float ChangeYValue = MoveDistance.Y;
            if (MoveDistance.X > CurrentMaxSpeed)
            {
                ChangeXValue = CurrentMaxSpeed;
            }
            if (MoveDistance.X < (-1f*CurrentMaxSpeed))
            {
                ChangeXValue = (-1f*CurrentMaxSpeed);
            }
            if ((MoveDistance.Y <= SuperJumpPower) && (Equals(CurrentMaxSpeed, MaxRunSpeed)) && (ChangeXValue != 0f))
            {
                ChangeYValue = SuperJumpPower;
            }
            else if (MoveDistance.Y < JumpPower)
            {
                ChangeYValue = JumpPower;
            }
            XPos = XPos + ChangeXValue;
            YPos = YPos + ChangeYValue;

            
            
            if (Equals((YPos - PreviousYPosition), Gravity) || ((YPos - PreviousYPosition) > Gravity))
            {
                SetEndUpwardForce(true);
                PhysicsEngine.ForceCancel(true);
            }

        }
        public void SetSmall()
        {
            PhysicsEngine.SetPauseState(true);
            MarioState.SetToSmall();
            MarioState.Stand();
        }
        public void EnemyJump()
        {
            MarioState.EnemyJump();
        }
        public void SetSingleJump(bool OneJump)
        {
            SingleJump = OneJump;
        }
        public void Win()
        {
            MarioState.Win();
            World.Instance.Player = new WinMario(this);
        }
        public void Disappear()
        {
            World.Instance.Player = new InvisibleWinMario(this);
        }
    }
}