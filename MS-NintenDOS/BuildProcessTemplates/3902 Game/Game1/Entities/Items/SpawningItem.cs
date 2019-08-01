using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Items
{
    public class SpawningItem : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.item;
        public Vector2 WorldLocation { get; set; }
        public ISprite Sprite { get; set; }
        public Collider Collider { get; set; }

        public SpawningItem(/*Vector2 position, Item item*/)
        {
            Collider = null;
        }

        public void Update()
        {

        }
        public void Draw()
        {

        }
    }
}
