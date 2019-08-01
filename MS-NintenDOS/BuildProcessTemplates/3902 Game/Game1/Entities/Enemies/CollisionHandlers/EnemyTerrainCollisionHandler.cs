namespace Game1.Entities.Enemies.CollisionHandlers
{
    public class EnemyTerrainCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            Enemy enemy = null;
            Side enemySide = side;
            if (obj1 is Enemy)
            {
                enemy = (Enemy)obj1;
            }
            else
            {
                enemy = (Enemy)obj2;
                switch (enemySide)
                {
                    case Side.left:
                        enemySide = Side.right;
                        break;
                    case Side.right:
                        enemySide = Side.left;
                        break;
                    case Side.top:
                        enemySide = Side.bottom;
                        break;
                    case Side.bottom:
                        enemySide = Side.top;
                        break;
                }
            }
            switch (enemySide)
            {
                case Side.left:
                case Side.right:
                    enemy.PhysicsEngine.Bounce(enemySide, depth);
                    break;
                case Side.bottom:
                case Side.top:
                    enemy.PhysicsEngine.Hit(enemySide, depth);
                    break;
            }
        }
    }
}
