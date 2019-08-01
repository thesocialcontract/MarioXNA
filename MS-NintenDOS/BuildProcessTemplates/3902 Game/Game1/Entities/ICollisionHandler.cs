namespace Game1.Entities
{
    public interface ICollisionHandler
    {
        void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth);
    }
}