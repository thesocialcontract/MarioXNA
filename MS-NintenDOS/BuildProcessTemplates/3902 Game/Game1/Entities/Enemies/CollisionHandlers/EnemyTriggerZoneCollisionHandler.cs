using Game1.Entities.TriggerZone;

namespace Game1.Entities.Enemies.CollisionHandlers
{
    class EnemyTriggerZoneCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            // Select Collisions
            Enemy enemy = null;
            if (obj1 is Enemy || obj2 is Enemy)
                enemy = (obj1 is Enemy) ? (Enemy)obj1 : (Enemy)obj2;
            else return;

            if (obj1 is DeathZone || obj2 is DeathZone)
                enemy.Destroy();
        }
    }
}
