using Game1.Entities.Mario.States;
using Microsoft.Xna.Framework;

namespace Game1.Entities.Mario
{
    public abstract class Player : IGameEntity
    {
        public ColliderCategories ColliderCategory => ColliderCategories.mario;
        public Vector2 WorldLocation { get; set; }
        public Collider Collider
        {
            get => MarioState.Collider;
            set => MarioState.Collider = value;
        }
        public IMarioState MarioState { get; set; }
        public IPhysicsEngine PhysicsEngine { get; set; }
        

        public virtual void Draw()
        {
            MarioState.Draw(WorldLocation);
            
        }
        public virtual void InvulnerableDraw()
        {
            MarioState.InvulnerableDraw(WorldLocation);
        }
        public virtual void Update()
        {
            
        }
    }
}
