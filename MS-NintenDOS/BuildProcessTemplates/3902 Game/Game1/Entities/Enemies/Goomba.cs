using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Enemies
{
    public class Goomba : Enemy
    {
        private Vector2 velocity = new Vector2(1, 0); //TODO tune
        public Goomba(Vector2 location)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("Goomba");
            WorldLocation = location;
            Rectangle bounds = new Rectangle((int)location.X, (int)location.Y, Sprite.Width, Sprite.Height);
            Collider = ColliderFactory.Instance.CreateCollider("Goomba", this);
            PhysicsEngine = new ObjectPhysicsEngine(this, 0);
            PhysicsEngine.SetVelocity(velocity);
        }

        public override void Update()
        {
            base.Update();
            Collider = ColliderFactory.Instance.CreateCollider("Goomba", this);
        }
        public override void TakeDamage()
        {
            base.TakeDamage();
            GoombaStomped stomped = new GoombaStomped(this.WorldLocation);
            World.Instance.AddEntity(stomped);
        }
        public override void Kill()
        {
            base.Kill();
            GoombaFlipped flipped = new GoombaFlipped(this.WorldLocation);
            World.Instance.AddEntity(flipped);
        }
        
    }
}
