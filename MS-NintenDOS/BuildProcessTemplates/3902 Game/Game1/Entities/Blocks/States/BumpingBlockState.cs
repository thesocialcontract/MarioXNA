using Globals;
using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Blocks.States
{
    class BumpingBlockState : BlockState
    {
        private const int bumpPixelHeight = 5;
        private float animationLengthSeconds = .5f;
        private float animationHalfPoint;
        private float currentSeconds = 0.0f;
        private int currentBumpPixelHeight = 0;
        private string blockType;
        private bool isFinalBump;

        public BumpingBlockState(AbstractBlock block, string blockType, bool isFinalBump = false) : base(block)
        {
            animationHalfPoint = animationLengthSeconds / 2.0f;
            this.isFinalBump = isFinalBump;
            this.blockType = blockType;

            Sprite = blockType == "UsedBlock"
                ? SpriteFactory.Instance.CreateSprite(blockType, "QuestionBlock")
                : SpriteFactory.Instance.CreateSprite(blockType);
        }

        public override void Update()
        {
            base.Update();
            var dt = GameGlobals.dt;
            currentSeconds += dt;
            if (currentSeconds <= animationHalfPoint)
            {   // PixelHeight * ratio animated (from 0-1)
                currentBumpPixelHeight = (int)(bumpPixelHeight * currentSeconds / animationHalfPoint);
            }
            else if (currentSeconds <= animationLengthSeconds)
            {
                currentBumpPixelHeight = (int)(bumpPixelHeight * (1.0f - currentSeconds / animationLengthSeconds));
            }
            else if (isFinalBump)
            {
                Block.State = new BumpedBlockState(Block, blockType);
            }
            else
            {
                Block.State = new BumpableBlockState(Block, blockType);
            }
        }

        public override void Draw(Vector2 location)
        {
            location.Y -= currentBumpPixelHeight;
            base.Draw(location);
        }
    }
}
