using System;
using System.Collections.Generic;
using Game1.WorldLoading.ProceduralGenerator;

namespace Game1.WorldLoading.ProceduralGenerator
{
    public class AbstractGameplayContext : IGameplayContext
    {

        protected List<string> compatibleChunks = new List<string>();

        public virtual IChunk SelectRandomChunk()
        {
            var rand = new Random();
            var randIndex = rand.Next(0, compatibleChunks.Count);
            var chunkFile = compatibleChunks[randIndex];
            var chunk = new Chunk(chunkFile);
            return chunk;
        }
    }
}
