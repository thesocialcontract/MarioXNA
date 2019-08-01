using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Game1.Entities;
using Game1.Entities.Mario;

namespace Game1.WorldLoading
{
    class WorldLoaderJson : IWorldLoader
    {
        private const int blockSize = WorldHelpers.BlockSize;
        private const int levelHeight = WorldHelpers.LevelHeight;

        public ICollection<IGameEntity> Load(string filepath, IMario player)
        {
            string json = File.ReadAllText(filepath);
            List<GameEntityRegistrar> deserialized = new JavaScriptSerializer().Deserialize<List<GameEntityRegistrar>>(json);
            ICollection<IGameEntity> entities = new List<IGameEntity>();
            foreach (var registrar in deserialized)
            {
                if (registrar.EntityType == "Player")
                {
                    var playerCoords = WorldHelpers.BlockCoordsToWorldCoords(registrar.WorldPosX, registrar.WorldPosY);
                    entities.Add(EntityFactory.CreatePlayer(playerCoords, player));
                }
                else
                {
                    var adjustedReg = ConvertBlockCoordsToWorldCoords(registrar);
                    entities.Add(EntityFactory.Create(adjustedReg));
                }
            }
            return entities;
        }

        static GameEntityRegistrar ConvertBlockCoordsToWorldCoords(GameEntityRegistrar registrar)
        {
            if (registrar.WorldPosXBlock != null)
                registrar.WorldPosX = (int)registrar.WorldPosXBlock * blockSize;
            if (registrar.WorldPosYBlock != null)
                registrar.WorldPosY = levelHeight - ((int)registrar.WorldPosYBlock * blockSize);
            return registrar;
        }
    }
}
