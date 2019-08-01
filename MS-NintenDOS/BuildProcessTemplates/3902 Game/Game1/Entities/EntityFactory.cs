using System;
using Microsoft.Xna.Framework;
using Game1.Entities.Terrain;
using Game1.Entities.Blocks;
using Game1.Entities.TriggerZone;
using Game1.Entities.Items;
using Game1.Entities.Background;
using Game1.Entities.Enemies;
using Game1.Entities.Pipes;
using Game1.Entities;
using Game1.WorldLoading;

namespace Game1.Entities
{
    public static class EntityFactory
    {
        public static IGameEntity Create(GameEntityRegistrar registrar)
        {
            var location = new Vector2(registrar.WorldPosX, registrar.WorldPosY);
            var WarpID = registrar.WarpID;
            var WarpTo = registrar.WarpTo;
            switch (registrar.EntityType)
            {
                case "Player":
                    return new Mario.Mario(location);
                case "Goomba":
                    return new Goomba(location);
                case "Koopa":
                    return new Koopa(location);
                case "QuestionBlock":
                    if (registrar.BlockContent != null)
                    {
                        var type = registrar.BlockContent.ContentType;
                        var numItems = registrar.BlockContent.NumItems;
                        var bumpTimer = registrar.BlockContent.TimeToGetItems;
                        return BlockFactory.CreateQuestionBlockWithContent(location, type, numItems, bumpTimer);
                    }
                    else
                    {
                        return BlockFactory.CreateQuestionBlock(location);
                    }
                case "BrickBlock":
                    if (registrar.BlockContent != null)
                    {
                        var type = registrar.BlockContent.ContentType;
                        var numItems = registrar.BlockContent.NumItems;
                        var bumpTimer = registrar.BlockContent.TimeToGetItems;
                        return BlockFactory.CreateBrickBlockWithContent(location, type, numItems, bumpTimer);
                    }
                    else
                    {
                        return BlockFactory.CreateBrickBlock(location);
                    }
                case "HiddenBlock":
                    if (registrar.BlockContent != null)
                    {
                        var type = registrar.BlockContent.ContentType;
                        var numItems = registrar.BlockContent.NumItems;
                        var bumpTimer = registrar.BlockContent.TimeToGetItems;
                        return BlockFactory.CreateHiddenBlockWithContent(location, type, numItems, bumpTimer);
                    }
                    else
                    {
                        return BlockFactory.CreateHiddenBlock(location);
                    }
                case "RampBlock":
                    return new RampBlock(location);
                case "UsedBlock":
                    return new UsedBlock(location);
                case "BaseBlock":
                    return new BaseBlock(location);
                case "Coin":
                    return ItemFactory.CreateCoin(location);
                case "StaticDownPipe":
                    return new StaticDownPipe(location);
                case "FireFlower":
                    return ItemFactory.CreateFireFlower(location);
                case "OneUpMushroom":
                    return ItemFactory.CreateOneUpMushroom(location);
                case "PowerUpMushroom":
                    return ItemFactory.CreatePowerUpMushroom(location);
                case "Starman":
                    return ItemFactory.CreateStarman(location);
                case "CloudsBig":
                    return new BackgroundGameEntity(location, BackgroundSpriteFactory.Instance.CreateBigCloudSprite());
                case "CloudsSmall":
                    return new BackgroundGameEntity(location, BackgroundSpriteFactory.Instance.CreateSmallCloudSprite());
                case "HillSmall":
                    return new BackgroundGameEntity(location, BackgroundSpriteFactory.Instance.CreateSmallHillSprite());
                case "HillBig":
                    return new BackgroundGameEntity(location, BackgroundSpriteFactory.Instance.CreateBigHillSprite());
                case "Black":
                    return new BackgroundGameEntity(location, BackgroundSpriteFactory.Instance.CreateBlackSprite());
                case "Floor":
                    return new Floor(location, registrar.BlockLength, false);
                case "CaveFloor":
                    return new Floor(location, registrar.BlockLength, true);
                case "Wall":
                    return new Wall(location, registrar.BlockLength, registrar.BlockHeight);
                case "SmallCastle":
                    return new BackgroundGameEntity(location, BackgroundSpriteFactory.Instance.CreateSmallCastleSprite());
                case "Flagpole":
                    return new Flagpole(location);
                case "DeathZone":
                    return new DeathZone(location, registrar.BlockLength);
                case "WinZone":
                    return new WinZone(location, registrar.BlockLength);
                case "WarpPipe":
                    return new WarpPipe(location, WarpID, WarpTo);
                default:
                    throw new ArgumentException(registrar.EntityType + " is not a valid EntityType", "registrar");
            }
        }
        public static IGameEntity CreateFloor(Vector2 position, int blockLength, bool inCave = false)
        {
            return new Floor(position, blockLength, inCave);
        }
        public static IGameEntity CreatePlayer(Vector2 position, Mario.IMario player)
        {
            
            if (player is Mario.Wario)
                return new Mario.Wario(position);

            return new Mario.Mario(position);
        }
        public static IGameEntity CreateDeathZone(Vector2 position, int blockLength)
        {
            return new DeathZone(position, blockLength);
        }
    }
}
