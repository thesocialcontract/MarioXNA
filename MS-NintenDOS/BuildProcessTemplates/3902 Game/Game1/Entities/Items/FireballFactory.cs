namespace Game1.Entities.Items
{
    public class FireballFactory
    {
        private double SecondsSinceFireball;
        private IGameEntity host;
        public FireballFactory(IGameEntity host)
        {
            this.host = host;
            SecondsSinceFireball = (int) Globals.GameGlobals.GameTime.TotalGameTime.TotalMilliseconds;
        }
        public Fireball CreateFireball()
        {
            double dt = Globals.GameGlobals.GameTime.TotalGameTime.TotalMilliseconds;
            // TODO-CALEB: var SecondsTilSpawnFireball = .5f;
            if(dt - SecondsSinceFireball > 500)
            {
                SecondsSinceFireball = dt;
                return new Fireball(host.WorldLocation);
            }
            else
            {
                return null;
            }
        }
    }
}
