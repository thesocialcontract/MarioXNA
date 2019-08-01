using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Game1.Rendering;

namespace Game1.Entities.Mario
{
    class MarioSpriteFactory
    {
        private Dictionary<string, SpriteRegistrar> marioSpriteRegistrars = new Dictionary<string, SpriteRegistrar>();
        public static MarioSpriteFactory Instance { get; } = new MarioSpriteFactory();

        public void LoadContent(string spriteInfoFile)
        {
            string json = File.ReadAllText(spriteInfoFile);
            marioSpriteRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteRegistrar>>(json);
        }

        public ISprite CreateLeftCrouchingBigMarioSprite()
        {
            Texture2D texture =  TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftCrouchingBig"]);
        }

        public ISprite CreateLeftCrouchingFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftCrouchingFire"]);
        }

        public ISprite CreateDeadMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("DeadMario");
            return new Sprite(texture, marioSpriteRegistrars["DeadMario"]);
        }

        public ISprite CreateLeftFacingBigMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftFacingBig"]);
        }

        public ISprite CreateLeftFacingFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftFacingFire"]);
        }

        public ISprite CreateLeftFacingSmallMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftFacingSmall"]);
        }

        public ISprite CreateLeftJumpingBigMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftJumpingBig"]);
        }

        public ISprite CreateLeftJumpingFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftJumpingFire"]);
        }

        public ISprite CreateLeftJumpingSmallMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftJumpingSmall"]);
        }

        public ISprite CreateLeftRunningBigMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftRunningBig"]);
        }

        public ISprite CreateLeftRunningFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftRunningFire"]);
        }

        public ISprite CreateLeftRunningSmallMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftRunningSmall"]);
        }

        public ISprite CreateRightCrouchingBigMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightCrouchingBig"]);
        }

        public ISprite CreateRightCrouchingFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightCrouchingFire"]);
        }

        public ISprite CreateRightFacingBigMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightFacingBig"]);
        }

        public ISprite CreateRightFacingFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightFacingFire"]);
        }

        public ISprite CreateRightFacingSmallMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightFacingSmall"]);
        }

        public ISprite CreateRightJumpingBigMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightJumpingBig"]);
        }

        public ISprite CreateRightJumpingFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightJumpingFire"]);
        }

        public ISprite CreateRightJumpingSmallMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightJumpingSmall"]);
        }

        public ISprite CreateRightRunningBigMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightRunningBig"]);
        }

        public ISprite CreateRightRunningFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightRunningFire"]);
        }

        public ISprite CreateRightRunningSmallMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightRunningSmall"]);
        }
        public ISprite CreateRightWinningSmallMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightWinningSmall"]);
        }
        public ISprite CreateRightWinningBigMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightWinningBig"]);
        }
        public ISprite CreateRightWinningFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["RightWinningFire"]);
        }
        public ISprite CreateLeftWinningSmallMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftWinningSmall"]);
        }
        public ISprite CreateLeftWinningBigMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftWinningBig"]);
        }
        public ISprite CreateLeftWinningFireMarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllMario");
            return new Sprite(texture, marioSpriteRegistrars["LeftWinningFire"]);
        }
    }
}