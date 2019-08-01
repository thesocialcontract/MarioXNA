using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Game1.Entities.Blocks;
using Game1.Entities.Enemies.CollisionHandlers;
using Game1.Entities.Items.CollisionHandlers;
using Game1.Entities.Mario.CollisionHandlers;

namespace Game1.Entities
{
    public class CollisionDetector : IUpdatable
    {
        private List<ICollider> stationaryColliders;
        private List<ICollider> dynamicColliders;
        private Dictionary<HashSet<ColliderCategories>, ICollisionHandler> handlerList;
        private Dictionary<ICollisionHandler, HashSet<Collision>> marioCollisionList;

        protected class Collision
        {
            public Side? CollisionSide { get; set; }
            public Rectangle Bounds { get; set; }
            public ICollider Collider2 { get; set; }
            public ICollider Collider1 { get; set; }

            public Collision(ICollider collider1, ICollider collider2)
            {
                Collider1 = collider1;
                Collider2 = collider2;
                Bounds = Rectangle.Intersect(collider1.Bounds, collider2.Bounds);
                if (!Bounds.IsEmpty)
                {
                    CollisionSide = DetermineCollisionSide(collider1.Bounds, Bounds);
                }
                else
                {
                    CollisionSide = null;
                }
            }
        }

        public CollisionDetector(ICollection<IGameEntity> entityList)
        {
            SetColliderList(entityList);
            InitializeHandlerList();
        }

        public void SetColliderList(ICollection<IGameEntity> entityList)
        {
            stationaryColliders = new List<ICollider>();
            dynamicColliders = new List<ICollider>();
            for (int i = 0; i < entityList.Count; i++)
            {
                ICollider collider = entityList.ElementAt(i).Collider;
                if (collider == null)
                {
                    continue;
                }
                else if (collider.IsDynamic)
                {
                    dynamicColliders.Add(collider);
                }
                else
                {
                    stationaryColliders.Add(collider);
                }
            }
        }
        public void Update()
        {
            List<ICollider> dynamicColliderPool = new List<ICollider>(dynamicColliders);
            for(int j = 0; j < dynamicColliderPool.Count; j++)
            {
                marioCollisionList = new Dictionary<ICollisionHandler, HashSet<Collision>>();
                for (int i = 0; i < stationaryColliders.Count; i++)
                {
                    ICollider collider2 = stationaryColliders[i];
                    ICollider collider1 = dynamicColliderPool[j];
                    Collision collision = new Collision(collider1, collider2);
                    if (collision.CollisionSide != null)
                    {
                        ICollisionHandler handler = GetCollisionHandler(collision.Collider1, collision.Collider2);
                        if (marioCollisionList.ContainsKey(handler))
                        {
                            marioCollisionList[handler].Add(collision);
                        }
                        else
                        {
                            marioCollisionList.Add(handler, new HashSet<Collision>() { collision });
                        }
                    }
                }
                foreach (ICollisionHandler handler in marioCollisionList.Keys)
                {
                    HandleLargestCollision(handler, marioCollisionList[handler]);
                }
            }

            while(dynamicColliderPool.Count != 0)
            {
                ICollider collider1 = dynamicColliderPool[0];
                dynamicColliderPool.RemoveAt(0);
                for (int i = 0; i < dynamicColliderPool.Count; i++)
                {
                    ICollider collider2 = dynamicColliderPool[i];
                    Collision collision = new Collision(collider1, collider2);
                    if (collision.CollisionSide != null)
                    {
                        ICollisionHandler handler = GetCollisionHandler(collision.Collider1, collision.Collider2);
                        float depth = DetermineDepth(collision.Bounds, (Side)collision.CollisionSide);
                        handler.HandleCollision(collision.Collider1.Host, collision.Collider2.Host, (Side)collision.CollisionSide, depth);
                    }
                }
            }
        }

        private static void HandleLargestCollision(ICollisionHandler handler, HashSet<Collision> collisions)
        {
            if(handler is MarioBlockCollisionHandler && (collisions.ElementAt(0).Collider1.Host is RampBlock || collisions.ElementAt(0).Collider2.Host is RampBlock)){
                HashSet<Side> handledSides = new HashSet<Side>();
                foreach(Collision collision in collisions)
                {
                    if (!handledSides.Contains((Side)collision.CollisionSide)){
                        float rampDepth = DetermineDepth(collision.Bounds, (Side)collision.CollisionSide);
                        handler.HandleCollision(collision.Collider1.Host, collision.Collider2.Host, (Side)collision.CollisionSide, rampDepth);
                        handledSides.Add((Side)collision.CollisionSide);
                    }
                }
                return;
            }
            Collision maxCollision = collisions.ElementAt(0);
            int maxArea = maxCollision.Bounds.Width * maxCollision.Bounds.Height;
            foreach(Collision collision in collisions)
            {
                int area = collision.Bounds.Width * collision.Bounds.Height;
                if(area > maxArea)
                {
                    maxCollision = collision;
                    maxArea = area;
                }
            }

            float depth = DetermineDepth(maxCollision.Bounds, (Side)maxCollision.CollisionSide);
            handler.HandleCollision(maxCollision.Collider1.Host, maxCollision.Collider2.Host, (Side)maxCollision.CollisionSide, depth);
        }

        private ICollisionHandler GetCollisionHandler(ICollider collider1, ICollider collider2)
        {
            HashSet<ColliderCategories> pair = new HashSet<ColliderCategories> { collider1.Category, collider2.Category };
            return handlerList[pair];
        }

        private void InitializeHandlerList()
        {
            handlerList = new Dictionary<HashSet<ColliderCategories>, ICollisionHandler>(HashSet<ColliderCategories>.CreateSetComparer())
            {
                { new HashSet<ColliderCategories> { ColliderCategories.mario, ColliderCategories.enemy }, new MarioEnemyCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.mario, ColliderCategories.item }, new MarioItemCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.mario, ColliderCategories.block }, new MarioBlockCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.mario, ColliderCategories.pipe }, new MarioPipeCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.mario, ColliderCategories.terrain }, new MarioTerrainCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.mario, ColliderCategories.triggerZone }, new MarioTriggerZoneCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.item, ColliderCategories.block }, new ItemBlockCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.item, ColliderCategories.enemy }, new ItemEnemyCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.item, ColliderCategories.item }, new ItemItemCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.item, ColliderCategories.pipe }, new ItemTerrainCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.item, ColliderCategories.terrain }, new ItemTerrainCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.item, ColliderCategories.triggerZone }, new ItemTriggerZoneCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.enemy, ColliderCategories.enemy }, new EnemyEnemyCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.enemy, ColliderCategories.pipe }, new EnemyTerrainCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.enemy, ColliderCategories.terrain }, new EnemyTerrainCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.enemy, ColliderCategories.block }, new EnemyBlockCollisionHandler() },
                { new HashSet<ColliderCategories> { ColliderCategories.enemy, ColliderCategories.triggerZone }, new ItemTriggerZoneCollisionHandler() }
            };
        }

        private static float DetermineDepth(Rectangle collision, Side side)
        {
            float depth = side == Side.left || side == Side.right ? collision.Width : collision.Height+1;
            return depth;
        }

        private static Side DetermineCollisionSide(Rectangle bounds, Rectangle collision)
        {
            bool rightOfLeftSide = collision.Left != bounds.Left;
            bool leftOfRightSide = collision.Right != bounds.Right;
            bool aboveBottomSide = collision.Bottom != bounds.Bottom;
            bool belowTopSide = collision.Top != bounds.Top; ;

            if(rightOfLeftSide == leftOfRightSide)
            {
                if (!aboveBottomSide && belowTopSide)
                {
                    return Side.bottom;
                } else if(aboveBottomSide && !belowTopSide)
                {
                    return Side.top;
                }
            }
            if(aboveBottomSide == belowTopSide)
            {
                if(!rightOfLeftSide && leftOfRightSide)
                {
                    return Side.left;
                } else if(rightOfLeftSide && !leftOfRightSide)
                {
                    return Side.right;
                }
            }
            //TODO collision side fails in some cases (especially when one object is very big, e.g. the pipe)
            bool inTopRight = collision.Center.Y <= ((bounds.Height / bounds.Width) * (collision.Center.X - bounds.Center.X) + bounds.Center.Y);
            bool inTopLeft = collision.Center.Y <= ((-bounds.Height / bounds.Width) * (collision.Center.X - bounds.Center.X) + bounds.Center.Y);

            if(inTopLeft && inTopRight)
            {
                return Side.top; 
            }
            if(!inTopLeft && inTopRight)
            {
                return Side.right;
            }
            if(inTopLeft && !inTopRight)
            {
                return Side.left;
            }
            if(!inTopLeft && !inTopRight) 
            {
                return Side.bottom;
            }
            return Side.bottom;
        }
    }
}
