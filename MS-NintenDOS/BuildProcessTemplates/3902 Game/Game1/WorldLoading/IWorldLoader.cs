using System.Collections.Generic;

using Game1.Entities;
using Game1.Entities.Mario;

namespace Game1.WorldLoading
{
    public interface IWorldLoader
    {
        ICollection<IGameEntity> Load(string filename, IMario Player);
    }
}
