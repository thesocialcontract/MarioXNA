using Microsoft.Xna.Framework;

namespace Game1.Entities.Items
{
    public abstract class Mushroom : Item
    {
        private Vector2 velocity = new Vector2(2, 0); //TODO tune

        protected Mushroom(Vector2 position) : base(position)
        {
            PhysicsEngine = new ObjectPhysicsEngine(this, 0);
            PhysicsEngine.SetVelocity(velocity);
        }
    }
}
