using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.WorldLoading.ProceduralGenerator.Chunks
{
    public static class ChunkFilepaths
    {
        public const string ChunkFilepath = "./WorldLoading/ProceduralGenerator/Chunks/ChunkJson/";

        // Horizontal
        public const string FlatEnemies =           ChunkFilepath + "FlatEnemiesChunk.json";
        public const string FlatHorde =             ChunkFilepath + "FlatHordeChunk.json";
        public const string Gap =                   ChunkFilepath + "GapChunk.json";
        public const string GapEnemies =            ChunkFilepath + "GapChunkEnemies.json";
        public const string PipeValley =            ChunkFilepath + "PipeValleyChunk.json";
        public const string PipeValleyHorde =       ChunkFilepath + "PipeValleyHordeChunk.json";
        public const string PipeValleyHordeKoopa =  ChunkFilepath + "PipeValleyHordeKoopaChunk.json";
        public const string PipeValleyLite =        ChunkFilepath + "PipeValleyLiteChunk.json";

        // Vertical
        public const string ThreePath =             ChunkFilepath + "3Path.json";
        public const string HordePillarGap =        ChunkFilepath + "HordePillarGapChunk.json";
        public const string PillarGap =             ChunkFilepath + "PillarGapChunk.json";
        public const string PillarGapItems =        ChunkFilepath + "PillarGapItemsChunk.json";
        public const string RampPillars =           ChunkFilepath + "RampPillarsChunk.json";
        public const string RampPillarsItem =       ChunkFilepath + "RampPillarsItemChunk.json";


        // Risk Reward
        public const string ThreePathRiskReward =   ChunkFilepath + "3PathRiskRewardGap.json";
        public const string RoofValley =            ChunkFilepath + "RoofValleyChunk.json";
        public const string RoofValleyKoopa =       ChunkFilepath + "RoofValleyEnemiesChunk.json";
        public const string RoofValleyHorde =       ChunkFilepath + "RoofValleyHordeChunk.json";
        public const string ThreePathRiskRewardValleyRoof = ChunkFilepath + "ThreePathRiskRewardRoofValley.json";
    }
}
