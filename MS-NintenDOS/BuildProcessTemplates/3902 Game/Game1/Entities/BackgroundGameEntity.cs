using Game1.Rendering;
using Microsoft.Xna.Framework;

namespace Game1.Entities
{
    public class BackgroundGameEntity : IGameEntity
    {
        public ColliderCategories ColliderCategory { get; } = ColliderCategories.none;
        public ISprite Sprite { get; set; }
        public Vector2 WorldLocation { get; set; }
        public Collider Collider { get; set; }

        public BackgroundGameEntity(Vector2 location, ISprite sprite)
        {
            WorldLocation = location;
            Collider = null;
            Sprite = sprite;
        }

        public void Update()
        {
            Sprite.Update();
        }

        public void Draw()
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, WorldLocation);
        }
    }
}
