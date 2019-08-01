using Game1.Entities.Terrain;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.CollisionHandlers
{
    class MarioTerrainCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side)
        {
            // Determine Mario
            IMario mario = SelectMario(obj1, obj2);
            Side marioSide = DetermineSide(obj1, side);

            // Handle Collision
            switch (marioSide)
            {
                case Side.left:
                    mario.PhysicsEngine.ForceCancel(false);
                    break;
                case Side.right:
                    mario.PhysicsEngine.ForceCancel(false);
                    break;
                case Side.bottom:
                    mario.PhysicsEngine.ForceCancel(true);
                    mario.SetEndUpwardForce(true);
                    break;
                case Side.top:
                    mario.Land();
                    mario.PhysicsEngine.ForceCancel(true);
                    mario.SetEndUpwardForce(false);
                    break;
            }
        }
        
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            IMario mario = SelectMario(obj1, obj2);
            Side marioSide = DetermineSide(obj1, side);
            IGameEntity terrain = SelectTerrain(obj1, obj2);

            if(terrain is Flagpole flagpole)
            {
                int height = flagpole.Collider.Bounds.Bottom - mario.Collider.Bounds.Bottom;
                World.Instance.AddToScore(height * 10);
                flagpole.Win();
                mario.Win();
                WorldAudioManager.PlayMusicWin();
            }
            else
            {

                switch (marioSide)
                {
                    case Side.right:
                        mario.XPos -= depth;
                        mario.PhysicsEngine.ForceCancel(false);
                        break;
                    case Side.left:
                        mario.XPos += depth;
                        mario.PhysicsEngine.ForceCancel(false);
                        break;
                    case Side.top:
                        mario.YPos += depth;
                        mario.PhysicsEngine.ForceCancel(true);
                        mario.SetEndUpwardForce(true);
                        break;
                    case Side.bottom:
                        mario.YPos -= depth;
                        mario.Land();
                        mario.PhysicsEngine.ForceCancel(true);
                        mario.SetEndUpwardForce(false);
                        break;
                }

            }
        }

        private Side SwapSide(Side side)
        {
            Side swappedSide;
            switch (side)
            {
                case Side.left:
                    swappedSide = Side.right;
                    break;
                case Side.right:
                    swappedSide = Side.left;
                    break;
                case Side.top:
                    swappedSide = Side.bottom;
                    break;
                default:
                    swappedSide = Side.top;
                    break;
            }

            return swappedSide;
        }
        private IMario SelectMario(IGameEntity obj1, IGameEntity obj2)
        {
            IMario mario = obj1 is IMario 
                ? (IMario)obj1 
                : (IMario)obj2;
            return mario;
        }
        private IGameEntity SelectTerrain(IGameEntity obj1, IGameEntity obj2)
        {
            IGameEntity terrain = obj1.ColliderCategory == ColliderCategories.terrain ? obj1 : obj2;
            return terrain;
        }
        private Side DetermineSide(IGameEntity obj1, Side side)
        {
            var marioSide = side;
            if (!(obj1 is IMario))
                marioSide = SwapSide(marioSide);
            return marioSide;
        }
    }
}

