using Game1.Audio;

namespace Game1.Entities.Enemies
{
    internal static class EnemyAudioManager
    {
        internal static void PlaySfxHitShell()
        {
            AudioManager.Instance.PlaySfxKickEnemy();
        }

        internal static void PlaySfxStomp()
        {
            AudioManager.Instance.PlaySfxStompEnemy();
        }
    }
}
