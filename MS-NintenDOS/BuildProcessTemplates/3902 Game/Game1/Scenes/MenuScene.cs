using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Entities.Mario;
using Game1.Input.Commands;
using Game1.Input.Controllers;
using Game1.Rendering.UI;
using Game1.Scenes.MenuSceneStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1.Scenes
{
    public class MenuScene : IScene
    {
        public Game1 Game { get; set; }
        public ContentManager Content { get; set; }
        public GraphicsDeviceManager Graphics { get; set; }
        public int MarioLives { get; set; }
        public IMenuSceneState MenuSceneState{ get; set; }
        public SpriteFont MenuText { get; set; }
        private KeyboardController Keyboard { get; set;}
        public string WorldString { get; set; }
        public IMario Player { get; set; }

        public MenuScene (Game1 game)
        {
            Game = game;
            Content = game.Content;
            Graphics = game.Graphics;
            MenuText = Content.Load<SpriteFont>("File");
            MenuSceneState = new MainMenuSceneState(this);
            

        }
        public void Draw()
        {
            Game.GraphicsDevice.Clear(Color.CornflowerBlue);
            Game.spriteBatch.Begin();
            MenuSceneState.Draw();
            Game.spriteBatch.End();
        }

        public void LoadScene()
        {
            Keyboard = new KeyboardController();
            Keyboard.RegisterReleaseCommand(Keys.Up, new MenuMoveUpCommand(this));
            Keyboard.RegisterReleaseCommand(Keys.Down, new MenuMoveDownCommand(this));
            Keyboard.RegisterReleaseCommand(Keys.Z, new MenuSelectCommand(this));
            Keyboard.RegisterReleaseCommand(Keys.X, new MenuGoBackCommand(this));
        }

        public void UnloadScene() { }

        public void Update()
        {
            Keyboard.Update();
            MenuSceneState.Update();
        }
        public void MoveLeft()
        {
            MenuSceneState.MoveLeft();
        }
        public void MoveRight()
        {
            MenuSceneState.MoveRight();
        }

        public void MoveUp()
        {
            MenuSceneState.MoveUp();
        }
        public void MoveDown()
        {
            MenuSceneState.MoveDown();
        }

        public void Select()
        {
            MenuSceneState.Select();
        }
        public void GoBack()
        {
            MenuSceneState.GoBack();
        }

        public void Exit()
        {
            Game.Exit();
        }
    }
}
