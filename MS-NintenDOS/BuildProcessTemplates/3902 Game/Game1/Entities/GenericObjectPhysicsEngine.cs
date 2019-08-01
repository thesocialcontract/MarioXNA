using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class GenericObjectPhysicsEngine : IPhysicsEngine
    {
        private IGameEntity Host;
        private Vector2 Velocity;

        private float TerminalVelocity = 6;
        private float Gravity = 2;
        
        private float FrictionAmount = 2;

        Vector2 Friction;
        Vector2 GravityPull;


        public GenericObjectPhysicsEngine(IGameEntity InputHost)
        {
            Host = InputHost;
                        
            Velocity = new Vector2(0, 0);
            
            Friction = new Vector2(0, 0);
            GravityPull = new Vector2(0, Gravity);
        }

        public void ApplyForce(Vector2 inputVelocity)
        {

            Velocity += inputVelocity;


        }

        public Vector2 Update()
        {

            if (!(Equals(Velocity.X, 0)))
            {
                if (Velocity.X > 0)
                {
                    Friction = new Vector2(-FrictionAmount, 0);
                }
                if (Velocity.X < 0)
                {
                    Friction = new Vector2(FrictionAmount, 0);
                }
            }
            else
            {
                Friction = new Vector2(0, 0);
            }


            Vector2 MoveDistance = Velocity + GravityPull + Friction;
            Velocity += Friction;

            if (MoveDistance.Y > TerminalVelocity)
            {
                MoveDistance = new Vector2(MoveDistance.X, TerminalVelocity);
            }

            return MoveDistance;


        }

        public void ForceCancel(bool Up)
        {
            if (Up)
            {
                Velocity = new Vector2(Velocity.X, 0);

            }
            else if (!Up)
            {
                Velocity = new Vector2(0, Velocity.Y);
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

        private bool Equals(float inputValue, float equalValue)
        {
            bool Equality = false;
            if ((inputValue <= (equalValue + .1)) && (inputValue >= (equalValue - .1)))
            {
                Equality = true;
            }
            return Equality;
        }

    }
}

