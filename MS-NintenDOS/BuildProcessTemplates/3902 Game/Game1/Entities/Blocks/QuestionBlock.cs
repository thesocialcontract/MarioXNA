using Microsoft.Xna.Framework;
using Game1.Entities.Blocks.States;

namespace Game1.Entities.Blocks
{
    public class QuestionBlock : AbstractBlock, IContainableBlock
    {
        public BlockContent Content { get; set; }
        public QuestionBlock(Vector2 position) : base(position)
        {
            State = new BumpableBlockState(this, "QuestionBlock");
            Content = null;
        }

        public QuestionBlock(Vector2 position, string contentType, int numItems, float bumpTimer) : base(position)
        {
            State = new BumpableBlockState(this, "QuestionBlock");
            Content = new BlockContent(this, contentType, numItems, bumpTimer);
        }

        public override void Bump(bool isMarioBig)
        {
            State.Bump(isMarioBig);
        }
    }
}
