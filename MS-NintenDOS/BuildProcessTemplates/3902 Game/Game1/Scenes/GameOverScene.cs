using Game1.Entities.Mario;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Game1.Scenes
{
    class GameOverScene : IScene
    {
        public Game1 Game { get; set; }
        public ContentManager Content { get; set; }
        public GraphicsDeviceManager Graphics { get; set; }
        private readonly string NextLevel;
        public int MarioLives { get; set; }
        public string WorldString { get; set; }
        public IMario Player { get; set; }

        
        public GameOverScene(int lives, string nextLevel)
        {
            this.Game = SceneManager.Instance.Game;
            this.MarioLives = lives;
           
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

        }
        private void ToNext()
        {

        }

        public void Exit()
        {
            Game.Exit();
        }
    }
}
