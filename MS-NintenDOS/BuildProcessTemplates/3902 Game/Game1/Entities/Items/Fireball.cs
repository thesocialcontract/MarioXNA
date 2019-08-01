using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Items
{
    public class Fireball : Item
    {
        private int explosionTimer = 30;
        private bool isExploding = false;

        public Fireball(Vector2 position) : base(position)
        {
            PhysicsEngine = new ObjectPhysicsEngine(this, 0, 0.6f); //TODO tune
        }

        public Vector2 Velocity { get; set; } = new Vector2(5, 15);

        public void SetDirection(bool right)
        {
            if (right)
            {
                PhysicsEngine.SetVelocity(Velocity);
            }
            else
            {
                PhysicsEngine.SetVelocity(new Vector2(-Velocity.X, Velocity.Y));
            }
        }

        public void Explode()
        {
            isExploding = true;
            Sprite = SpriteFactory.Instance.CreateSprite("FireBurst", "Fireball");
            Collider = null;
        }

        public override void Update()
        {
            if (!isExploding)
            {
                base.Update();
            }
            else
            {
                if(explosionTimer == 0)
                {
                    Destroy();
                }
                else
                {
                    explosionTimer--;
                    Sprite.Update();
                }
            }
        }
    }
}
