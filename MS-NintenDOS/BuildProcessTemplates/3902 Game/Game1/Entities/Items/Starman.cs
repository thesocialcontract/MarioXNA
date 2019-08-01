using Microsoft.Xna.Framework;

namespace Game1.Entities.Items
{
    public class Starman : Item
    {
        private Vector2 velocity = new Vector2(3, 20); //TODO tune
        public Starman(Vector2 position) : base(position)
        {
            PhysicsEngine = new ObjectPhysicsEngine(this, 0, 0.6f);
            PhysicsEngine.SetVelocity(velocity);
        }
    }
}
