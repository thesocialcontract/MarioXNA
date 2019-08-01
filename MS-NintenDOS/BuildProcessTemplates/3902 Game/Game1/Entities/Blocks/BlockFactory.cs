using Microsoft.Xna.Framework;

namespace Game1.Entities.Blocks
{
    public static class BlockFactory
    {
        public static QuestionBlock CreateQuestionBlock(Vector2 location)
        {
            return new QuestionBlock(location);
        }
        public static QuestionBlock CreateQuestionBlockWithContent(Vector2 location, string contentType, int numItems, float bumpTimer)
        {
            return new QuestionBlock(location, contentType, numItems, bumpTimer);
        }
        public static BrickBlock CreateBrickBlock(Vector2 location)
        {
            return new BrickBlock(location);
        }
        public static BrickBlock CreateBrickBlockWithContent(Vector2 location, string contentType, int numItems, float bumpTimer)
        {
            return new BrickBlock(location, contentType, numItems, bumpTimer);
        }
        public static RampBlock CreateRampBlock(Vector2 location)
        {
            return new RampBlock(location);
        }
        public static UsedBlock CreateUsedBlock(Vector2 location)
        {
            return new UsedBlock(location);
        }
        public static HiddenBlock CreateHiddenBlock(Vector2 location)
        {
            return new HiddenBlock(location);
        }
        public static HiddenBlock CreateHiddenBlockWithContent(Vector2 location, string contentType, int numItems, float bumpTimer)
        {
            return new HiddenBlock(location, contentType, numItems, bumpTimer);
        }
        public static BaseBlock CreateBaseBlock(Vector2 location)
        {
            return new BaseBlock(location);
        }

        public static BrickParticle CreateBrickParticle(Vector2 location, float degrees)
        {
            return new BrickParticle(location, degrees);
        }
    }
}
