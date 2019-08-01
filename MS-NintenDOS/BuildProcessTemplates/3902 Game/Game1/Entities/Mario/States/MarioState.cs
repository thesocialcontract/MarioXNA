using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Mario.States
{
    public abstract class MarioState : IMarioState
    {
        public ISprite Sprite { get; set; }
        protected Mario Mario { get; }
        protected MarioState(Mario mario)
        {
            Mario = mario;
        }
        public Collider Collider { get; set; }

        public virtual void SpecialAbility() { }
        public void SpecialAbilityFinish() { }
        public virtual void Update()
        {
            Sprite.Update();
            string marioSizeString;
            if (GetType().Name.Contains("Small"))
            {
                marioSizeString = "SmallMario";
            } else if (GetType().Name.Contains("Big"))
            {
                marioSizeString = "BigMario";
            } else if (GetType().Name.Contains("Fire"))
            {
                marioSizeString = "FireMario";
            }
            else
            {
                marioSizeString = "DeadMario";
            }
            Collider = ColliderFactory.Instance.CreateCollider(marioSizeString, Mario);
        }
        public virtual void Draw(Vector2 location)
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, location);
        }
        public virtual void InvulnerableDraw(Vector2 location)
        {
            Sprite.InvulnerableDraw(TextureList.Instance.GameSpriteBatch, location);
        }
        protected void SetSprite(ISprite sprite)
        {
            Sprite = sprite;
        }

        public virtual void TakeDamage()
        {
            Mario.Die();
        }
        
        public virtual void RunLeft(){ }
        public virtual void RunRight() { }
        public virtual void SetToFire(){ }
        public virtual void SetToBig(){ }
        public virtual void SetToSmall(){ }
        public virtual void SuperJump(){ }
        public virtual void Stand(){ }
        public virtual void Land() { }
        public virtual void Crouch(){ }
        public virtual void Jump() { }
        public virtual void MoveDown()
        {
            Mario.PhysicsEngine.ForceCancel(false);

        }
        public virtual void MoveLeft() { }
        public virtual void MoveRight(){}
        public virtual void Die()
        {
            Mario.MarioState = new DeadMarioState(Mario);
        }
        public virtual void EnemyJump() { }
        public virtual void Win() { }

        
    }
}
