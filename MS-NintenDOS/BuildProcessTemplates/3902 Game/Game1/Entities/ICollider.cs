using Microsoft.Xna.Framework;

namespace Game1.Entities
{
    public interface ICollider
    {
        bool IsDynamic { get; set; }
        IGameEntity Host { get; set; }
        Rectangle Bounds { get; set; }
        ColliderCategories Category { get; }
    }
}
