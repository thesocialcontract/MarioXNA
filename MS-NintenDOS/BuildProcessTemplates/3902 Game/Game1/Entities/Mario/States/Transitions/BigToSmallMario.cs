using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.States.Transitions
{
    class BigToSmallMario : Player, IMario
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
        public bool isDead { get; set; }
        public bool isInHitStun { get; set; }
        public FireballFactory FireballFactory
        {
            get => DecoratedMario.FireballFactory;
            set => DecoratedMario.FireballFactory = value;
        }
        public int ConsecutiveBounces { get; set; }

        private int Timer;
        private bool StateSwitcher;
        public BigToSmallMario(IMario mario)
        {
            isStarMario = false;
            StateSwitcher = false;
            DecoratedMario = mario;
            MarioState = DecoratedMario.MarioState;
            XPos = DecoratedMario.XPos;
            YPos = DecoratedMario.YPos;
            PhysicsEngine = DecoratedMario.PhysicsEngine;
            Timer = 50;
            MarioAudioManager.PlaySfxPowerdown();
        }
        public void Crouch()
        {

        }

        public void Die()
        {

        }

        public override void Draw()
        {
            this.DecoratedMario.Draw();
        }

        public void SuperJump()
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

        public void Jump()
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

        public void SetFire()
        {

        }

        public void SetStar()
        {

        }
        public void Stand()
        {

        }

        public void TakeDamage()
        {

        }

        public void ThrowFireball()
        {

        }

        public override void Update()
        {
            Timer--;
            if (Timer <= 0)
            {
                
                RemoveDecorator();
            }
            StateSwitcher = Timer % 5 == 0;
            if (StateSwitcher)
            {
                this.DecoratedMario.MarioState.SetToSmall();
            }
            else
            {
                this.DecoratedMario.MarioState.SetToBig();
            }
            DecoratedMario.Update();
        }

        public void RemoveDecorator()
        {
            PhysicsEngine.SetPauseState(false);
            this.DecoratedMario.SetSmall();
            
            World.Instance.Player = new HitStunMario(DecoratedMario);

        }
        public override void InvulnerableDraw()
        {

        }
        public void SpeedButtonPress(bool Button)
        {

        }
        public void SetEndUpwardForce(bool EndUpwardForce)
        {

        }

        public void SetSmall()
        {

        }
        public void Land()
        {

        }
        public void EnemyJump() { }
        public void SetSingleJump(bool OneJump) { }

        public void Win()
        {
            
        }

        public void Disappear()
        {
            
        }
    }
}

