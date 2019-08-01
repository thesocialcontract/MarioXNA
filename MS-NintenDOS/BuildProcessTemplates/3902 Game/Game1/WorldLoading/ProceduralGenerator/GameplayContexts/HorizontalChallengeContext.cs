using Game1.WorldLoading.ProceduralGenerator.Chunks;
using System;
using System.Collections.Generic;

namespace Game1.WorldLoading.ProceduralGenerator
{
    public class HorizontalChallengeContext : AbstractGameplayContext
    {
        public HorizontalChallengeContext()
        {
            compatibleChunks = new List<string>()
            {
                ChunkFilepaths.FlatEnemies,
                ChunkFilepaths.FlatHorde,
                ChunkFilepaths.Gap,
                ChunkFilepaths.GapEnemies,
                ChunkFilepaths.PipeValley,
                ChunkFilepaths.PipeValleyHordeKoopa,
            };
        }
    }
}
