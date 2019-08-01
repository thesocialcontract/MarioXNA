using Microsoft.Xna.Framework;

namespace Game1.WorldLoading.ProceduralGenerator
{
    public interface IGameplayContext
    {
        IChunk SelectRandomChunk();
    }
}
