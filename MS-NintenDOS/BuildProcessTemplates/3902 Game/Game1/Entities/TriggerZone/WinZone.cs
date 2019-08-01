using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.TriggerZone
{
    class WinZone : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.triggerZone;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider { get; set; }

        public ISprite Sprite { get; set; }

        public WinZone(Vector2 position, int blockLength)
        {
            WorldLocation = position;
            Point size = new Point(blockLength, blockLength);
            Point loc = new Point((int)position.X, (int)position.Y);
            Rectangle bounds = new Rectangle(loc, size);
            Collider = ColliderFactory.CreateCollider(this, bounds);
            
        }
        public void Draw()
        {
            
        }

        public void Update()
        {
            
        }
    }
}
