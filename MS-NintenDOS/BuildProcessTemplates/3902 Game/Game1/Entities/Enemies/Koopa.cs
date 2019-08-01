using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Enemies
{
    public class Koopa : Enemy
    {
        private Vector2 velocity = new Vector2(1, 0);
        private bool facingRight = true;
        public Koopa(Vector2 location)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("RightWalkingKoopa", "Koopa");
            WorldLocation = location;
            PhysicsEngine = new ObjectPhysicsEngine(this, 0);
            PhysicsEngine.SetVelocity(velocity);
            Collider = ColliderFactory.Instance.CreateCollider("WalkingKoopa", this);
        }

        public override void TakeDamage()
        {
            base.TakeDamage();
            KoopaShell shell = new KoopaShell(WorldLocation);
            World.Instance.AddEntity(shell);
        }

        public override void Update()
        {
            base.Update();
            if(facingRight && PhysicsEngine.Velocity.X < 0)
            {
                facingRight = false;
                Sprite = SpriteFactory.Instance.CreateSprite("LeftWalkingKoopa", "Koopa");
            } else if(!facingRight && PhysicsEngine.Velocity.X > 0)
            {
                facingRight = true;
                Sprite = SpriteFactory.Instance.CreateSprite("RightWalkingKoopa", "Koopa");
            }
            Collider = ColliderFactory.Instance.CreateCollider("WalkingKoopa", this);
        }
        public override void Kill()
        {
            base.Kill();
            World.Instance.AddToScore(100);
            RisingTextManager.Instance.AddRisingText(100, WorldLocation);
            KoopaFlipped flipped = new KoopaFlipped(this.WorldLocation);
            World.Instance.AddEntity(flipped);
        }
    }
}
