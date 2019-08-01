using Game1.Entities;
using Game1.Entities.Mario;
using System.Collections.Generic;

namespace Game1.WorldLoading
{
    public interface IWorldGenerator
    {
        ICollection<IGameEntity> ReloadLevel(IMario player);
        ICollection<IGameEntity> LoadNewLevel(IMario player);
    }
}