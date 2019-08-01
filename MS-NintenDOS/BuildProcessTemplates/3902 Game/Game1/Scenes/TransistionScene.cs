using Game1.Entities.Mario;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Game1.Scenes
{
    class TransistionScene : IScene
    {
        public Game1 Game { get; set; }
        public ContentManager Content { get; set; }
        public GraphicsDeviceManager Graphics { get; set; }
        private readonly string NextLevel;
        public int MarioLives { get; set; }
        public string WorldString { get; set; }
        public IMario Player { get; set; }

        private int Timer;
        public TransistionScene(int lives, string nextLevel)
        {
            this.Game = SceneManager.Instance.Game;
            this.MarioLives = lives;
            this.Timer = 100;
            this.NextLevel = nextLevel;
        }
        public void Draw()
        {
            Game.GraphicsDevice.Clear(Color.Black);
        }

        public void LoadScene()
        {
            Game.PlayersHud.SetMidScreen(true);
        }

        public void UnloadScene()
        {
            Game.PlayersHud.SetMidScreen(false);
        }

        public void Update()
        {
            Timer--;
            if (Timer <= 0)
            {
                ToNext();
            }
        }
        private void ToNext()
        {
            SceneManager.Instance.LoadScene(new WorldScene(NextLevel,MarioLives, SceneManager.Instance.PreviousScene.Player));
        }

        public void Exit()
        {
            Game.Exit();
        }
    }
}
