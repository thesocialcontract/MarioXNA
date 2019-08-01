using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Blocks.States
{
    public interface IBlockState
    {
        AbstractBlock Block { get; set; }
        ISprite Sprite { get; set; }
        Collider Collider { get; set; }
        void Bump(bool IsMarioBig);
        void Break();
        void Update();
        void Draw(Vector2 location);
    }
}
