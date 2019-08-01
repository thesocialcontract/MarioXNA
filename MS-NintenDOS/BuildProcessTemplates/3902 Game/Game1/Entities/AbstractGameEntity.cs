using Microsoft.Xna.Framework;
using Game1.WorldLoading;

namespace Game1.Entities
{
    public class AbstractGameEntity : IGameEntity
    {
        public virtual ColliderCategories ColliderCategory { get; } 
        public virtual Vector2 WorldLocation { get; set; }
        public virtual Collider Collider { get; set; }
        
        public virtual void Destroy()
        {
            // TODO: Decouple with WorldCommands
            World.Instance.RemoveEntity(this);
        }

        public virtual void Update() { }

        public virtual void Draw() { }
    }
}
