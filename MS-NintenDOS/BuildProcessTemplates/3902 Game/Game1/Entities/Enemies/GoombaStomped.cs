using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Enemies
{
    class GoombaStomped : IGameEntity
    {
        public ISprite Sprite { get; }
        public Vector2 WorldLocation { get; }
        public ColliderCategories ColliderCategory => ColliderCategories.enemy;
        Vector2 IGameEntity.WorldLocation { get; set; }
        public Collider Collider { get; set; }

        private float timeToLive = .5f;
        private float time = 0.0f;
        public GoombaStomped(Vector2 location)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("StompedGoomba", "Goomba");
            WorldLocation = location;
            Collider = null;

        }
        public void Update()
        {
            time += Globals.GameGlobals.dt;
            if (time >= timeToLive)
                World.Instance.RemoveEntity(this);
        }
        public void Draw()
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, WorldLocation);
        }
    }
}
