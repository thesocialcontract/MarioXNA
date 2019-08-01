using Game1.Entities.Items;
using System;
using Game1.WorldLoading;

namespace Game1.Entities.Mario.CollisionHandlers
{
    public class MarioItemCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(IGameEntity obj1, IGameEntity obj2, Side side, float depth)
        {
            IMario mario;
            Item item;
            
            if (obj1 is IMario)
            {
                mario = (IMario)obj1;
                item = (Item)obj2;
            }
            else
            {
                mario = (IMario)obj2;
                item = (Item)obj1;
            }
            
            switch (item.GetType().Name)
            {
                case "FireFlower":
                    if (!mario.MarioState.GetType().ToString().Contains("Fire"))
                    {
                        //World.Instance.Player = new BigToFireMario(mario);
                        mario.PhysicsEngine.SetPauseState(true);
                        mario.PhysicsEngine.ForceCancel(true);
                        mario.SetEndUpwardForce(true);
                        mario.SetFire();
                    }
                    World.Instance.AddToScore(1000);
                    RisingTextManager.Instance.AddRisingText(1000, item.WorldLocation);
                    item.Destroy();
                    break;
                case "PowerUpMushroom":
                    if (mario.MarioState.GetType().ToString().Contains("Small") )
                    {
                       // World.Instance.Player = new SmallToBigMario(mario);
                        mario.PhysicsEngine.SetPauseState(true);
                        mario.PhysicsEngine.ForceCancel(true);
                        mario.SetEndUpwardForce(true);
                        mario.SetBig();
                    }
                    World.Instance.AddToScore(1000);
                    RisingTextManager.Instance.AddRisingText(1000, item.WorldLocation);
                    item.Destroy();
                    break;
                case "Starman":
                    mario.SetStar();
                    World.Instance.AddToScore(1000);
                    RisingTextManager.Instance.AddRisingText(1000, item.WorldLocation);
                    item.Destroy();
                    break;
                case "OneUpMushroom":
                    ItemAudioManager.PlaySfxOneUp();
                    mario.Lives++;
                    item.Destroy();
                    break;
                case "Coin":
                    ItemAudioManager.PlaySfxCoin();
                    item.Destroy();
                    World.Instance.AddToCoins(1);
                    break;
                case "Fireball":
                    break;
                default:
                    item.Destroy();
                    break;
            }
        }
    }
}
