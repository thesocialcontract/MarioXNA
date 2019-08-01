using Microsoft.Xna.Framework;
using Game1.Entities.Blocks.States;

namespace Game1.Entities.Blocks
{
    public class BrickBlock : AbstractBlock, IContainableBlock
    {
        public BlockContent Content { get; set; }
        public BrickBlock(Vector2 position) : base(position)
        {
            State = new BumpableBlockState(this, "BrickBlock");
            Content = null;
        }

        public BrickBlock(Vector2 position, string contentType, int numItems, float bumpTimer) : base(position)
        {
            State = new BumpableBlockState(this, "BrickBlock");
            Content = new BlockContent(this, contentType, numItems, bumpTimer);
        }

        private Vector2 GetTranslatedWorldLocation(float dx, float dy)
        {
            return new Vector2(WorldLocation.X + dx, WorldLocation.Y + dy);
        }

        public override void Bump(bool isMarioBig)
        {
            State.Bump(isMarioBig);
        }
    }
}
