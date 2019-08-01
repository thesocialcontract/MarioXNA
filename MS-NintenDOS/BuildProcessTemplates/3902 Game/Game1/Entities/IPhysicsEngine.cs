using Microsoft.Xna.Framework;

namespace Game1.Entities
{
    public interface IPhysicsEngine
    {
        Vector2 Update();
        void ApplyForce(Vector2 inputVelocity);
        void ForceCancel(bool Right);
               
        void ReverseDirection(bool Up);

        void SetPauseState(bool pause);

    }
}
