using Game1.Entities;
using Game1.WorldLoading;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Game1.WorldLoading.ProceduralGenerator
{
    public class Chunk : IChunk
    {
        public string FilePath { get; set; }
        public Chunk(string filepath)
        {
            FilePath = filepath;
        }

        public List<IGameEntity> GenerateContent(int posX)
        {
            var loader = new WorldLoaderJson();
            var entities = (List<IGameEntity>)loader.Load(FilePath, World.Instance.Player);
            return TranslateChunk(entities, posX);
        }
        protected List<IGameEntity> TranslateChunk(List<IGameEntity> chunk, int blockCoordX)
        {
            return WorldGenerationHelpers.TranslateChunkToLocation(chunk, blockCoordX);
        }
    }
}
