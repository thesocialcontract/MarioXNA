using Microsoft.Xna.Framework;

namespace Game1.Entities
{
    public class Collider : ICollider
    {
        public bool IsDynamic { get; set; }
        public IGameEntity Host { get; set; }
        public Rectangle Bounds { get; set; }
        public ColliderCategories Category => Host.ColliderCategory;

        public Collider(ColliderRegistrar colliderRegistrar, IGameEntity host)
        {
            int scale = colliderRegistrar.Scale;
            int xPos = (int)host.WorldLocation.X + colliderRegistrar.XOffset*scale;
            int yPos = (int)host.WorldLocation.Y + colliderRegistrar.YOffset*scale;
            int width = colliderRegistrar.Width*scale;
            int height = colliderRegistrar.Height*scale;
            IsDynamic = colliderRegistrar.IsDynamic;
            Host = host;
            Bounds = new Rectangle(xPos, yPos, width, height);
        }

        public Collider(bool isDynamic, IGameEntity host, Rectangle bounds)
        {
            IsDynamic = isDynamic;
            Host = host;
            Bounds = bounds;
        }
    }
}
