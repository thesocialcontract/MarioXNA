using Microsoft.Xna.Framework;
using Game1.Rendering;
using System.Collections.Generic;

namespace Game1.Entities.Mario.States
{
    public class DeadMarioState : MarioState
    {
        private Animation animation;

        public DeadMarioState(Mario mario) : base(mario)
        {
            base.SetSprite(MarioSpriteFactory.Instance.CreateDeadMarioSprite());
            Collider = null;
            var keyframes = new List<Vector3>
            {
                new Vector3(0, 0.0f, 0.0f),
                new Vector3(0, 0.0f, 0.5f),
                new Vector3(0, -64.0f, 1.5f),
                new Vector3(0, 256.0f, 3.7f)
            };
            animation = new Animation(keyframes);
            MarioAudioManager.PlayMarioDie();
            mario.Lives--;
        }

        public override void Die() { }
        public override void MoveDown() { }
        public override void Jump() { }
        public override void MoveLeft() { }
        public override void MoveRight() { }
        

        public override void Update()
        {
            Sprite.Update();
            animation.Update();
        }

        public override void Draw(Vector2 location)
        {
            animation.Draw(Sprite, location);
        }
    }
}