using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Terrain
{
    public class Floor : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.terrain;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider { get; set; }
        public float StartX { get; set; }
        public int NumFloorBlocks { get; set; }
        public ISprite BlockSprite { get; set; }
        private const int floorDepth = 10;
        
        public Floor(Vector2 position, int blockLength, bool isCave)
        {
            WorldLocation = position;
            NumFloorBlocks = blockLength;
            if (isCave)
            {
                BlockSprite = SpriteFactory.Instance.CreateSprite("CaveBaseBlock");
            }
            else
            {
                BlockSprite = SpriteFactory.Instance.CreateSprite("BaseBlock");
            }
            //TODO: Collider = ColliderFactory.Instance.CreateCollider(this, bounds);
            Collider = ColliderFactory.Instance.CreateCollider("Floor", this);
            var colliderSize = Collider.Bounds.Size;
            colliderSize.X = colliderSize.X * NumFloorBlocks;
            colliderSize.Y = colliderSize.Y * floorDepth;
            // !- It doesn't seem ok for objects to define the behavior of other objects by their internals
            Collider.Bounds = new Rectangle(Collider.Bounds.Location, colliderSize);
        }

        public void Draw()
        {
            // For general use we would want to write a generic texture tiling function
            // But since this is the only thing that needs tiled for total project completion...
            for (int y = 0; y < floorDepth; y++)
            {
                var tempLocation = WorldLocation;
                tempLocation.Y += (y * BlockSprite.Height);
                BlockSprite.Draw(TextureList.Instance.GameSpriteBatch, tempLocation);
                for (int i = 1; i < NumFloorBlocks; i++)
                {
                    tempLocation.X += BlockSprite.Width;
                    BlockSprite.Draw(TextureList.Instance.GameSpriteBatch, tempLocation);
                }
            }
        }

        public void Update() { }

    }
}
