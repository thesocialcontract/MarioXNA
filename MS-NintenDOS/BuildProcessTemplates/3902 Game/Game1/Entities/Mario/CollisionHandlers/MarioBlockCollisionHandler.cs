using System;
using Game1.Entities.Blocks;

namespace Game1.Entities.Mario.CollisionHandlers
{
    class MarioBlockCollisionHandler : ICollisionHandler
    {

        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            IMario mario;
            AbstractBlock block;
            String small = "Small";
            if (obj1 is IMario)
            {
                mario = (IMario)obj1;
                block = (AbstractBlock)obj2;
                bool isCurrentlyHidden = false;
                if (block is HiddenBlock hiddenBlock)
                {
                    isCurrentlyHidden = hiddenBlock.State.GetType().Name.Contains("Bumpable");
                }
                switch (side)
                {
                    case Side.bottom:
                        if (!isCurrentlyHidden)
                        {
                            mario.YPos -= depth;
                            mario.Land();
                            mario.PhysicsEngine.ForceCancel(true);
                            mario.SetEndUpwardForce(false);

                        }
                        break;
                    case Side.left:
                        if (!isCurrentlyHidden)
                        {
                            mario.XPos += depth;
                            mario.PhysicsEngine.ForceCancel(false);
                        }
                        break;
                    case Side.right:
                        if (!isCurrentlyHidden)
                        {
                            
                            mario.XPos -= depth;
                            mario.PhysicsEngine.ForceCancel(false);
                        }
                        break;
                    case Side.top:
                        String marioStateString = mario.MarioState.GetType().ToString();
                        bool marioIsJumping = marioStateString.Contains("Jumping");
                        if(!isCurrentlyHidden || marioIsJumping)
                        {
                            bool marioIsBig = !marioStateString.Contains(small);
                            block.Bump(marioIsBig);
                            //mario.MoveDown();
                            mario.PhysicsEngine.ForceCancel(true);
                            mario.SetEndUpwardForce(true);
                        }
                        break;
                }
            }
            else
            {
                mario = (IMario)obj2;
                block = (AbstractBlock)obj1;
                bool isCurrentlyHidden = false;
                if (block is HiddenBlock hiddenBlock)
                {
                    isCurrentlyHidden = hiddenBlock.State.GetType().Name.Contains("Bumpable");
                }
                switch (side)
                {
                    case Side.bottom:
                        String marioStateString = mario.MarioState.GetType().ToString();
                        bool marioIsJumping = marioStateString.Contains("Jumping");
                        if(!isCurrentlyHidden || marioIsJumping)
                        {
                            bool marioIsBig = !marioStateString.Contains(small);
                            block.Bump(marioIsBig);
                            //mario.MoveDown();
                            mario.YPos += depth;
                            mario.PhysicsEngine.ForceCancel(true);
                            mario.SetEndUpwardForce(true);
                        }
                        break;
                    case Side.left:
                        if (!isCurrentlyHidden)
                        {
                            //  mario.MoveLeft();
                            mario.XPos -= depth;
                            mario.PhysicsEngine.ForceCancel(false);
                        }
                        break;
                    case Side.right:
                        if (!isCurrentlyHidden)
                        {
                            //mario.MoveRight();
                            mario.XPos += depth;
                            mario.PhysicsEngine.ForceCancel(false);
                        }
                        break;
                    case Side.top:
                        if (!isCurrentlyHidden)
                        {
                            // mario.MoveUp();
                            mario.YPos -= depth;
                            
                            mario.Land();
                            mario.PhysicsEngine.ForceCancel(true);
                            mario.SetEndUpwardForce(false);
                        }
                        break;
                }
            }
        }
    }
}

