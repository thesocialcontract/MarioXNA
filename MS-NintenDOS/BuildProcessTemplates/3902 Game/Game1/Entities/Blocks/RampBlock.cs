using Microsoft.Xna.Framework;
using Game1.Entities.Blocks.States;

namespace Game1.Entities.Blocks
{
    public class RampBlock : AbstractBlock
    {
        public RampBlock(Vector2 position) : base(position)
        {
            State = new BumpedBlockState(this, "RampBlock");
        }
    }
}
