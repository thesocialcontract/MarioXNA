using Game1.Entities.TriggerZone;

namespace Game1.Entities.Items.CollisionHandlers
{
    public class ItemTriggerZoneCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            // Select Collisions
            Item item = null;
            if (obj1 is Item || obj2 is Item)
                item = (obj1 is Item) ? (Item)obj1 : (Item)obj2;
            else return;

            if (obj1 is DeathZone || obj2 is DeathZone)
                item.Destroy();
        }
    }
}
