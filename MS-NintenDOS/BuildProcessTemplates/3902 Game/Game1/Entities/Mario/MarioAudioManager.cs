using Game1.Audio;

namespace Game1.Entities.Mario
{
    internal static class MarioAudioManager
    {
        internal static void PlaySfxJumpSmall()
        {
            AudioManager.Instance.PlaySfxJumpSmall();
        }
        internal static void PlaySfxJumpBig()
        {
            AudioManager.Instance.PlaySfxJumpBig();
        }
        internal static void PlaySfxFireball()
        {
            AudioManager.Instance.PlaySfxFireball();
        }
        internal static void PlaySfxPowerup()
        {
            AudioManager.Instance.PlaySfxPowerup();
        }
        internal static void PlaySfxPowerdown()
        {
            AudioManager.Instance.PlaySfxPowerdown();
        }
        internal static void PlayMarioDie()
        {
            AudioManager.Instance.PlayMusicMarioDie();
        }
        internal static void PlayStarman()
        {
            AudioManager.Instance.PlayMusicStarman();
        }
        internal static void PlaySfxCharge()
        {
            AudioManager.Instance.PlaySfxCharge();
        }

    }
}
