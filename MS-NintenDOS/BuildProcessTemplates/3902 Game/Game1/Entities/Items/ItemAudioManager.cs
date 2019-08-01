using Game1.Audio;

namespace Game1.Entities.Items
{
    internal static class ItemAudioManager
    {
        internal static void PlaySfxCoin()
        {
            AudioManager.Instance.PlaySfxCoin();
        }
        internal static void PlaySfxOneUp()
        {
            AudioManager.Instance.PlaySfxOneUp();
        }
    }
}
