using Microsoft.Xna.Framework;
using Game1.Entities.Blocks.States;

namespace Game1.Entities.Blocks
{
    public class BaseBlock : AbstractBlock
    {
        public BaseBlock(Vector2 position) : base(position)
        {
            State = new BumpedBlockState(this, "BaseBlock");
        }
    }
}
