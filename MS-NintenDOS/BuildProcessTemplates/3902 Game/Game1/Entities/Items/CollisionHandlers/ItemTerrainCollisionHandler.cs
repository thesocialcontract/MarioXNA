namespace Game1.Entities.Items.CollisionHandlers
{
    public class ItemTerrainCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            Item item = null;
            Side itemSide = side;
            if (obj1 is Item)
            {
                item = (Item)obj1;
            }
            else
            {
                item = (Item)obj2;
                switch (itemSide)
                {
                    case Side.left:
                        itemSide = Side.right;
                        break;
                    case Side.right:
                        itemSide = Side.left;
                        break;
                    case Side.top:
                        itemSide = Side.bottom;
                        break;
                    case Side.bottom:
                        itemSide = Side.top;
                        break;
                }
            }
            if (!(item is Starman) && !(item is Fireball))
            {
                switch (itemSide)
                {
                    case Side.left:
                    case Side.right:
                        item.PhysicsEngine.Bounce(itemSide, depth);
                        break;
                    case Side.bottom:
                    case Side.top:
                        item.PhysicsEngine.Hit(itemSide, depth);
                        break;
                }
            }
            else if (item is Starman)
            {
                item.PhysicsEngine.Bounce(itemSide, depth);
            }
            else
            {
                Fireball fireball = (Fireball)item;
                switch (itemSide)
                {
                    case Side.left:
                    case Side.right:
                        fireball.Explode();
                        break;
                    case Side.bottom:
                    case Side.top:
                        fireball.PhysicsEngine.Bounce(itemSide, depth);
                        break;
                }
            }
        }
    }
}
