using Microsoft.Xna.Framework;
using Game1.Entities.Items;
using Game1.WorldLoading;

namespace Game1.Entities.Mario
{
    public class StarMario : Player, IMario
    {
        public int Score { get; set; }
        public int Lives { get; set; }
        public int Coins { get; set; }

        // Physics
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
        public bool isInHitStun { get; set; }
        public bool isDead { get; set; }
        public FireballFactory FireballFactory
        {
            get => DecoratedMario.FireballFactory;
            set => DecoratedMario.FireballFactory = value;
        }
        public int ConsecutiveBounces { get; set; }
        public bool isCrouching
        {
            get => DecoratedMario.isCrouching;
            set => DecoratedMario.isCrouching = value;
        }

        private int Timer;

        public StarMario(Mario mario)
        {
            MarioAudioManager.PlayStarman();
            isStarMario = true;
            DecoratedMario = mario;
            MarioState = DecoratedMario.MarioState;
            XPos = DecoratedMario.XPos;
            YPos = DecoratedMario.YPos;
            PhysicsEngine = DecoratedMario.PhysicsEngine;
            Timer = 500;
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
            DecoratedMario.InvulnerableDraw();
            
        }

        public void SuperJump()
        {
            DecoratedMario.SuperJump();
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

        public void Jump()
        {
            DecoratedMario.Jump();
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
        public void SpecialAbilityFinish() {
            DecoratedMario.SpecialAbilityFinish();
        }
        public override void Update()
        {
            Timer--;
            if(Timer <= 0)
            {
                RemoveStar();
            }
            DecoratedMario.Update();
            XPos = DecoratedMario.XPos;
            YPos = DecoratedMario.YPos;
            MarioState = DecoratedMario.MarioState;
            
        }

        public void RemoveStar()
        {
            World.Instance.Player = DecoratedMario;
            World.Instance.PlayBackgroundMusic();
            DecoratedMario.isStarMario = false;
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
            
        }

        public void Land()
        {
            throw new System.NotImplementedException();
        }
        public void EnemyJump() { }

        public void SetSingleJump(bool OneJump)
        {
            DecoratedMario.SetSingleJump(OneJump);
        }

        public void Win()
        {
            DecoratedMario.Win();
        }

        public void Disappear()
        {
            DecoratedMario.Disappear();
        }
    }
}
