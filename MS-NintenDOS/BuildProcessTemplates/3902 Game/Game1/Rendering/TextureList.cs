using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Game1.Rendering
{
    public class TextureList
    {
        public SpriteBatch GameSpriteBatch { get; set; }
        public static TextureList Instance { get; } = new TextureList();
        public Dictionary<string, Texture2D> Textures { get; }

        private TextureList()
        {
            Textures = new Dictionary<string, Texture2D>();
        }

        public void LoadAllTextures(ContentManager content)
        {
            // Mario
            Textures.Add("AllMario", content.Load<Texture2D>("AllMarioSprite"));
            Textures.Add("DeadMario", content.Load<Texture2D>("DeadMarioSprite"));
            Textures.Add("AllWario", content.Load<Texture2D>("AllWarioSpriteClear"));

            // Blocks
            Textures.Add("BaseBlock", content.Load<Texture2D>("BaseSprite"));
            Textures.Add("CaveBaseBlock", content.Load<Texture2D>("CaveBaseSprite"));
            Textures.Add("BrickBlock", content.Load<Texture2D>("BrickSprite"));
            Textures.Add("QuestionBlock", content.Load<Texture2D>("QuestionBlockSprite"));
            Textures.Add("RampBlock", content.Load<Texture2D>("RampBlockSprite"));
            Textures.Add("DownPipe", content.Load<Texture2D>("DownPipeSprite"));
            Textures.Add("BrickParticles", content.Load<Texture2D>("BrickExplodedSprite"));

            // Items
            Textures.Add("Coin", content.Load<Texture2D>("CoinSprite2"));
            Textures.Add("OneUpMushroom", content.Load<Texture2D>("1UpMushroomSprite"));
            Textures.Add("Fireball", content.Load<Texture2D>("FireballSprite"));
            Textures.Add("FireFlower", content.Load<Texture2D>("FireFlowerSprite"));
            Textures.Add("Starman", content.Load<Texture2D>("StarmanSprite"));
            Textures.Add("PowerUpMushroom", content.Load<Texture2D>("MushroomSprite"));

            // Enemies
            Textures.Add("Goomba", content.Load<Texture2D>("GoombaSprite"));
            Textures.Add("Koopa", content.Load<Texture2D>("KoopaSprite"));

            // Terrain and Background
            Textures.Add("Hill", content.Load<Texture2D>("HillSprite"));
            Textures.Add("Cloud", content.Load<Texture2D>("CloudSprite"));
            Textures.Add("SmallCastle", content.Load<Texture2D>("SmallCastleSprite"));
            Textures.Add("CaveBrick", content.Load<Texture2D>("CaveBrickSprite"));
            Textures.Add("Flagpole", content.Load<Texture2D>("FlagSprite"));
            Textures.Add("Pole", content.Load<Texture2D>("FlagPole"));
            Textures.Add("Banner", content.Load<Texture2D>("FlagBanner"));
            Textures.Add("Black", content.Load<Texture2D>("BlackSprite"));

            //hud
            Textures.Add("HudCoinSprite", content.Load<Texture2D>("InnerHudCoin"));
            Textures.Add("MarioLifeSprite", content.Load<Texture2D>("MarioLifeSprite"));
            Textures.Add("WarioLifeSprite", content.Load<Texture2D>("WarioLifeSprite"));

            Textures.Add("Triangle", content.Load<Texture2D>("Triangle"));

        }

        public Texture2D GetTexture(string name)
        {
            return Textures[name];
        }
    }
}
