using Game1.Rendering;
using System.Collections.Generic;
using System.Linq;

using Game1.Entities;
using Game1.Entities.Mario;
using Game1.WorldLoading.States;
using Game1.Scenes;
using System;

namespace Game1.WorldLoading
{
    public class World : IWorld, IUpdatable, IDrawable
    {
        public static World Instance { get; } = new World();
        public IWorldState State { get; set; }
        public ICollection<IGameEntity> GameEntities { get; }
        public IMario Player { get; set; }
        public int ScreenHeight { get; set; }
        public int ScreenWidth { get; set; }
        public CameraController Camera { get; set; }
        public CollisionDetector CollisionDetector { get; set; }
        public ICollection<IGameEntity> EntitiesToDelete { get; }
        public ICollection<IGameEntity> EntitiesToAdd { get; }
        private IWorldLoader loader;
        private IWorldGenerator worldGenerator;

        public IGameEntity EntityToFixCamera { get; set; }

        private World()
        {
            GameEntities = new List<IGameEntity>();
            EntitiesToDelete = new List<IGameEntity>();
            EntitiesToAdd = new List<IGameEntity>();
            Camera = new CameraController();
            loader = new WorldLoaderJson();
            worldGenerator = new WorldGenerator();
        }

        private void SetGameEntities(ICollection<IGameEntity> gameEntities)
        {
            GameEntities.Clear();
            foreach (IGameEntity gameEntity in gameEntities) {
                GameEntities.Add(gameEntity);
            }
        }

        public void Start(string levelfilePath)
        {
            if (Player != null) Player = null;
            LoadLevel(levelfilePath);
        }

        public void ReloadGeneratedLevel()
        {
            var score = Player?.Score ?? 0;
            var coins = Player?.Coins ?? 0;
            var lives = Player?.Lives ?? WorldHelpers.StartingLives;
            
            SetGameEntities(worldGenerator.ReloadLevel(Player));
            Player = (IMario)GameEntities.FirstOrDefault(x => x is IMario);
            
            Player.Score = score;
            Player.Coins = coins;
            Player.Lives = lives;

            StartLevel();
        }

        public void LoadNextGeneratedLevel()
        {
            var score = Player?.Score ?? 0;
            var coins = Player?.Coins ?? 0;
            var lives = Player?.Lives ?? WorldHelpers.StartingLives;

            SetGameEntities(worldGenerator.LoadNewLevel(Player));
            Player = (IMario)GameEntities.FirstOrDefault(x => x is IMario);
            Player.Score = score;
            Player.Coins = coins;
            Player.Lives = lives;

            StartLevel();
        }

        public void LoadLevel(string levelFilePath)
        {
            var score = Player?.Score ?? 0;
            var coins = Player?.Coins ?? 0;
            var lives = Player?.Lives ?? WorldHelpers.StartingLives;

            SetGameEntities(loader.Load(levelFilePath, Player));
            Player = (IMario)GameEntities.FirstOrDefault(x => x is IMario);
            
            Player.Score = score;
            Player.Coins = coins;
            Player.Lives = lives;

            StartLevel();
        }

        private void StartLevel()
        {
            EntityToFixCamera = Player;
            CollisionDetector = new CollisionDetector(GameEntities);
            WorldAudioManager.StartOverworldLevel();
            State = new PlayingWorldState(this, WorldHelpers.LevelSeconds);
        }

        public void UnloadLevel()
        {
            GameEntities?.Clear();
            EntitiesToDelete.Clear();
        }

        public void Update()
        {
            State.Update();
            WorldAudioManager.Instance.Update();
        }

        public void Draw()
        {
            State.Draw();
        }

        public void RemoveEntity(IGameEntity entity)
        {
            if (GameEntities.Contains(entity))
                EntitiesToDelete.Add(entity);
        }

        public void AddEntity(IGameEntity entity)
        {
            EntitiesToAdd.Add(entity);
        }

        public void NextLevel()
        {
            SceneManager.Instance.LoadScene(new TransistionScene
                (SceneManager.Instance.CurrentScene.MarioLives,
                "NextGeneratedLevel"));
        }
        public void PlayBackgroundMusic()
        {
            WorldAudioManager.PlayBackgroundMusic();
        }

        public void Pause()
        {
            State.Pause();
        }
        public void AddToScore(int score)
        {
            Player.Score += score;
        }
        public void AddToCoins(int coins)
        {
            Player.Coins += coins;
        }

        public void CheatEntry(string key)
        {
            State.CheatEntry(key);
        }
    }
}
