using Game1.Rendering;
using Game1.WorldLoading.States;
using System.Collections.Generic;

using Game1.Entities;
using Game1.Entities.Mario;

namespace Game1.WorldLoading
{
    public interface IWorld : IUpdatable, IDrawable
    {
        ICollection<IGameEntity> GameEntities { get; }
        ICollection<IGameEntity> EntitiesToDelete { get; }
        ICollection<IGameEntity> EntitiesToAdd { get; }
        IMario Player { get; set; }
        IWorldState State { get; set; }
        int ScreenHeight { get; set; }
        int ScreenWidth { get; set; }
        CameraController Camera { get; set; }
        CollisionDetector CollisionDetector { get; set; }

        IGameEntity EntityToFixCamera { get; set; }

        void LoadLevel(string levelFilePath);
        void UnloadLevel();
        void Pause();
    }
}
