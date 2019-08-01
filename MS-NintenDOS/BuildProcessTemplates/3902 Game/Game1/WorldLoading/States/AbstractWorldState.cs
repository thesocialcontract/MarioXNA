namespace Game1.WorldLoading.States
{
    public class AbstractWorldState : IWorldState
    {
        protected IWorld World { get; set; }
        public float SecondsLeft { get; protected set; }

        public AbstractWorldState(IWorld world, float secondsLeft)
        {
            World = world;
            SecondsLeft = secondsLeft;
        }

        public virtual void Update() { }
        public virtual void Draw()
        {
            foreach (var entity in World.GameEntities)
                entity.Draw();
            World.Player.Draw();
        }
        public virtual void Pause() { }
        public virtual void WorldResume() { }
        public virtual void Reset(float secondsLeft)
        {
            SecondsLeft = secondsLeft;
        }
        public virtual void CheatEntry(string key) { }
    }
}
