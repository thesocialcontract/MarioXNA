using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Blocks.States
{
    internal abstract class BlockState : IBlockState
    {
        public ISprite Sprite { get; set; }
        public AbstractBlock Block { get; set; }
        public Collider Collider { get; set; }

        protected BlockState(AbstractBlock block)
        {
            Block = block;
            Collider = ColliderFactory.Instance.CreateCollider("Block", Block);
        }

        public virtual void Bump(bool isMarioBig) { }

        public virtual void Break() { }

        public virtual void Update()
        {
            Sprite.Update();
        }

        public virtual void Draw(Vector2 location)
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, location);
        }
    }
}
