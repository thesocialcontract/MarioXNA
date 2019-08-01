using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Pipes
{
    public abstract class Pipe : IGameEntity
    {
        protected Pipe(Vector2 position)
        {
            WorldLocation = position;
        }
        public ColliderCategories ColliderCategory => ColliderCategories.pipe;
        public Vector2 WorldLocation { get; set; }
        public ISprite Sprite { get; set; }
        public Collider Collider { get; set; }

        public virtual void Draw()
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, WorldLocation);
        }

        public virtual void Update()
        {
            Sprite.Update();
        }
        public virtual void Warp() { }
    }
}
