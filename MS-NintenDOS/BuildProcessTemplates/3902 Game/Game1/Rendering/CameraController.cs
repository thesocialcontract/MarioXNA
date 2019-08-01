using Microsoft.Xna.Framework;
using Game1.Entities;
using Game1.WorldLoading;

namespace Game1.Rendering
{
    public class CameraController
    {
        public Matrix TranformationMatrix { get; set; }
        public CameraController()
        {
            TranformationMatrix = new Matrix();
        }

        private bool yIsSet = false;
        private int yCoord;

        public void Update(IGameEntity gameEntity)
        {
            if (!yIsSet)
            {
                yCoord = -(int)gameEntity.WorldLocation.Y + 64; //TODO consider adding a center definition back in
                yIsSet = true;
            }
            TranformationMatrix = Matrix.CreateTranslation(
                -gameEntity.WorldLocation.X, yCoord, 0);

            TranformationMatrix *= Matrix.CreateTranslation(
                World.Instance.ScreenWidth / 2,
                World.Instance.ScreenHeight / 2,
                0);
        }
    }
}
