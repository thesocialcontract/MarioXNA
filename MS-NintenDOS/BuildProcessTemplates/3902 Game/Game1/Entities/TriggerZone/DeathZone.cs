using Microsoft.Xna.Framework;

namespace Game1.Entities.TriggerZone
{
    class DeathZone : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.triggerZone;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider { get; set; }

        public DeathZone(Vector2 position, int blockLength)
        {
            WorldLocation = position;
            var translatedBlocks = WorldLoading.WorldHelpers.BlockCoordsToWorldCoords(blockLength, 0);
            Point size = new Point((int)translatedBlocks.X, (int)translatedBlocks.X);
            Point loc = new Point((int)position.X, (int)position.Y);
            Rectangle bounds = new Rectangle(loc, size);
            Collider = ColliderFactory.CreateCollider(this, bounds);
        }

        public void Draw() { }

        public void Update() { }
    }
}
