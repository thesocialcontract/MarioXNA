using Game1.Entities.Enemies;
using Microsoft.Xna.Framework;
using System;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.CollisionHandlers
{
    class MarioEnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            IMario mario;
            IEnemy enemy;
            if(obj1 is IMario)
            {
                mario = (IMario)obj1;
                enemy = (Enemy)obj2;
            }
            else
            {
                mario = (IMario)obj2;
                enemy = (Enemy)obj1;
                switch (side)
                {
                    case Side.left:
                        side = Side.right;
                        break;
                    case Side.right:
                        side = Side.left;
                        break;
                    case Side.top:
                        side = Side.bottom;
                        break;
                    case Side.bottom:
                        side = Side.top;
                        break;
                }
            }
            if (mario.isStarMario || mario.isInvulnerable)
            {
                enemy.Kill();
            }
            else if(!(mario.isInHitStun))
            {
                switch (side)
                {
                    case Side.bottom:
                        enemy.TakeDamage();
                        mario.EnemyJump();
                        mario.ConsecutiveBounces++;
                        mario.WorldLocation = new Vector2(mario.WorldLocation.X, mario.WorldLocation.Y - depth);
                        if(mario.ConsecutiveBounces > 1)
                        {
                            int score = 100 * (int)Math.Pow(mario.ConsecutiveBounces, 2);
                            World.Instance.AddToScore(score);
                            RisingTextManager.Instance.AddRisingText(score, mario.WorldLocation);
                        }
                        break;
                    case Side.left:
                    case Side.right:
                        if (enemy is KoopaShell shellPush)
                        {
                            if (shellPush.IsSliding)
                            {
                                mario.PhysicsEngine.SetPauseState(true);
                                mario.PhysicsEngine.ForceCancel(true);
                                mario.SetEndUpwardForce(true);
                                mario.TakeDamage();
                            }
                            else
                            {
                                EnemyAudioManager.PlaySfxHitShell();
                                shellPush.Push(side, depth);
                            }
                        }
                        else
                        {
                            mario.PhysicsEngine.SetPauseState(true);
                            mario.PhysicsEngine.ForceCancel(true);
                            mario.SetEndUpwardForce(true);
                            mario.TakeDamage();
                        }
                        break;
                    case Side.top: 
                        if(enemy is KoopaShell shell)
                        {
                            if (shell.IsSliding)
                            {
                                mario.PhysicsEngine.SetPauseState(true);
                                mario.PhysicsEngine.ForceCancel(true);
                                mario.SetEndUpwardForce(true);
                                mario.TakeDamage();
                            }
                            else
                            {
                                shell.TakeDamage();
                            }
                        }
                        else
                        {
                            mario.PhysicsEngine.SetPauseState(true);
                            mario.PhysicsEngine.ForceCancel(true);
                            mario.SetEndUpwardForce(true);
                            mario.TakeDamage();
                            
                        }
                        break;
                }
            }
        }

    }
}


