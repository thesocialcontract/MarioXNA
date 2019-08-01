using Microsoft.Xna.Framework;

namespace Game1.Entities.Items
{
    public static class ItemFactory
    {
        public static FireFlower CreateFireFlower(Vector2 location)
        {
            return new FireFlower(location);
        }
        public static PowerUpMushroom CreatePowerUpMushroom(Vector2 location)
        {
            return new PowerUpMushroom(location);
        }
        public static OneUpMushroom CreateOneUpMushroom(Vector2 location)
        {
            return new OneUpMushroom(location);
        }
        public static Starman CreateStarman(Vector2 location)
        {
            return new Starman(location);
        }
        public static Fireball CreateFireball(Vector2 location)
        {
            return new Fireball(location);
        }
        public static Coin CreateCoin(Vector2 location)
        {
            return new Coin(location);
        }
        public static BlockCoin CreateBlockCoin(Vector2 location)
        {
            return new BlockCoin(location);
        }
    }
}
