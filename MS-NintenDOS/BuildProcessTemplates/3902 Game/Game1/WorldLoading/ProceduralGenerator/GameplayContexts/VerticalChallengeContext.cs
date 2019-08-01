using Game1.WorldLoading.ProceduralGenerator.Chunks;
using System;
using System.Collections.Generic;

namespace Game1.WorldLoading.ProceduralGenerator
{
    public class VerticalChallengeContext : AbstractGameplayContext
    {
        public VerticalChallengeContext()
        {
            compatibleChunks = new List<string>()
            {
                ChunkFilepaths.HordePillarGap,
                ChunkFilepaths.PillarGapItems,
                ChunkFilepaths.ThreePath,
                ChunkFilepaths.ThreePath,
                ChunkFilepaths.RampPillars,
                ChunkFilepaths.RampPillarsItem
            };
        }
    }
}
