using Game1.Entities.Blocks;
using Game1.Entities.Blocks.States;

namespace Game1.Entities.Enemies.CollisionHandlers
{
    public class EnemyBlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            IBlock block = null;
            Enemy enemy = null;
            Side enemySide = side;
            if (obj1 is Enemy)
            {
                enemy = (Enemy)obj1;
                block = (IBlock)obj2;
            }
            else
            {
                enemy = (Enemy)obj2;
                block = (IBlock)obj1;
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
                    if (block.State is BumpingBlockState || block.State is BreakingBlockState)
                        enemy.Kill();
                    enemy.PhysicsEngine.Hit(enemySide, depth);
                    break;
                case Side.top:
                    enemy.PhysicsEngine.Hit(enemySide, depth);
                    break;
            }
        }
    }
}
