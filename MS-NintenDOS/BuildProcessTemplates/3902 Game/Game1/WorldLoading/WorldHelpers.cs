using Microsoft.Xna.Framework;

namespace Game1.WorldLoading
{
    static class WorldHelpers
    {
        public const float LevelSeconds = 300;
        public const float HurrySeconds = 100;
        public const int BlockSize = 32;
        public const int UndergroundArea = -5 * BlockSize;
        public const int StartingLives = 3;
        public const int LevelHeight = 450;
        public const string FirstLevelFilepath = "./WorldLoading/Levels/1-1.json";

        public static Vector2 BlockCoordsToWorldCoords(int blockX, int blockY)
        {
            var worldX = blockX * BlockSize;
            var worldY = LevelHeight - blockY * BlockSize;
            return new Vector2(worldX, worldY);
        }

        public static Vector2 WorldCoordsToBlockCoords(Vector2 position)
        {
            int blockX = (int)position.X / BlockSize;
            int blockY = (int)position.Y / BlockSize;
            return new Vector2(blockX, blockY);
        }
    }
}
