using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Game1.Rendering;

namespace Game1.Entities.Background
{
    class BackgroundSpriteFactory
    {
        private Dictionary<string, SpriteRegistrar> backgroundSpriteRegistrars = new Dictionary<string, SpriteRegistrar>();
        public static BackgroundSpriteFactory Instance { get; } = new BackgroundSpriteFactory();

        public void LoadContent(string spriteInfoFile)
        {
            string json = File.ReadAllText(spriteInfoFile);
            backgroundSpriteRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteRegistrar>>(json);
        }
        public ISprite CreateBigCloudSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("Cloud");
            return new Sprite(texture, backgroundSpriteRegistrars["CloudsBig"]);
        }
        public ISprite CreateSmallCloudSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("Cloud");
            return new Sprite(texture, backgroundSpriteRegistrars["CloudsSmall"]);
        }
        public ISprite CreateBigHillSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("Hill");
            return new Sprite(texture, backgroundSpriteRegistrars["HillBig"]);
        }
        public ISprite CreateSmallHillSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("Hill");
            return new Sprite(texture, backgroundSpriteRegistrars["HillSmall"]);
        }
        public ISprite CreateSmallCastleSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("SmallCastle");
            return new Sprite(texture, backgroundSpriteRegistrars["SmallCastle"]);
        }

        public ISprite CreateBlackSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("Black");
            return new Sprite(texture, backgroundSpriteRegistrars["Black"]);
        }
    }
}