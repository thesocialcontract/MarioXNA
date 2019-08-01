using Game1.Entities.Items;
using Game1.Entities.Mario.States;

namespace Game1.Entities.Mario
{
    public interface IMario : IUpdatable, IDrawable, IGameEntity
    {

        IMarioState MarioState { get; set; }
        IPhysicsEngine PhysicsEngine {get; set; }
        bool isDead { get; set; }
        bool isStarMario { get; set; }
        bool isInvulnerable { get; set; }
        bool isInHitStun { get; set; }
        bool isCrouching { get; set; }
        float XPos { get; set; }
        float YPos { get; set; }
        FireballFactory FireballFactory { get; set; }
        int ConsecutiveBounces { get; set; }
        int Score { get; set; }
        int Lives { get; set; }
        int Coins { get; set; }

        void RunLeft();
        void RunRight();
        void SetSmall();
        void SetFire();
        void SetBig();
        void SetStar();
        void TakeDamage();
        void SuperJump();
        void Crouch();
        void Die();
        void Jump();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Stand();
        void Land();
        void SpecialAbility();
        void SpecialAbilityFinish();
        void InvulnerableDraw();
        void SetEndUpwardForce(bool Up);
        void SpeedButtonPress(bool Button);
        void EnemyJump();
        void SetSingleJump(bool OneJump);
        void Win();
        void Disappear();
    }
}
