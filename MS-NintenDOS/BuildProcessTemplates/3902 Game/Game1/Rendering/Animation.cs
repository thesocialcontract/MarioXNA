using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Game1.Rendering
{
    class Animation
    {
        // Keyframes are defined to be in position x,y at time z
        private List<Vector3> keyframes;
        private float animationLength;
        private int currentKeyframe;
        private int finalKeyframe;
        private float time;
        public bool IsDone { get; private set; }
        public Vector2 Position { get; private set; }
        private bool DoesRepeat { get; set; }

        public Animation(List<Vector3> keyframes, bool isRepeating = false)
        {
            this.keyframes = keyframes.OrderBy(x => x.Z).ToList();
            finalKeyframe = keyframes.Count - 1;
            currentKeyframe = 0;
            animationLength = keyframes[finalKeyframe].Z;
            time = 0.0f;
            DoesRepeat = isRepeating;
        }

        private void SetPosition()
        {
            var originKeyFrame = keyframes[currentKeyframe];
            var targetKeyFrame = keyframes[currentKeyframe + 1];
            var origin = new Vector2(originKeyFrame.X, originKeyFrame.Y);
            var target = new Vector2(targetKeyFrame.X, targetKeyFrame.Y);
            var vectorToTravel = target - origin;

            var startTime = originKeyFrame.Z;
            var endTime = targetKeyFrame.Z;
            var keyframeLength = endTime - startTime;
            var t = (time - startTime) / keyframeLength;

            Position = (vectorToTravel * t) + origin;
        }

        public void Update()
        {
            if (IsDone) return;
            
            time += Globals.GameGlobals.dt;
            if (time >= keyframes[(currentKeyframe + 1) % keyframes.Count()].Z)
                currentKeyframe = (currentKeyframe + 1) % keyframes.Count();

            if (time >= animationLength && !DoesRepeat)
                IsDone = true;
            else
                SetPosition();
        }

        public void Draw(ISprite sprite, Vector2 location)
        {
            location += Position;
            sprite.Draw(TextureList.Instance.GameSpriteBatch, location);
        }
    }
}
