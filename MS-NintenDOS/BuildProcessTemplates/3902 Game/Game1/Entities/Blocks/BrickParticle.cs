using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Blocks
{
    public class BrickParticle : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.none;
        public Vector2 WorldLocation { get; set; }
        public ISprite Sprite { get; set; }
        public Collider Collider { get; set; }
        public IPhysicsEngine PhysicsEngine { get; set; }
        private float rotation;
        private float timeToLive = .5f;
        private float time = 0.0f; // TODO: Fix Physics

        public BrickParticle(Vector2 position, float degrees)
        {
            WorldLocation = position;
            Sprite = SpriteFactory.Instance.CreateSprite("BrickParticles");
            Collider = null;
            rotation = degrees;
            PhysicsEngine = new GenericObjectPhysicsEngine2();
            var initForce = new Vector2(1, 1);
            PhysicsEngine.ApplyForce(initForce);
        }
        public void Update()
        {
            time += Globals.GameGlobals.dt;
            if (time >= timeToLive)
                World.Instance.RemoveEntity(this);
        }

        public void Draw()
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, WorldLocation, rotation);
        }
    }
}
