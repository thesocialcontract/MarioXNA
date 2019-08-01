using Game1.Entities;
using Game1.WorldLoading.ProceduralGenerator;
using Game1.WorldLoading;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Game1.WorldLoading.ProceduralGenerator.Chunks;
using Game1.Entities.Mario;

namespace Game1
{
    class WorldGenerator : IWorldGenerator
    {
        private List<IChunk> chunks = new List<IChunk>();
        public ICollection<IGameEntity> ReloadLevel(IMario player)
        {
            return LoadLevel(player);
        }
        public ICollection<IGameEntity> LoadNewLevel(IMario player)
        {
            SelectNewChunks();
            return LoadLevel(player);
        }

        private ICollection<IGameEntity> LoadLevel(IMario player)
        {
            var level = GenerateEntitiesFromChunks(chunks);

            // Non Chunk Entities
            var playerCoords = WorldHelpers.BlockCoordsToWorldCoords(5, 3);
            level.Add(EntityFactory.CreatePlayer(playerCoords, player));
            level = AddEnd(level);
            level = AddDeathZone(level);
            level = AddBackground(level);

            return level;
        }

        private List<IGameEntity> GenerateEntitiesFromChunks(List<IChunk> chunks)
        {
            var entities = new List<IGameEntity>();
            entities.Add(GenerateLevelMargin());
            for (int i = 0; i < chunks.Count; i++)
            {
                var posX = (i * WorldGenerationHelpers.ChunkSize) + WorldGenerationHelpers.LevelMargin;
                var chunkEntities = chunks[i].GenerateContent(posX);
                entities.AddRange(chunkEntities);
            }
            return entities;
        }

        private void SelectNewChunks()
        {
            chunks.Clear();
            for (int i = 0; i < WorldGenerationHelpers.NumChunks; i++)
            {
                IGameplayContext context = ContextSelector.SelectRandomContext();
                IChunk chunk = context.SelectRandomChunk();
                chunks.Add(chunk);
            }
        }

        private List<IGameEntity> AddBackground(List<IGameEntity> level)
        {
            // TODO: Would love to load background data from a file
            var worldSize = WorldGenerationHelpers.LevelSizeWorldCoords;
            worldSize += WorldGenerationHelpers.LevelMargin;
            worldSize += WorldHelpers.BlockSize * 50;
            var cloudHeightMin = WorldHelpers.BlockCoordsToWorldCoords(0, 6);
            var cloudHeightMax = WorldHelpers.BlockCoordsToWorldCoords(0, 14);
            var smallHillHeightMin = WorldHelpers.BlockCoordsToWorldCoords(0, -2);
            var smallHillHeightMax = WorldHelpers.BlockCoordsToWorldCoords(0, -2);
            var largeHillHeightMin = WorldHelpers.BlockCoordsToWorldCoords(0, -2);
            var largeHillHeightMax = WorldHelpers.BlockCoordsToWorldCoords(0, -2);

            var backgroundEntities = new List<IGameEntity>();
            for (int x = -256; x < worldSize; x++)
            {


            }

            // Add level to background to put background in beginning of entity list
            backgroundEntities.AddRange(level);
            return backgroundEntities;
        }
        private IGameEntity GenerateLevelMargin()
        {
            var position = WorldHelpers.BlockCoordsToWorldCoords(-10, 0);
            return EntityFactory.CreateFloor(position, WorldGenerationHelpers.LevelMargin + 10);
        }
        private List<IGameEntity> AddEnd(List<IGameEntity> level)
        {
            var loader = new WorldLoaderJson();
            var entities = (List<IGameEntity>)loader.Load(WorldGenerationHelpers.LevelEndFilepath, World.Instance.Player);
            entities = WorldGenerationHelpers.TranslateChunkToLocation(entities, WorldGenerationHelpers.LevelSize);
            level.AddRange(entities);
            return level;
        }
        private List<IGameEntity> AddDeathZone(List<IGameEntity> level)
        {
            var position = WorldHelpers.BlockCoordsToWorldCoords(-15, -4);
            var deathZone = EntityFactory.CreateDeathZone(position, WorldGenerationHelpers.LevelSize + 200);
            level.Add(deathZone);
            return level;
        }
    }
}
