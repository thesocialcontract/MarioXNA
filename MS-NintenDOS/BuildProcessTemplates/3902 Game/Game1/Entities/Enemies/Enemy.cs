using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Enemies
{
    public abstract class Enemy : IGameEntity, IEnemy
    {
        public ColliderCategories ColliderCategory => ColliderCategories.enemy;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider { get; set; }
        public ObjectPhysicsEngine PhysicsEngine { get; set; }
        public ISprite Sprite { get; set; }

        public virtual void TakeDamage()
        {
            World.Instance.AddToScore(100);
            RisingTextManager.Instance.AddRisingText(100, WorldLocation);
            EnemyAudioManager.PlaySfxStomp();
            Destroy();
        }

        public virtual void Kill()
        {
            World.Instance.AddToScore(100);
            RisingTextManager.Instance.AddRisingText(100, WorldLocation);
            EnemyAudioManager.PlaySfxStomp();
            Destroy();
        }

        public virtual void Destroy()
        {
            World.Instance.RemoveEntity(this);
        }

        public virtual void Draw()
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, WorldLocation);
        }
        public virtual void Update()
        {
            PhysicsEngine?.Update();
            Sprite.Update();
        }
        
    }
}
