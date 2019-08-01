using Microsoft.Xna.Framework;

namespace Game1.Entities
{
    public class GenericObjectPhysicsEngine2 : IPhysicsEngine
    {
        
        private Vector2 Velocity;

        private float TerminalVelocity = 6f;
        private float Gravity = 3f;
        private float GenericMaxRun = 7f;
        private float GenericMaxJump = 9f;

        Vector2 Friction;
        Vector2 GravityPull;
        private bool PauseState = false;

        public GenericObjectPhysicsEngine2()
        {
            
            Velocity = new Vector2(0f, 0f);

            Friction = new Vector2(0f, 0f);
            GravityPull = new Vector2(0f, Gravity);
        }

        public void ApplyForce(Vector2 inputVelocity)
        {
            if (!PauseState)
            { 
            Velocity = new Vector2((Velocity.X + inputVelocity.X), (Velocity.Y + inputVelocity.Y));
            }

        }

        public Vector2 Update()
        {

            float ChangeXValue = Velocity.X;
            float ChangeYValue = Velocity.Y;

            if (Velocity.X > GenericMaxRun)
            {
                ChangeXValue = GenericMaxRun;
            }
            if (Velocity.X < (-1f * GenericMaxRun))
            {
                ChangeXValue = (-1f * GenericMaxRun);
            }
            if (Velocity.Y < (-1f * GenericMaxJump))
            {
                ChangeYValue = (-1f * GenericMaxJump);
            }
            Velocity = new Vector2(ChangeXValue, ChangeYValue);


            if (Velocity.X < 0f)
            {
                Friction = new Vector2(0.5f, 0f);
            }

            if (Velocity.X > 0f)
            {
                Friction = new Vector2((-1f*0.5f), 0f);
            }
            if (Equals(Velocity.X, 0f))
            {
                Friction = new Vector2(0f, 0f);
            }


            Vector2 MoveDistance = Velocity + GravityPull + Friction;
            if (!PauseState)
            {
                Velocity = Velocity + Friction;
            }

            if (MoveDistance.Y > TerminalVelocity)
            {
                MoveDistance = new Vector2(MoveDistance.X, TerminalVelocity);
            }

            if (PauseState)
            {
                return new Vector2(0f, 0f);
            }
            else
            {
                return MoveDistance;
            }

        }

        public void ForceCancel(bool Up)
        {
            if (Up)
            {
                Velocity = new Vector2(Velocity.X, 0f);

            }
            else if (!Up)
            {
                Velocity = new Vector2(0f, Velocity.Y);
            }

        }

        public void ReverseDirection(bool Up)
        {
            if (Up)
            {
                Velocity = new Vector2(Velocity.X, -Velocity.Y);
            }
            if (!Up)
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }

        }

        private static bool Equals(float inputValue, float equalValue)
        {
            bool Equality = false;
            if ((inputValue <= (equalValue + 0.1f)) && (inputValue >= (equalValue - 0.1f)))
            {
                Equality = true;
            }
            return Equality;
        }
        public void SetPauseState(bool Pause)
        {
            PauseState = Pause;
        }
    }
}

