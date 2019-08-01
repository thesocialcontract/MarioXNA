using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Mario.States
{
    public abstract class WarioState : IMarioState
    {
        public ISprite Sprite { get; set; }
        protected Wario Wario { get; }
        protected WarioState(Wario wario)
        {
            Wario = wario;
        }
        public Collider Collider { get; set; }

        public virtual void SpecialAbility() { }

        public virtual void SpecialAbilityFinish() { }

        public virtual void Update()
        {
            Sprite.Update();
            string warioSizeString;
            if (GetType().Name.Contains("Small"))
            {
                warioSizeString = "SmallWario";
            }
            else if (GetType().Name.Contains("Crouch"))
            {
                warioSizeString = "CrouchWario";
            }
            else if (GetType().Name.Contains("Hunter"))
            {
                warioSizeString = "BigWario";
            }

            else if (GetType().Name.Contains("Viking"))
            {
                warioSizeString = "BigWario";
            }
            else
            {
                warioSizeString = "DeadWario";
            }
            Collider = ColliderFactory.Instance.CreateCollider(warioSizeString, Wario);


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
            Wario.Die();
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
        public virtual void MoveDown(){ }
        public virtual void MoveLeft() { }
        public virtual void MoveRight(){}
        public virtual void Die()
        {
           Wario.MarioState = new DeadWarioState(Wario);
        }
        public virtual void EnemyJump() { }
        public virtual void Win() { }

        
    }
}
