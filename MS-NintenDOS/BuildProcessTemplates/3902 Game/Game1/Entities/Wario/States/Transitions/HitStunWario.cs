using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States.Transitions
{
    class HitStunWario : Player, IMario
    {
        // Player meta score
        public int Score { get; set; }
        public int Lives { get; set; }
        public int Coins { get; set; }
        public float XPos { get; set; }
        public float YPos { get; set; }
        public IMario DecoratedWario { get; set; }
        public new Collider Collider
        {
            get => DecoratedWario.MarioState.Collider;
            set => DecoratedWario.MarioState.Collider = value;
        }
        public new Vector2 WorldLocation
        {
            get => DecoratedWario.WorldLocation;
            set => DecoratedWario.WorldLocation = value;
        }
        public bool isStarMario { get; set; }
        public bool isInvulnerable { get; set; }
        public bool isDead { get; set; }
        public FireballFactory FireballFactory
        {
            get => DecoratedWario.FireballFactory;
            set => DecoratedWario.FireballFactory = value;
        }
        public int ConsecutiveBounces { get; set; }
        public bool isInHitStun { get; set; }
        public bool isCrouching
        {
            get => DecoratedWario.isCrouching;
            set => DecoratedWario.isCrouching = value;
        }

        private int Timer;
       // private bool drawSwitcher;
        public HitStunWario(IMario wario)
        {
            isStarMario = false;
            //drawSwitcher = false;
            isInHitStun = true;
            DecoratedWario = wario;
            MarioState = DecoratedWario.MarioState;
            XPos = DecoratedWario.XPos;
            YPos = DecoratedWario.YPos;
            PhysicsEngine = DecoratedWario.PhysicsEngine;
            Timer = 100;
            DecoratedWario.isInHitStun = true;
            isInvulnerable = DecoratedWario.isInvulnerable;
        }
        public void Crouch()
        {
            DecoratedWario.Crouch();
        }

        public void Die()
        {

        }

        public override void Draw()
        {
            this.DecoratedWario.InvulnerableDraw();
        }

        public void Jump()
        {
            DecoratedWario.Jump();
        }

        public void MoveDown()
        {
            DecoratedWario.MoveDown();
        }

        public void MoveLeft()
        {
            DecoratedWario.MoveLeft();
        }

        public void MoveRight()
        {
            DecoratedWario.MoveRight();
        }


        public void RunLeft()
        {
            DecoratedWario.RunLeft();
        }

        public void RunRight()
        {
            DecoratedWario.RunRight();
        }

        public void SetBig()
        {
            DecoratedWario.SetBig();
        }

        public void SetFire()
        {
            DecoratedWario.SetFire();
        }

        public void SetStar()
        {
            DecoratedWario.SetStar();
        }
        public void Stand()
        {
            DecoratedWario.Stand();
        }

        public void TakeDamage()
        {
            
        }

        public void SpecialAbility()
        {
            DecoratedWario.SpecialAbility();
        }
        public void SpecialAbilityFinish() { }
        public override void Update()
        {
            DecoratedWario.PhysicsEngine.SetPauseState(false);
            Timer--;
            if (Timer <= 0)
            {
                
                RemoveDecorator();
            }
            //drawSwitcher = Timer % 5 == 0;
            DecoratedWario.Update();
            this.MarioState = DecoratedWario.MarioState;

        }

        public void RemoveDecorator()
        {
            DecoratedWario.isInHitStun = false;
            World.Instance.Player = DecoratedWario;
        }
        public override void InvulnerableDraw()
        {

        }
        public void SpeedButtonPress(bool Button)
        {
            DecoratedWario.SpeedButtonPress(Button);
        }
        public void SetEndUpwardForce(bool EndUpwardForce)
        {
            DecoratedWario.SetEndUpwardForce(EndUpwardForce);
        }

        public void SetSmall()
        {
            DecoratedWario.SetSmall();
        }
        public void Land()
        {
            DecoratedWario.Land();
        }
        public void SuperJump()
        {
            DecoratedWario.SuperJump();
        }
        public void EnemyJump()
        {
            DecoratedWario.EnemyJump();
        }
        public void SetSingleJump(bool oneJump)
        {
            DecoratedWario.SetSingleJump(oneJump);
        }

        public void Win()
        {
            DecoratedWario.Win();
        }

        public void Disappear()
        {
            
        }
    }
}
