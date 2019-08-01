using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Enemies
{
    public class KoopaShell : Enemy
    {
        public bool IsSliding { get; set; } = false;
        public Vector2 Velocity { get; set; } = new Vector2(7, 0); //TODO tune

        private int killCount = 0;

        public KoopaShell(Vector2 location)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("KoopaShell", "Koopa");
            WorldLocation = location;
            PhysicsEngine = new ObjectPhysicsEngine(this, 0);
            PhysicsEngine.SetVelocity(Vector2.Zero);
            Collider = ColliderFactory.Instance.CreateCollider("KoopaShell", this);
        }

        public override void TakeDamage() {
            World.Instance.AddToScore(100);
            RisingTextManager.Instance.AddRisingText(100, WorldLocation);
            EnemyAudioManager.PlaySfxHitShell();
            if (IsSliding)
            {
                IsSliding = false;
                PhysicsEngine.SetVelocity(Vector2.Zero);
            }
            else
            {
                IsSliding = true;
                PhysicsEngine.SetVelocity(Velocity);
            }
        }

        public void Push(Side side, float depth)
        {
            Vector2 velocity = Velocity;
            if (side == Side.left)
            {
                velocity *= -1;
                depth *= -1;
            }
            if (IsSliding)
            {
                IsSliding = false;
                PhysicsEngine.SetVelocity(Vector2.Zero);
            }
            else
            {
                IsSliding = true;
                PhysicsEngine.SetVelocity(velocity);
                WorldLocation = new Vector2(WorldLocation.X + depth*2, WorldLocation.Y);
            }
        }

        public override void Kill()
        {
            base.Kill();
            World.Instance.AddToScore(100);
            RisingTextManager.Instance.AddRisingText(100, WorldLocation);
            KoopaFlipped flipped = new KoopaFlipped(this.WorldLocation);
            World.Instance.AddEntity(flipped);
        }

        public void AddKill()
        {
            killCount++;
            World.Instance.AddToScore(200 * killCount);
            RisingTextManager.Instance.AddRisingText((200*killCount), WorldLocation);
        }
        public override void Update()
        {
            base.Update();
            Collider = ColliderFactory.Instance.CreateCollider("KoopaShell", this);
        }
    }
}
