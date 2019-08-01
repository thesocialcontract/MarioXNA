using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Terrain
{
    public class Wall : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.terrain;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider { get; set; }
        public ISprite BlockSprite { get; set; }

        private int length = 1;
        private int height = 1;

        public Wall(Vector2 position, int blockLength, int blockHeight)
        {
            WorldLocation = position;
            this.length = blockLength;
            this.height = blockHeight;
            BlockSprite = SpriteFactory.Instance.CreateSprite("CaveBrick");

            // Collider
            var width = ConvertBlockDistanceToPixel(blockLength);
            var height = ConvertBlockDistanceToPixel(blockHeight);
            var blockSize = ConvertBlockDistanceToPixel(1);
            var colliderOrigin = position;
            // HACK: Draw origin is top left, so we need to remove 1 to line up with the draw function
            colliderOrigin.Y -= (height - blockSize); 
            Rectangle bounds = GetBounds(colliderOrigin, width, height);
            Collider = ColliderFactory.CreateCollider(this, bounds);
        }

        public void Draw()
        {
            Vector2 tempLocation = WorldLocation;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    BlockSprite.Draw(TextureList.Instance.GameSpriteBatch, tempLocation);
                    tempLocation.X += BlockSprite.Width;
                }
                tempLocation.X = WorldLocation.X;
                tempLocation.Y -= BlockSprite.Height;
            }
        }

        public void Update() { }
        
        private static Rectangle GetBounds(Vector2 position, int blockLength, int blockHeight)
        {
            Point origin = position.ToPoint();
            Point size = new Point(blockLength, blockHeight);
            return new Rectangle(origin, size);
        }
        
        private int ConvertBlockDistanceToPixel(int blockDistance)
        {
            return BlockSprite.Height * blockDistance;
        }

    }
}
