using Game1.Input.Commands;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Game1.Input.Controllers;
using Game1.Rendering.UI;
using Game1.WorldLoading;
using Game1.Entities.Mario;
using Game1.Rendering;

namespace Game1.Scenes
{
    public class WorldScene : IScene
    {
        public Game1 Game { get; set; }
        public ContentManager Content { get; set; }
        public GraphicsDeviceManager Graphics { get; set; }
        public World Level { get; set;}
        public String WorldString { get; set; }
        public GameHud PlayersHud { get; set; }
        public RisingTextManager RisingTextManager { get; set; }
        public int MarioLives { get; set; }

        private IController keyboard;
        private GamepadController3 gamepad;
        private SpriteFont RisingTextFont;
        public IMario Player { get; set; }
        public WorldScene(String world, int lives, IMario player)
        {
            Level = World.Instance;
            Game = SceneManager.Instance.Game;
            WorldString = world;
            Content = Game.Content;
            Graphics = Game.Graphics;
            MarioLives = lives;
            Level.ScreenHeight = Game.Graphics.PreferredBackBufferHeight;
            Level.ScreenWidth = Game.Graphics.PreferredBackBufferWidth;
            RisingTextFont = Content.Load<SpriteFont>("RisingTextFont");
            RisingTextManager = RisingTextManager.ResetTEXT(RisingTextFont);


            var score = Player?.Score ?? 0;
            var coins = Player?.Coins ?? 0;
            Player = player;
            Player.Score = score;
            Player.Coins = coins;
            Player.Lives = lives;
        }
        public void Draw()
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);

            Game.spriteBatch.Begin(transformMatrix: Level.Camera.TranformationMatrix);

            Level.Draw();
            RisingTextManager.Draw();
            Game.spriteBatch.End();
        }

        public void LoadScene()
        {
            // HACK!!!
            Level.Player = Player;
            if (WorldString.Contains(".json"))
                Level.LoadLevel(WorldString);
            else if (WorldString == "GeneratedLevel")
                Level.ReloadGeneratedLevel();
            else
            {
                Level.LoadNextGeneratedLevel();
                WorldString = "GeneratedLevel";
            }

            // Input
            keyboard = new KeyboardController();
            gamepad = new GamepadController3();
            keyboard.RegisterCommand(Keys.Z, new GoUpCommand(this));
            keyboard.RegisterCommand(Keys.Up, new GoUpCommand(this));
            keyboard.RegisterCommand(Keys.S, new GoDownCommand(this));
            keyboard.RegisterCommand(Keys.Down, new GoDownCommand(this));
            keyboard.RegisterCommand(Keys.A, new MoveLeftCommand(this));
            keyboard.RegisterCommand(Keys.Left, new MoveLeftCommand(this));
            keyboard.RegisterCommand(Keys.D, new MoveRightCommand(this));
            keyboard.RegisterCommand(Keys.Right, new MoveRightCommand(this));
            keyboard.RegisterCommand(Keys.Q, new QuitCommand(this));
            keyboard.RegisterCommand(Keys.R, new ResetCommand());
            keyboard.RegisterCommand(Keys.X, new RunCommand(this));
            keyboard.RegisterCommand(Keys.X, new FireballCommand(this));
            
            keyboard.RegisterReleaseCommand(Keys.Z, new JumpButtonReleaseCommand(this));
            keyboard.RegisterReleaseCommand(Keys.Up, new JumpButtonReleaseCommand(this));
            keyboard.RegisterReleaseCommand(Keys.S, new StandCommand(this));
            keyboard.RegisterReleaseCommand(Keys.Down, new StandCommand(this));
            keyboard.RegisterReleaseCommand(Keys.A, new StandCommand(this));
            keyboard.RegisterReleaseCommand(Keys.Left, new StandCommand(this));
            keyboard.RegisterReleaseCommand(Keys.D, new StandCommand(this));
            keyboard.RegisterReleaseCommand(Keys.Right, new StandCommand(this));
            keyboard.RegisterReleaseCommand(Keys.X, new StopRunCommand(this));
            keyboard.RegisterReleaseCommand(Keys.P, new PauseLevelCommand(Level));
            keyboard.RegisterReleaseCommand(Keys.T, new CheatEntryCommand(this, "T"));
            keyboard.RegisterReleaseCommand(Keys.F, new CheatEntryCommand(this, "F"));
            keyboard.RegisterReleaseCommand(Keys.G, new CheatEntryCommand(this, "G"));
            keyboard.RegisterReleaseCommand(Keys.H, new CheatEntryCommand(this, "H"));

            //GamepadButtons

            gamepad.RegisterCommand(Buttons.DPadDown, new GoDownCommand(this));
            gamepad.RegisterCommand(Buttons.DPadLeft, new MoveLeftCommand(this));
            gamepad.RegisterCommand(Buttons.DPadRight, new MoveRightCommand(this));
            gamepad.RegisterCommand(Buttons.A, new GoUpCommand(this));
            gamepad.RegisterCommand(Buttons.B, new RunCommand(this));
            gamepad.RegisterCommand(Buttons.B, new FireballCommand(this));

            gamepad.RegisterReleaseCommand(Buttons.DPadDown, new StandCommand(this));
            gamepad.RegisterReleaseCommand(Buttons.DPadLeft, new StandCommand(this));
            gamepad.RegisterReleaseCommand(Buttons.DPadRight, new StandCommand(this));
            gamepad.RegisterReleaseCommand(Buttons.A, new JumpButtonReleaseCommand(this));
            gamepad.RegisterReleaseCommand(Buttons.B, new StopRunCommand(this));

            String HudName = "";
            String LifeSprite = "";

            if(Player.GetType().Name.Contains("Mario"))
            {
                HudName = "Mario";
                LifeSprite = "MarioLifeSprite";
            }
            if (Player.GetType().Name.Contains("Wario"))
            {
                HudName = "Wario";
                LifeSprite = "WarioLifeSprite";
            }
            Game.PlayersHud = GameHud.ResetHUD(Game.HudspriteBatch, Game.TextFont, HudName, TextureList.Instance.GetTexture("HudCoinSprite"), TextureList.Instance.GetTexture(LifeSprite));

        }

        public void UnloadScene()
        {
            Level.UnloadLevel();
        }

        public void Update()
        {
            keyboard.Update();
            gamepad.Update();
            Level.Update();
            RisingTextManager.Update();
        }

        public void Exit()
        {
            Game.Exit();
        }
        public static void Lose() { }
        public static void Win(){ }

        public void CheatEntry(string key)
        {
            Level.CheatEntry(key);
        }
    }
}
