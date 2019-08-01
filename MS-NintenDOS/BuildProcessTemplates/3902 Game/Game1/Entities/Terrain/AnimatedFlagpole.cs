using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Terrain
{
    class AnimatedFlagpole : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.terrain;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider { get; set; }
        public ISprite Sprite { get; set; }
        private int Timer;
        public AnimatedFlagpole(Vector2 location)
        {
            this.WorldLocation = location;
            this.WorldLocation = new Vector2(WorldLocation.X, WorldLocation.Y - 50);
            Collider = null;
            Sprite = SpriteFactory.Instance.CreateSprite("FlagpoleLowering", "Flagpole");
            Timer = 50;
            World.Instance.AddEntity(this);
        }
        public void Draw()
        {
            Sprite.Draw(TextureList.Instance.GameSpriteBatch, WorldLocation);
        }

        public void Update()
        {
            Timer--;
            Sprite.Update();
            if (Timer <= 0 )
            {
                FlagpoleBottom bottom = new FlagpoleBottom(this.WorldLocation);
                World.Instance.RemoveEntity(this);
                
            }
        }

    }
}
