using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Terrain
{
    class Flagpole : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.terrain;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider { get; set; }
        public ISprite Sprite { get; set; }

        public Flagpole(Vector2 position)
        {
            WorldLocation = position;
            Sprite = SpriteFactory.Instance.CreateSprite("Flagpole");
            Collider = ColliderFactory.Instance.CreateCollider("Flagpole", this);
        }

        public void Draw()
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, WorldLocation);
        }

        public void Update() { }
        public void Win()
        {
            AnimatedFlagpole flagpole = new AnimatedFlagpole(this.WorldLocation);
            World.Instance.RemoveEntity(this);
            
        }
    }
}
