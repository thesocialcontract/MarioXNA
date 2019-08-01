using Microsoft.Xna.Framework;
using Game1.Entities.Blocks.States;

namespace Game1.Entities.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        public ColliderCategories ColliderCategory => ColliderCategories.block;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider
        {
            get => State.Collider;
            set => State.Collider = value;
        }
        public IBlockState State { get; set; }
        public virtual void Bump(bool isMarioBig) { }

        protected AbstractBlock(Vector2 position)
        {
            WorldLocation = position;
        }

        public virtual void Draw()
        {
            State.Draw(WorldLocation);
        }

        public virtual void Update()
        {
            State.Update();
        }
    }
}
