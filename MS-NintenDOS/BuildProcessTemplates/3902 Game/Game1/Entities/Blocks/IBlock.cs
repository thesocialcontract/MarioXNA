using Game1.Entities.Blocks.States;
namespace Game1.Entities.Blocks
{
    public interface IBlock : IGameEntity
    {
        IBlockState State { get; set; }
        void Bump(bool isMarioBig);
    }
}
