using System.IO;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using Microsoft.Xna.Framework;

namespace Game1.Entities
{
    public class ColliderFactory
    {
        private Dictionary<string, ColliderRegistrar> colliderRegistrars = new Dictionary<string, ColliderRegistrar>();
        public static ColliderFactory Instance { get; } = new ColliderFactory();

        private ColliderFactory() { }

        public void LoadContent(string colliderInfoFile)
        {
            string json = File.ReadAllText(colliderInfoFile);
            colliderRegistrars = new JavaScriptSerializer().Deserialize<Dictionary<string, ColliderRegistrar>>(json);
        }

        public Collider CreateCollider(string objectName, IGameEntity host)
        {
            return new Collider(colliderRegistrars[objectName], host);
        }

        public static Collider CreateCollider(IGameEntity host, Rectangle bounds)
        {
            return new Collider(false, host, bounds);
        }
    }
}
