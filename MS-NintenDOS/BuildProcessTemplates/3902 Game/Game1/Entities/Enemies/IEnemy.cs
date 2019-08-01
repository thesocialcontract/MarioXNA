namespace Game1.Entities.Enemies
{
    public interface IEnemy
    {
        void Update();
        void Draw();
        void TakeDamage();
        void Kill();

       
    }
}
