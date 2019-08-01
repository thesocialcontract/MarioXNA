using Game1.WorldLoading.ProceduralGenerator.Chunks;
using System;
using System.Collections.Generic;

namespace Game1.WorldLoading.ProceduralGenerator
{
    public class RiskRewardContext : AbstractGameplayContext
    {
        public RiskRewardContext()
        {
            compatibleChunks = new List<string>()
            {
                ChunkFilepaths.RoofValley,
                ChunkFilepaths.RoofValleyHorde,
                ChunkFilepaths.ThreePathRiskReward,
                ChunkFilepaths.ThreePathRiskRewardValleyRoof
            };
        }
    }
}
