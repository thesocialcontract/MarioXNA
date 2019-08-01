using Microsoft.Xna.Framework;
using Game1.Entities.Blocks;
using Game1.Entities.Blocks.States;

namespace Game1
{
    public class UsedBlock : AbstractBlock
    {
        public UsedBlock(Vector2 position) : base(position)
        {
            State = new BumpedBlockState(this, "UsedBlock");
        }
    }
}
