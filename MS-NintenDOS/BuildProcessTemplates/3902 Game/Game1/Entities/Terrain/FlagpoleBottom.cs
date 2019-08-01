using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Terrain
{
    class FlagpoleBottom : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.terrain;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider { get; set; }
        public ISprite Sprite { get; set; }

        public FlagpoleBottom(Vector2 location)
        {
            this.WorldLocation = location;
            Collider = null;
            Sprite = SpriteFactory.Instance.CreateSprite("FlagpoleBottom", "Flagpole");
            World.Instance.AddEntity(this);
        }
        public void Draw()
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, WorldLocation);
        }

        public void Update()
        {
            Sprite.Update();
        }
    }
}
