using Microsoft.Xna.Framework;

namespace Game1.Entities
{
    public interface IGameEntity : IUpdatable, IDrawable
    {
        ColliderCategories ColliderCategory { get; }
        Vector2 WorldLocation { get; set; }
        Collider Collider { get; set; }
    }
}
