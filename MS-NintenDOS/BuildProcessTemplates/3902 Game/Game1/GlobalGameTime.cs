using Microsoft.Xna.Framework;

namespace Globals
{
    static class GameGlobals
    {
        public static GameTime GameTime { get; set; }
        public static float dt => (float)GameTime.ElapsedGameTime.TotalSeconds;
        public static int ScreenWidth { get; set; }
        public static int ScreenHeight { get; set; }
    }
}
