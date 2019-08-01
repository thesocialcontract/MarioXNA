using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States.Transitions
{
    class HitStunMario : Player, IMario
    {
        // Player meta score
        public int Score { get; set; }
        public int Lives { get; set; }
        public int Coins { get; set; }
        public float XPos { get; set; }
        public float YPos { get; set; }
        public IMario DecoratedMario { get; set; }
        public new Collider Collider
        {
            get => DecoratedMario.MarioState.Collider;
            set => DecoratedMario.MarioState.Collider = value;
        }
        public new Vector2 WorldLocation
        {
            get => DecoratedMario.WorldLocation;
            set => DecoratedMario.WorldLocation = value;
        }
        public bool isStarMario { get; set; }
        public bool isInvulnerable { get; set; }
        public bool isDead { get; set; }
        public FireballFactory FireballFactory
        {
            get => DecoratedMario.FireballFactory;
            set => DecoratedMario.FireballFactory = value;
        }
        public int ConsecutiveBounces { get; set; }
        public bool isInHitStun { get; set; }
        public bool isCrouching
        {
            get => DecoratedMario.isCrouching;
            set => DecoratedMario.isCrouching = value;
        }

        private int Timer;
       // private bool drawSwitcher;
        public HitStunMario(IMario mario)
        {
            isStarMario = false;
            //drawSwitcher = false;
            isInHitStun = true;
            DecoratedMario = mario;
            MarioState = DecoratedMario.MarioState;
            XPos = DecoratedMario.XPos;
            YPos = DecoratedMario.YPos;
            PhysicsEngine = DecoratedMario.PhysicsEngine;
            Timer = 100;
            DecoratedMario.isInHitStun = true;
            isInvulnerable = DecoratedMario.isInvulnerable;
        }
        public void Crouch()
        {
            DecoratedMario.Crouch();
        }

        public void Die()
        {

        }

        public override void Draw()
        {
            this.DecoratedMario.InvulnerableDraw();
        }

        public void Jump()
        {
            DecoratedMario.Jump();
        }

        public void MoveDown()
        {
            DecoratedMario.MoveDown();
        }

        public void MoveLeft()
        {
            DecoratedMario.MoveLeft();
        }

        public void MoveRight()
        {
            DecoratedMario.MoveRight();
        }


        public void RunLeft()
        {
            DecoratedMario.RunLeft();
        }

        public void RunRight()
        {
            DecoratedMario.RunRight();
        }

        public void SetBig()
        {
            DecoratedMario.SetBig();
        }

        public void SetFire()
        {
            DecoratedMario.SetFire();
        }

        public void SetStar()
        {
            DecoratedMario.SetStar();
        }
        public void Stand()
        {
            DecoratedMario.Stand();
        }

        public void TakeDamage()
        {
            
        }

        public void SpecialAbility()
        {
            DecoratedMario.SpecialAbility();
        }
        public void SpecialAbilityFinish()
        {
            DecoratedMario.SpecialAbilityFinish();
        }
        public override void Update()
        {
            DecoratedMario.PhysicsEngine.SetPauseState(false);
            Timer--;
            if (Timer <= 0)
            {
                
                RemoveDecorator();
            }
            //drawSwitcher = Timer % 5 == 0;
            DecoratedMario.Update();
            this.MarioState = DecoratedMario.MarioState;

        }

        public void RemoveDecorator()
        {
            DecoratedMario.isInHitStun = false;
            World.Instance.Player = DecoratedMario;
        }
        public override void InvulnerableDraw()
        {

        }
        public void SpeedButtonPress(bool Button)
        {
            DecoratedMario.SpeedButtonPress(Button);
        }
        public void SetEndUpwardForce(bool EndUpwardForce)
        {
            DecoratedMario.SetEndUpwardForce(EndUpwardForce);
        }

        public void SetSmall()
        {
            DecoratedMario.SetSmall();
        }
        public void Land()
        {
            DecoratedMario.Land();
        }
        public void SuperJump()
        {
            DecoratedMario.SuperJump();
        }
        public void EnemyJump()
        {
            DecoratedMario.EnemyJump();
        }
        public void SetSingleJump(bool oneJump)
        {
            DecoratedMario.SetSingleJump(oneJump);
        }

        public void Win()
        {
            DecoratedMario.Win();
        }

        public void Disappear()
        {
            
        }
    }
}
