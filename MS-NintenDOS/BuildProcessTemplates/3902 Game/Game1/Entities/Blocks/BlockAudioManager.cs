using Game1.Audio;

namespace Game1.Entities.Blocks
{
    internal static class BlockAudioManager
    {
        internal static void PlaySfxCoin()
        {
            AudioManager.Instance.PlaySfxCoin();
        }
        internal static void PlaySfxBump()
        {
            AudioManager.Instance.PlaySfxBumpBlock();
        }
        internal static void PlaySfxBreak()
        {
            AudioManager.Instance.PlaySfxBreakBlock();
        }
        internal static void PlaySfxPowerUpAppears()
        {
            AudioManager.Instance.PlaySfxPowerupAppears();
        }
    }
}
