using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using Game1.Rendering;

namespace Game1.Entities.Mario
{
    class WarioSpriteFactory
    {
        private Dictionary<string, SpriteRegistrar> warioSpriteRegistrars = new Dictionary<string, SpriteRegistrar>();
        public static WarioSpriteFactory Instance { get; } = new WarioSpriteFactory();

        public void LoadContent(string spriteInfoFile)
        {
            string json = File.ReadAllText(spriteInfoFile);
            warioSpriteRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, SpriteRegistrar>>(json);
        }

        public ISprite CreateLeftCrouchingHunterWarioSprite()
        {
            Texture2D texture =  TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftCrouchingHunter"]);
        }
        public ISprite CreateLeftCrouchWalkingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftCrouchWalkingHunter"]);
        }
        public ISprite CreateLeftFacingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftFacingHunter"]);
        }
        public ISprite CreateLeftWalkingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftWalkingHunter"]);
        }
        public ISprite CreateLeftJumpingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftJumpingHunter"]);
        }
        public ISprite CreateLeftDashingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftDashingHunter"]);
        }
        public ISprite CreateLeftDashJumpingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftDashJumpingHunter"]);
        }
        public ISprite CreateLeftWinningHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftWinningHunter"]);
        }
                
        public ISprite CreateRightCrouchingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightCrouchingHunter"]);
        }
        public ISprite CreateRightCrouchWalkingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightCrouchWalkingHunter"]);
        }
        public ISprite CreateRightFacingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightFacingHunter"]);
        }
        public ISprite CreateRightWalkingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightWalkingHunter"]);
        }
        public ISprite CreateRightJumpingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightJumpingHunter"]);
        }
        public ISprite CreateRightDashingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightDashingHunter"]);
        }
        public ISprite CreateRightDashJumpingHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightDashJumpingHunter"]);
        }
        public ISprite CreateRightWinningHunterWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightWinningHunter"]);
        }
        

        public ISprite CreateLeftCrouchingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftCrouchingViking"]);
        }
        public ISprite CreateLeftCrouchWalkingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftCrouchWalkingViking"]);
        }
        public ISprite CreateLeftFacingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftFacingViking"]);
        }
        public ISprite CreateLeftWalkingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftWalkingViking"]);
        }
        public ISprite CreateLeftJumpingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftJumpingViking"]);
        }
        public ISprite CreateLeftDashingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftDashingViking"]);
        }
        public ISprite CreateLeftDashJumpingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftDashJumpingViking"]);
        }
        public ISprite CreateLeftWinningVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftWinningViking"]);
        }
        public ISprite CreateLeftGroundPoundingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftGroundPoundingViking"]);
        }
        

        public ISprite CreateRightCrouchingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightCrouchingViking"]);
        }
        public ISprite CreateRightCrouchWalkingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightCrouchWalkingViking"]);
        }
        public ISprite CreateRightFacingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightFacingViking"]);
        }
        public ISprite CreateRightWalkingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightWalkingViking"]);
        }
        public ISprite CreateRightJumpingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightJumpingViking"]);
        }
        public ISprite CreateRightDashingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightDashingViking"]);
        }
        public ISprite CreateRightDashJumpingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightDashJumpingViking"]);
        }
        public ISprite CreateRightWinningVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightWinningViking"]);
        }
        public ISprite CreateRightGroundPoundingVikingWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightGroundPoundingViking"]);
        }
       

        public ISprite CreateLeftFacingSmallWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftFacingSmall"]);
        }
        public ISprite CreateLeftWalkingSmallWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftWalkingSmall"]);
        }
        public ISprite CreateLeftJumpingSmallWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftJumpingSmall"]);
        }
        public ISprite CreateLeftWinningSmallWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftWinningSmall"]);
        }

        

        public ISprite CreateRightFacingSmallWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightFacingSmall"]);
        }
        public ISprite CreateRightWalkingSmallWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightWalkingSmall"]);
        }
        public ISprite CreateRightJumpingSmallWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightJumpingSmall"]);
        }
        public ISprite CreateRightWinningSmallWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightWinningSmall"]);
        }
        
        public ISprite CreateRightCrouchingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightCrouchingJet"]);
        }
        public ISprite CreateRightCrouchWalkingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightCrouchWalkingJet"]);
        }
        public ISprite CreateRightFacingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightFacingJet"]);
        }
        public ISprite CreateRightWalkingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightWalkingJet"]);
        }
        public ISprite CreateRightJumpingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightJumpingJet"]);
        }
        public ISprite CreateRightDashingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightDashingJet"]);
        }
        
        public ISprite CreateRightWinningJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["RightWinningJet"]);
        }
        //STOP HERE
        public ISprite CreateLeftCrouchingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftCrouchingJet"]);
        }
        public ISprite CreateLeftCrouchWalkingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftCrouchWalkingJet"]);
        }
        public ISprite CreateLeftFacingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftFacingJet"]);
        }
        public ISprite CreateLeftWalkingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftWalkingJet"]);
        }
        public ISprite CreateLeftJumpingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftJumpingJet"]);
        }
        public ISprite CreateLeftDashingJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftDashingJet"]);
        }

        public ISprite CreateLeftWinningJetWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["LeftWinningJet"]);
        }
        public ISprite CreateDeadWarioSprite()
        {
            Texture2D texture = TextureList.Instance.GetTexture("AllWario");
            return new Sprite(texture, warioSpriteRegistrars["DeadWario"]);
        }
        
    }
}