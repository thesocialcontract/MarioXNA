using Game1.Rendering;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Game1.WorldLoading;

namespace Game1.Entities.Enemies
{
    class KoopaFlipped : IGameEntity
    {
        public ISprite Sprite { get; }
        public Vector2 WorldLocation { get; }
        public ColliderCategories ColliderCategory => ColliderCategories.enemy;
       // public ObjectPhysicsEngine PhysicsEngine { get; set; }
        Vector2 IGameEntity.WorldLocation { get; set; }
        public Collider Collider { get; set; }
        private Animation Animation { get; set; }
        public KoopaFlipped(Vector2 location)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("FlippedKoopa", "Koopa");
            WorldLocation = location;
            Collider = null;
            var keyframes = new List<Vector3>
            {
                new Vector3(4.0f, 0f, 0.0f),
                new Vector3(6.0f, -20f, 0.1f),
                new Vector3(8.0f, 0f, 0.2f)
            };
            Animation = new Animation(keyframes);

        }
        public void Update()
        {
            Sprite.Update();
            Animation.Update();
            if (Animation.IsDone)
                World.Instance.RemoveEntity(this);
        }
        public void Draw()
        {
            Animation.Draw(this.Sprite, WorldLocation);
        }
    }
}
