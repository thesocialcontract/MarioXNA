using System.IO;
using System.Collections.Generic;
using System.Web.Script.Serialization;

namespace Game1.Rendering
{
    public class SpriteFactory
    {
        private Dictionary<string, SpriteRegistrar> spriteRegistrars = new Dictionary<string, SpriteRegistrar>();
        public static SpriteFactory Instance { get; } = new SpriteFactory();

        private SpriteFactory() { }

        public void LoadContent(string spriteInfoFile)
        {
            string json = File.ReadAllText(spriteInfoFile);
            spriteRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteRegistrar>>(json);
        }

        public ISprite CreateSprite(string objectName)
        {
            return new Sprite(TextureList.Instance.GetTexture(objectName), spriteRegistrars[objectName]);
        }

        public ISprite CreateSprite(string objectName, string textureName)
        {
            return new Sprite(TextureList.Instance.GetTexture(textureName), spriteRegistrars[objectName]);
        }

        public ISprite CreateUsedBlockSprite()
        {
            return new Sprite(TextureList.Instance.GetTexture("QuestionBlock"), spriteRegistrars["UsedBlock"]);
        }
        public ISprite CreateSpawningCoinSprite()
        {
            return new Sprite(TextureList.Instance.GetTexture("Coin"), spriteRegistrars["Coin"]);
        }
    }
}
