using Game1.Entities.Items;
using Microsoft.Xna.Framework;
using Game1.WorldLoading;

namespace Game1.Entities.Blocks
{
    public class BlockContent
    {
        public string ContentType { get; private set; }
        public int NumItems { get; private set; } = 1;
        public float BumpTimer { get; private set; } = 0;
        public bool IsEmpty { get; private set; }

        private IContainableBlock parentBlock;
        private bool isTicking = false;
        private float timeSinceBump = 0.0f;

        public BlockContent(IContainableBlock parent, string contentType)
        {
            parentBlock = parent;
            ContentType = contentType;
        }
        public BlockContent(IContainableBlock parent, string contentType, int numItems)
        {
            parentBlock = parent;
            ContentType = contentType;
            NumItems = numItems;
        }
        public BlockContent(IContainableBlock parent, string contentType, float bumpTimer)
        {
            parentBlock = parent;
            ContentType = contentType;
            BumpTimer = bumpTimer;
        }
        public BlockContent(IContainableBlock parent, string contentType, int numItems, float bumpTimer)
        {
            parentBlock = parent;
            ContentType = contentType;
            BumpTimer = bumpTimer;
            NumItems = numItems;
        }

        public void Eject(bool isMarioBig)
        {
            if (NumItems <= 0) return;
            if (BumpTimer > 0.0f && timeSinceBump >= BumpTimer) return;

            NumItems--;
            isTicking = true;
            var spawnLocation = parentBlock.WorldLocation;
            switch (ContentType)
            {
                case "PowerUp":
                    BlockAudioManager.PlaySfxPowerUpAppears();
                    if (isMarioBig)
                    {
                        var fireFlower = ItemFactory.CreateFireFlower(spawnLocation);
                        ShiftSpawnPosition(fireFlower);
                        World.Instance.AddEntity(fireFlower);
                    }
                    else
                    {
                        var powerUpShroom = ItemFactory.CreatePowerUpMushroom(spawnLocation);
                        ShiftSpawnPosition(powerUpShroom);
                        World.Instance.AddEntity(powerUpShroom);
                    }
                    break;
                case "OneUpShroom":
                    BlockAudioManager.PlaySfxPowerUpAppears();
                    var oneUpShroom = ItemFactory.CreateOneUpMushroom(spawnLocation);
                    ShiftSpawnPosition(oneUpShroom);
                    World.Instance.AddEntity(oneUpShroom);
                    break;
                case "Starman":
                    BlockAudioManager.PlaySfxPowerUpAppears();
                    var starman = ItemFactory.CreateStarman(spawnLocation);
                    ShiftSpawnPosition(starman);
                    var starSpawnPadding = 6;
                    var paddedLocation = starman.WorldLocation;
                    paddedLocation.Y -= starSpawnPadding;
                    starman.WorldLocation = paddedLocation;
                    World.Instance.AddEntity(starman);
                    break;
                case "Coin":
                    World.Instance.AddToScore(200);
                    BlockAudioManager.PlaySfxCoin();
                    World.Instance.AddToCoins(1);
                    var blockCoin = ItemFactory.CreateBlockCoin(spawnLocation);
                    World.Instance.AddEntity(blockCoin);
                    break;
            }
            if (NumItems <= 0 || timeSinceBump >= BumpTimer)
            {
                IsEmpty = true;
                isTicking = false;
            }
        }

        private static void ShiftSpawnPosition(IGameEntity entity)
        {
            Vector2 newLocation = entity.WorldLocation;
            newLocation.Y -= entity.Collider.Bounds.Size.Y;
            entity.WorldLocation = newLocation;
        }

        public void Update()
        {
            // TODO Deltatime
            float dt = 1.0f;
            if (isTicking)
                timeSinceBump += dt;
        }
    }
}
