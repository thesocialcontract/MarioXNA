using System;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Blocks.States
{
    class BumpableBlockState : BlockState
    {
        internal BumpableBlockState(AbstractBlock block, String blockType) : base(block)
        {
            if (string.IsNullOrEmpty(blockType)) return;

            Sprite = blockType == "UsedBlock"
                ? SpriteFactory.Instance.CreateSprite(blockType, "QuestionBlock")
                : SpriteFactory.Instance.CreateSprite(blockType);
        }

        public override void Bump(bool isMarioBig)
        {
            var container = ((IContainableBlock)Block);
            
            // Empty Blocks, and Brick Block Explosion
            if (container.Content == null)
            {
                if (Block is BrickBlock && isMarioBig)
                {
                    Block.State = new BreakingBlockState(Block);
                }
                else
                {
                    BlockAudioManager.PlaySfxBump();
                    Block.State = new BumpingBlockState(Block, typeof(BrickBlock).Name);
                }
                return;
            }

            // Non-Empty Blocks
            container.Content?.Eject(isMarioBig);
            World.Instance.AddToScore(50);
            bool isDone = container.Content?.IsEmpty ?? true;
            if (isDone)
                Block.State = new BumpingBlockState(Block, typeof(UsedBlock).Name, true);
            else
                Block.State = new BumpingBlockState(Block, Block.GetType().Name);
        }
    }
}
