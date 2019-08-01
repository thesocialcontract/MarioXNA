using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Items
{
    public class BlockCoin : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.item;
        public Vector2 WorldLocation { get; set; }
        public ISprite Sprite { get; set; }
        public Collider Collider { get; set; }

        private Animation animation;

        public BlockCoin(Vector2 position)
        {
            WorldLocation = position;
            Sprite = SpriteFactory.Instance.CreateSpawningCoinSprite();
            Collider = null;
            var keyframes = new List<Vector3>();
            keyframes.Add(new Vector3(4.0f, -32.0f,  0.0f));
            keyframes.Add(new Vector3(4.0f, -96.0f, 0.25f));
            keyframes.Add(new Vector3(4.0f, -32.0f,  0.5f));
            animation = new Animation(keyframes);
        }



        public virtual void Draw()
        {
            animation.Draw(this.Sprite, WorldLocation);
        }

        public virtual void Update()
        {
            Sprite.Update();
            animation.Update();
            if (animation.IsDone)
                World.Instance.RemoveEntity(this);
        }
    }
}
