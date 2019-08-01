using Microsoft.Xna.Framework;

namespace Game1.Entities.Mario.States
{
    public interface IMarioState
    {
        Collider Collider { get; set; }

        void RunLeft();
        void RunRight();
        void SetToFire();
        void SetToBig();
        void SetToSmall();
        void SuperJump();
        void Crouch();
        void TakeDamage();
        void Die();
        void Stand();
        void Land();
        void SpecialAbility();
        void SpecialAbilityFinish();
        void Update();
        void Draw(Vector2 location);
        void InvulnerableDraw(Vector2 location);
        void Jump();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void EnemyJump();
        void Win();
    }
}