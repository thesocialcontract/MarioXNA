using System;
using Game1.Rendering;

namespace Game1.Entities.Blocks.States
{
    class BumpedBlockState : BlockState
    {
        public BumpedBlockState(AbstractBlock block, String blockType) : base(block)
        {
            if(blockType == "UsedBlock")
            {
                Sprite = SpriteFactory.Instance.CreateSprite(blockType, "QuestionBlock");
            }
            else
            {
                Sprite = SpriteFactory.Instance.CreateSprite(blockType);
            }
        }
    }
}
