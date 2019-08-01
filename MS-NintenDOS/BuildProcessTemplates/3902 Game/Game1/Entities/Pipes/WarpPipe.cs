using Microsoft.Xna.Framework;
using Game1.Rendering;
using Game1.WorldLoading;

namespace Game1.Entities.Pipes
{
    public class WarpPipe : Pipe
    {
        public int WarpID { get; set; }
        public int WarpTo { get; set; }
        public WarpPipe(Vector2 position, int WarpID, int WarpTo) : base(position)
        {
            Sprite = SpriteFactory.Instance.CreateSprite("DownPipe");
            Collider = ColliderFactory.Instance.CreateCollider("DownPipe", this);
            this.WarpID = WarpID;
            this.WarpTo = WarpTo;
        }
        public override void Warp()
        {
            if(WarpTo > 0)
            {
                WarpPipe Destination = null;
                foreach (IGameEntity entity in World.Instance.GameEntities)
                {
                    if (entity is WarpPipe pipe)
                    {
                        if(pipe.WarpID == this.WarpTo)
                        {
                            Destination = pipe;
                        }
                    }
                }
                if (Destination != null)
                {
                    World.Instance.Player.WorldLocation = new Vector2(
                        Destination.WorldLocation.X,
                        Destination.WorldLocation.Y - World.Instance.Player.Collider.Bounds.Height);
                }
            }
        }
    }
}
