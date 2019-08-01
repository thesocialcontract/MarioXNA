using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Globals;
using Game1.Entities.Mario;
using Game1.Rendering;
using Game1.Audio;
using Game1.Scenes;
using Game1.Entities;
using Game1.Entities.Background;
using Game1.Rendering.UI;
using Game1.WorldLoading;
using System;

namespace Game1
{

    public class Game1 : Game
    {      

        public GraphicsDeviceManager Graphics { get; }
        protected AudioManager Audio { get; }
        
        public SpriteBatch spriteBatch { get; set; }
        public SpriteBatch HudspriteBatch;
        private TextureList textureList;
                
        public GameHud PlayersHud { get; set; }
        public RisingTextManager RisingTextManager { get; set; }
        public SpriteFont TextFont;
        
        
        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            GameGlobals.ScreenWidth = Graphics.PreferredBackBufferWidth;
            GameGlobals.ScreenHeight = Graphics.PreferredBackBufferHeight;
        }


        protected override void Initialize()
        {
            base.Initialize();
        }
                
        protected override void LoadContent()
        {
            // Audio
            AudioManager.Instance.LoadContent(Content);

            // Rendering
            
            TextFont = Content.Load<SpriteFont>("File");
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            HudspriteBatch = new SpriteBatch(GraphicsDevice);
            textureList = TextureList.Instance;
            textureList.LoadAllTextures(Content);
            textureList.GameSpriteBatch = spriteBatch;
            SpriteFactory.Instance.LoadContent("./Rendering/Sprites.json");
            MarioSpriteFactory.Instance.LoadContent("./Entities/Mario/MarioSprites.json");
            WarioSpriteFactory.Instance.LoadContent("./Entities/Wario/WarioSprites.json");
            BackgroundSpriteFactory.Instance.LoadContent("./Entities/Background/BackgroundSprites.json");
            ColliderFactory.Instance.LoadContent("./Entities/ColliderData.json");

            // Level
            SceneManager.Instance.Game = this;
            SceneManager.Instance.LoadScene(new MenuScene(this));
            

            
        }
                
        protected override void UnloadContent()
        {
            //Not implemented for this size of project
        }

        public static void Reset()
        {
            SceneManager.Instance.ReloadScene();
        }

        protected override void Update(GameTime gameTime)
        { 
            base.Update(gameTime);
            GameGlobals.GameTime = gameTime;
            SceneManager.Instance.Update();
            PlayersHud?.Update();
            

        }


        protected override void Draw(GameTime gameTime)
        {
            SceneManager.Instance.Draw();
            HudspriteBatch.Begin();
            PlayersHud?.Draw();
            
            HudspriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
