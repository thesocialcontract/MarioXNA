using Game1.Entities;
using Game1.WorldLoading;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Game1
{
    public static class WorldGenerationHelpers
    {
        public const int LevelSize = 256;
        public const int ChunkSize = 24;
        public const int LevelMargin = LevelSize % ChunkSize;
        public const int NumChunks = (LevelSize - LevelMargin) / ChunkSize;
        public const string LevelEndFilepath = "./WorldLoading/ProceduralGenerator/LevelEnd.json";
        public static readonly int LevelSizeWorldCoords = (int)WorldHelpers.BlockCoordsToWorldCoords(LevelSize, 0).X;

        public static List<IGameEntity> TranslateChunkToLocation(List<IGameEntity> chunk, int blockCoordX)
        {
            foreach (var entity in chunk)
            {
                var x = entity.WorldLocation.X;
                var y = entity.WorldLocation.Y;
                var translationVector = WorldHelpers.BlockCoordsToWorldCoords(blockCoordX, 0);
                var translatedX = x + translationVector.X;
                entity.WorldLocation = new Vector2(translatedX, y);

                if (entity.Collider == null) continue;
                int translatedColliderX = entity.Collider.Bounds.X + (int)translationVector.X;
                var colliderOrigin = new Point(translatedColliderX, (int)y);
                var translatedColliderBounds = new Rectangle(colliderOrigin, entity.Collider.Bounds.Size);
                entity.Collider = ColliderFactory.CreateCollider(entity, translatedColliderBounds);
            }
            return chunk;
        }
    }
}
