using Microsoft.Xna.Framework;
using Game1.Rendering;

namespace Game1.Entities.Pipes
{
    public class StaticDownPipe : Pipe
    {
        public StaticDownPipe(Vector2 position) : base(position)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("DownPipe");
            Collider = ColliderFactory.Instance.CreateCollider("DownPipe", this);
        }
    }
}
