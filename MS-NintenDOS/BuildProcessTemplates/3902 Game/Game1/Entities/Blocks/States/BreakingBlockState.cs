using Microsoft.Xna.Framework;
using Game1.WorldLoading;

namespace Game1.Entities.Blocks.States
{
    class BreakingBlockState : BlockState
    {
        public BreakingBlockState(AbstractBlock block) : base(block)
        {
            BlockAudioManager.PlaySfxBreak();
            var dx = Collider.Bounds.Width;
            var dy = Collider.Bounds.Height;
            var posTopRight = GetTranslatedWorldLocation(dx, 0);
            var posBotLeft = GetTranslatedWorldLocation(0, dy);
            var posBotRight = GetTranslatedWorldLocation(dx, dy);
            var angleTopLeft = 0f;
            var angleTopRight = 90f;
            var angleBotLeft = 180f;
            var angleBotRight = 270f;

            var particleTopLeft = BlockFactory.CreateBrickParticle(Block.WorldLocation, angleTopLeft);
            var particleTopRight = BlockFactory.CreateBrickParticle(posTopRight, angleTopRight);
            var particleBotLeft = BlockFactory.CreateBrickParticle(posBotLeft, angleBotLeft);
            var particleBotRight = BlockFactory.CreateBrickParticle(posBotRight, angleBotRight);

            World.Instance.AddEntity(particleTopLeft);
            World.Instance.AddEntity(particleTopRight);
            World.Instance.AddEntity(particleBotLeft);
            World.Instance.AddEntity(particleBotRight);
        }

        private Vector2 GetTranslatedWorldLocation(float dx, float dy)
        {
            return new Vector2(Block.WorldLocation.X + dx, Block.WorldLocation.Y + dy);
        }

        public override void Update()
        {
            // HACK: Remove After 1 frame to allow enemies to die on collision detection
            World.Instance.RemoveEntity(this.Block);
        }

        public override void Draw(Vector2 location)
        {

        }
    }
}
