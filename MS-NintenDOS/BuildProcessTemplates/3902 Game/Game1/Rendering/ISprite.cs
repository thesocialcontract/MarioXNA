using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Game1.Rendering
{
    public interface ISprite
    {
        int Width { get; }
        int Height { get; }
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void Draw(SpriteBatch spriteBatch, Vector2 location, float degrees);
        void InvulnerableDraw(SpriteBatch spriteBatch, Vector2 location);
    }
}
