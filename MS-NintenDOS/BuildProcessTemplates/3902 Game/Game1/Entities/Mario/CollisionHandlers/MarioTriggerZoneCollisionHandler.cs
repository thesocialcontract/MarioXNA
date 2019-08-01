using Game1.Entities.TriggerZone;
using System.Threading;

namespace Game1.Entities.Mario.CollisionHandlers
{
    class MarioTriggerZoneCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            // Select mario
            IMario mario = null;
            if (obj1 is IMario || obj2 is IMario)
                mario = (obj1 is IMario) ? (IMario)obj1 : (IMario)obj2;
            else return;

            // Handle Collisions
            if (obj1 is DeathZone || obj2 is DeathZone)
                mario.Die();
            else if (obj1 is WinZone || obj2 is WinZone)
            {
                var winZone = (obj1 is WinZone) ? (WinZone)obj1 : (WinZone)obj2;
                WorldLoading.World.Instance.RemoveEntity(winZone);
                mario.Disappear();
            }
        }
    }
}
