using Game1.Audio;

namespace Game1.WorldLoading
{
    public class WorldAudioManager
    {
        public static WorldAudioManager Instance { get; } = new WorldAudioManager();
        private float timeTilNextSong = 0.0f;
        private string previousSong;

        private WorldAudioManager()
        {
            previousSong = "";
        }

        public static bool IsHurried { get; set; }
        public static bool IsOverworld { get; set; }
        public static void Pause()
        {
            AudioManager.Instance.PlaySfxPause();
            AudioManager.PauseMusic();
        }
        public static void WorldAudioResume()
        {
            AudioManager.ResumeMusic();
        }
        public static void PlayMusicOverworld()
        {
            if (IsHurried)
                AudioManager.Instance.PlayMusicOverworldFast();
            else
                AudioManager.Instance.PlayMusicOverworld();
        }
        
        public static void PlayMusicUnderworld()
        {
            if (IsHurried)
                AudioManager.Instance.PlayMusicUnderworldFast();
            else
                AudioManager.Instance.PlayMusicUnderworld();
        }
        public static void PlayBackgroundMusic()
        {
            if (IsOverworld)
                PlayMusicOverworld();
            else
                PlayMusicUnderworld();
        }
        public static void PlayMusicWin()
        {
            AudioManager.Instance.PlayMusicStageClear();
        }
        public static void PlayGameOver()
        {
            AudioManager.Instance.PlayMusicGameOver();
        }
        public static void StartOverworldLevel()
        {
            IsHurried = false;
            IsOverworld = true;
            PlayBackgroundMusic();
        }
        public void SetHurry()
        {
            IsHurried = true;
            previousSong = AudioManager.Instance.CurrentSong;
            AudioManager.Instance.PlayMusicWarning();
            timeTilNextSong = AudioManager.Instance.GetMusicLength(AudioConstants.MusicWarning);
            
        }
        public void SetWorldArea(bool isInUnderground)
        {
            bool isSwitchingToUnderworld = IsOverworld && isInUnderground;
            bool isSwitchingToOverworld = !IsOverworld && !isInUnderground;
            if (isSwitchingToOverworld || isSwitchingToUnderworld)
            {
                IsOverworld = isSwitchingToOverworld;
                PlayBackgroundMusic();
            }
        }
        private void ResumeAfterWarning()
        {
            if (previousSong == AudioConstants.MusicOverworld || previousSong == AudioConstants.MusicUnderworld)
                PlayBackgroundMusic();
            else if (previousSong == AudioConstants.MusicStarman)
                AudioManager.Instance.PlayMusicStarman();

            previousSong = "";
        }
        public void Update()
        {
            if (timeTilNextSong > 0.0f)
                timeTilNextSong -= Globals.GameGlobals.dt;
            if (timeTilNextSong < 0.0f)
            {
                timeTilNextSong = 0.0f;
                ResumeAfterWarning();
            }
        }
    }
}
