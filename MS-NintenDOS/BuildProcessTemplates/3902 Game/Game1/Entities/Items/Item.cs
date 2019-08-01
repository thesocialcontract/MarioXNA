using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Items
{
    public abstract class Item : IGameEntity
    {
        protected Item(Vector2 position)
        {
            WorldLocation = position;
            Sprite = SpriteFactory.Instance.CreateSprite(GetType().Name);
            Collider = ColliderFactory.Instance.CreateCollider(GetType().Name, this);
        }

        public ColliderCategories ColliderCategory => ColliderCategories.item;
        public Vector2 WorldLocation { get; set; }
        public ISprite Sprite { get; set; }
        public Collider Collider { get; set; }
        public ObjectPhysicsEngine PhysicsEngine { get; set; }

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
            Collider = ColliderFactory.Instance.CreateCollider(GetType().Name, this);
            Sprite.Update();
        }
    }
}
