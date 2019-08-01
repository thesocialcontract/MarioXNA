using Microsoft.Xna.Framework;

namespace Game1.Entities
{
    public class ObjectPhysicsEngine
    {
        public Vector2 Velocity => velocity;

        private IGameEntity host;
        private Vector2 velocity;
        private Vector2 netForce;
        private readonly float xDampingFactor = 0.95f; //TODO tune
        private readonly float yDampingFactor = 0.4f; //TODO tune
        private readonly float gravity = 3f; //TODO tune

        public ObjectPhysicsEngine(IGameEntity host)
        {
            this.host = host;
        }

        public ObjectPhysicsEngine(IGameEntity host, float xDampingFactor)
        {
            this.host = host;
            this.xDampingFactor = xDampingFactor;
        }

        public ObjectPhysicsEngine(IGameEntity host, float xDampingFactor, float yDampingFactor)
        {
            this.host = host;
            this.xDampingFactor = xDampingFactor;
            this.yDampingFactor = yDampingFactor;
        }

        public void ApplyForce(Vector2 force)
        {
            netForce += force;
        }

        public void Hit(Side side)
        {
            Vector2 currentPosition = host.WorldLocation;
            switch (side)
            {
                case Side.left:
                    velocity.X = 0;
                    currentPosition.X += 1;
                    break;
                case Side.right:
                    velocity.X = 0;
                    currentPosition.X -= 1;
                    break;
                case Side.top:
                    velocity.Y = 0;
                    currentPosition.Y += 1;
                    break;
                case Side.bottom:
                    velocity.Y = 0;
                    currentPosition.Y -= 5;
                    break;
                default:
                    velocity = new Vector2(0, 0);
                    break;
            }
            host.WorldLocation = currentPosition;
        }

        public void Hit(Side side, float depth)
        {
            Vector2 currentPosition = host.WorldLocation;
            switch (side)
            {
                case Side.left:
                    velocity.X = 0;
                    currentPosition.X += depth;
                    break;
                case Side.right:
                    velocity.X = 0;
                    currentPosition.X -= depth;
                    break;
                case Side.top:
                    velocity.Y = 0;
                    currentPosition.Y += depth;
                    break;
                case Side.bottom:
                    velocity.Y = 0;
                    currentPosition.Y -= depth;
                    break;
                default:
                    velocity = new Vector2(0, 0);
                    break;
            }
            host.WorldLocation = currentPosition;
        }

        public void Bounce(Side side)
        {
            Vector2 currentPosition = host.WorldLocation;
            switch (side)
            {
                case Side.left:
                    if (velocity.X < 0)
                    {
                        velocity.X *= -1;
                    }
                    currentPosition.X += 1;
                    break;
                case Side.right:
                    if (velocity.X > 0)
                    {
                        velocity.X *= -1;
                    }
                    currentPosition.X -= 1;
                    break;
                case Side.top:
                    if (velocity.Y < 0)
                    {
                        velocity.Y *= -1;
                    }
                    currentPosition.Y += 1;
                    break;
                case Side.bottom:
                    if (velocity.Y > 0)
                    {
                        velocity.Y *= -1;
                    }
                    currentPosition.Y -= 1;
                    break;
                default:
                    velocity *= -1;
                    break;
            }
            host.WorldLocation = currentPosition;
        }

        public void Bounce(Side side, float depth)
        {
            float yVelocity = 20; //TODO tune
            Vector2 currentPosition = host.WorldLocation;
            switch (side)
            {
                case Side.left:
                    if (velocity.X < 0)
                    {
                        velocity.X *= -1;
                    }
                    currentPosition.X += depth;
                    break;
                case Side.right:
                    if (velocity.X > 0)
                    {
                        velocity.X *= -1;
                    }
                    currentPosition.X -= depth;
                    break;
                case Side.top:
                    if (velocity.Y < 0)
                    {
                        velocity.Y = yVelocity;
                    }
                    currentPosition.Y += depth;
                    break;
                case Side.bottom:
                    if (velocity.Y > 0)
                    {
                        velocity.Y = -yVelocity;
                    }
                    currentPosition.Y -= depth;
                    break;
                default:
                    velocity *= -1;
                    break;
            }
            host.WorldLocation = currentPosition;
        }

        public void SetVelocity(Vector2 newVelocity)
        {
            velocity = newVelocity;
        }

        public void Update()
        {
            velocity += netForce;
            Vector2 currentPosition = host.WorldLocation;
            currentPosition += velocity;
            host.WorldLocation = currentPosition;
            Vector2 dampingForce = new Vector2(-xDampingFactor * velocity.X, -yDampingFactor * velocity.Y);
            Vector2 gravityForce = new Vector2(0, gravity);
            netForce = dampingForce + gravityForce;
        }
    }
}
