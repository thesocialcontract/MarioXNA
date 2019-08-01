using Game1.Entities;
using Game1.Entities.Mario;
using Game1.Entities.Terrain;
using Game1.Entities.TriggerZone;
using Game1.Scenes;
using System.Threading;
using System;
using System.Collections.Generic;
using Game1.Entities.Mario.States;
using Globals;

namespace Game1.WorldLoading.States
{
    public class PlayingWorldState : AbstractWorldState
    {
        public bool IsWinning { get; set; }
        private float deathTimer = 0.0f;
        private bool isTicking;
        private readonly float timeToReset = 3.0f;
        
        public PlayingWorldState(IWorld world, float secondsLeft) : base(world, secondsLeft)
        {
            WorldAudioManager.WorldAudioResume();
            IsWinning = false;
        }

        public override void Update()
        {
            AddAndRemoveEntities();
            ICollection<IGameEntity> onCameraEntities = new List<IGameEntity>();
            foreach (var entity in World.GameEntities)
            {
                float xDistanceToPlayer = Math.Abs(entity.WorldLocation.X - World.Player.WorldLocation.X);
                float yDistanceToPlayer = Math.Abs(entity.WorldLocation.Y - World.Player.WorldLocation.Y);
                if(xDistanceToPlayer < World.ScreenWidth && yDistanceToPlayer < World.ScreenHeight)
                {
                    onCameraEntities.Add(entity);
                }else if(entity is Floor || entity is Wall || entity is DeathZone || entity is WinZone)
                {
                    onCameraEntities.Add(entity);
                }
            }
            foreach(IGameEntity entity in onCameraEntities)
            {
                entity.Update();
            }

            World.Camera.Update(World.Player);
            World.Player.Update();
            World.CollisionDetector.SetColliderList(onCameraEntities);
            World.CollisionDetector.Update();
            
            HandleWinLoseStates();

            bool isInUndergroundArea = World.Player.WorldLocation.X <= WorldHelpers.UndergroundArea;
            WorldAudioManager.Instance.SetWorldArea(isInUndergroundArea);
            UpdateTimer();
        }
        public override void Pause()
        {
            World.State = new PausedWorldState(World, SecondsLeft);
        }

        public void UpdatePlayer()
        {
            IGameEntity marioInGameEntities = null;
            foreach (IGameEntity gameEntity in World.GameEntities)
            {
                if(gameEntity is IMario)
                {
                    marioInGameEntities = gameEntity;
                }
            }

            if (marioInGameEntities != null)
            {
                World.GameEntities.Remove(marioInGameEntities);
                World.GameEntities.Add((IGameEntity)World.Player);
            }
        }

        private void UpdateTimer()
        {
            SecondsLeft -= GameGlobals.dt;
            if (SecondsLeft < WorldHelpers.HurrySeconds && !WorldAudioManager.IsHurried)
                WorldAudioManager.Instance.SetHurry();
            else if (SecondsLeft <= 0)
                World.Player.Die();
        }

        private void AddAndRemoveEntities()
        {
            foreach (var entity in World.EntitiesToDelete)
                World.GameEntities.Remove(entity);
            World.EntitiesToDelete.Clear();

            foreach (var entity in World.EntitiesToAdd)
                World.GameEntities.Add(entity);
            World.EntitiesToAdd.Clear();
        }

        private void HandleWinLoseStates()
        {
            bool isDying = ((World.Player.MarioState is DeadMarioState) || (World.Player.MarioState is DeadWarioState));
            bool isWinning = ((World.Player.MarioState is InvisibleWinMario) || (World.Player.MarioState is InvisibleWinWario));
            
            bool isGameOver = World.Player.Lives <= 0;
            isTicking = (isDying || isWinning);
            if (isTicking)
                deathTimer += GameGlobals.dt;
            if (deathTimer >= timeToReset)
            {
                if (isGameOver)
                {
                    SceneManager.Instance.LoadScene(new TransistionScene
                        (SceneManager.Instance.CurrentScene.MarioLives - 1,
                        SceneManager.Instance.CurrentScene.WorldString));
                    WorldAudioManager.PlayGameOver();

                    Thread.Sleep(4000); // HACK!
                    ((World)World).Start(WorldHelpers.FirstLevelFilepath);
                }
                else if (isDying)
                    SceneManager.Instance.LoadScene(new TransistionScene
                        (SceneManager.Instance.CurrentScene.MarioLives - 1,
                        SceneManager.Instance.CurrentScene.WorldString));
                deathTimer = 0.0f;
                isTicking = false;
            }
        }
    }
}
