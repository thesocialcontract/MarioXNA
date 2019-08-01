using Game1.Entities;
namespace Game1
{
    public interface IPlayer : IUpdatable, IDrawable
    {
        IGameEntity GameEntity { get; set; }
    }
}
