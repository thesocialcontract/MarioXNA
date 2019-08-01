namespace Game1.Entities.Enemies.CollisionHandlers
{
    class EnemyEnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            Enemy enemy1 = (Enemy)obj1;
            Enemy enemy2 = (Enemy)obj2;
            if(enemy1 is KoopaShell ks1)
            {
                if (ks1.IsSliding)
                {
                    enemy2.Kill();
                    ks1.AddKill();
                }
                else
                {
                    BounceEnemies(side, enemy2, depth, false);
                }
            }
            else if(enemy2 is KoopaShell ks2)
            {
                if (ks2.IsSliding)
                {
                    enemy1.Kill();
                    ks2.AddKill();
                }
                else
                {
                    BounceEnemies(side, enemy1, depth, true);
                }
            }
            else
            {
                BounceEnemies(side, enemy1, depth, true);
                BounceEnemies(side, enemy2, 0, false);
            }
        }
        private static void BounceEnemies(Side side, Enemy enemy, float depth, bool IsEnemy1)
        {
            if (!IsEnemy1)
            {
                switch (side)
                {
                    case Side.left:
                        side = Side.right;
                        break;
                    case Side.right:
                        side = Side.left;
                        break;
                    default:
                        break;
                }
            }
            switch (side)
            {
                case Side.left:
                    enemy.PhysicsEngine.Bounce(Side.left, depth);
                    break;
                case Side.right:
                    enemy.PhysicsEngine.Bounce(Side.right, depth);
                    break;
                default:
                    break;
            }
        }
    }
}
