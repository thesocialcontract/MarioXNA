using Game1.Entities.Enemies;

namespace Game1.Entities.Items.CollisionHandlers
{
    class ItemEnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            Item item;
            Enemy enemy;
            if (obj1 is Item)
            {
                item = (Item)obj1;
                enemy = (Enemy)obj2;
            }
            else
            {
                item = (Item)obj2;
                enemy = (Enemy)obj1;
            }
            if (item is Fireball fireball)
            {
                enemy.Kill();
                fireball.Explode();
            }
        }
    }
}
