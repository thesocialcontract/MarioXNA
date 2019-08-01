using Game1.Entities.Pipes;

namespace Game1.Entities.Mario.CollisionHandlers
{
    class MarioPipeCollisionHandler : ICollisionHandler
    {

        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            IMario mario;
            Pipe pipe;
            if (obj1 is IMario)
            {
                mario = (IMario)obj1;
                pipe = (Pipe)obj2;
                switch (side)
                {
                    case Side.bottom:
                        mario.YPos -= depth;
                        mario.Land();
                        mario.PhysicsEngine.ForceCancel(true);
                        mario.SetEndUpwardForce(false);
                        if(mario.isCrouching)
                            pipe.Warp();
                        break;
                    case Side.left:
                        mario.XPos += depth;
                        if (mario.isCrouching)
                        {
                            pipe.Warp();
                        }
                        mario.PhysicsEngine.ForceCancel(false);
                        break;
                    case Side.right:
                        mario.XPos -= depth;
                        mario.PhysicsEngine.ForceCancel(false);
                        break;
                    case Side.top:
                        mario.YPos += depth;
                        mario.PhysicsEngine.ForceCancel(true);
                        mario.SetEndUpwardForce(true);
                        break;
                }
            }
            else
            {
                mario = (IMario)obj2;
                pipe = (Pipe)obj2;
                switch (side)
                {
                    case Side.bottom:
                        mario.YPos += depth;
                        mario.PhysicsEngine.ForceCancel(true);
                        mario.SetEndUpwardForce(false);
                        break;
                    case Side.left:
                        mario.XPos -= depth;
                        mario.PhysicsEngine.ForceCancel(false);
                        break;
                    case Side.right:
                        mario.XPos += depth;
                        mario.PhysicsEngine.ForceCancel(false);
                        break;
                    case Side.top:
                        mario.YPos -= depth;
                        mario.Land();
                        mario.PhysicsEngine.ForceCancel(true);
                        mario.SetEndUpwardForce(true);
                        if(mario.isCrouching)
                        {
                            pipe.Warp();
                        }
                        break;
                }
            }
        }
    }
}

