using Game1.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Game1.WorldLoading.ProceduralGenerator
{
    public interface IChunk
    {
        List<IGameEntity> GenerateContent(int posX);
    }
}
