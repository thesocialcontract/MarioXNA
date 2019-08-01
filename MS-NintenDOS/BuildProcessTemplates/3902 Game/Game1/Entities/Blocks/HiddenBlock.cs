using Microsoft.Xna.Framework;
using Game1.Entities.Blocks.States;

namespace Game1.Entities.Blocks
{
    public class HiddenBlock : AbstractBlock, IContainableBlock
    {
        public BlockContent Content { get; set; }
        private bool isBumped;

        public HiddenBlock(Vector2 position) : base(position)
        {
            State = new BumpableBlockState(this, "");
            Content = null;
            isBumped = false;
        }

        public HiddenBlock(Vector2 position, string contentType, int numItems, float bumpTimer) : base(position)
        {
            State = new BumpableBlockState(this, "");
            Content = new BlockContent(this, contentType, numItems, bumpTimer);
            isBumped = false;
        }

        public override void Bump(bool isMarioBig)
        {
            State.Bump(isMarioBig);
            if (Content?.IsEmpty ?? false)
                isBumped = true;
        }

        public override void Update()
        {
            State.Collider = ColliderFactory.Instance.CreateCollider("Block", State.Block);
            if (isBumped)
                base.Update();
        }

        public override void Draw()
        {
            if (isBumped)
                base.Draw();
        }
    }
}
