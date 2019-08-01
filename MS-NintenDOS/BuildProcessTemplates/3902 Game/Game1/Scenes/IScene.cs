using Game1.Entities.Mario;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace Game1.Scenes
{
    public interface IScene
    {
        Game1 Game { get; set; }
        ContentManager Content { get; set; }
        GraphicsDeviceManager Graphics { get; set; }
        int MarioLives { get; set; }
        String WorldString { get; set; }
        IMario Player { get; set; }
        void LoadScene();
        void UnloadScene();
        void Draw();
        void Update();
        void Exit();
    }
}
