using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace Game1.Audio
{
    public class AudioManager
    {
        private Dictionary<string, SoundEffect> soundEffects = new Dictionary<string, SoundEffect>();
        private Dictionary<string, Song> music = new Dictionary<string, Song>();
        public static AudioManager Instance { get; } = new AudioManager();
        public string CurrentSong { get; private set; }
        public void LoadContent(ContentManager content)
        {
            LoadSoundEffects(content);
            LoadMusic(content);
        }

        private void LoadSoundEffects(ContentManager content)
        {
            var soundEffectNames = new List<string>()
            {
                AudioConstants.SfxBlockBreak,
                AudioConstants.SfxBlockBump,
                AudioConstants.SfxBlockPowerupAppears,
                AudioConstants.SfxEnemyKick,
                AudioConstants.SfxEnemyStomp,
                AudioConstants.SfxPause,
                AudioConstants.SfxItemOneUp,
                AudioConstants.SfxItemCoin,
                AudioConstants.SfxMarioFireball,
                AudioConstants.SfxMarioJumpBig,
                AudioConstants.SfxMarioJumpSmall,
                AudioConstants.SfxMarioPowerup,
                AudioConstants.SfxWorldFlagpole,
                AudioConstants.SfxWorldPipe,
                AudioConstants.SfxCharge
            };

            foreach (var name in soundEffectNames)
            {
                var effect = content.Load<SoundEffect>(name);
                soundEffects.Add(name, effect);
            }
        }

        private void LoadMusic(ContentManager content)
        {
            var musicNames = new List<string>()
            {
                AudioConstants.MusicGameover,
                AudioConstants.MusicMarioDie,
                AudioConstants.MusicOverworld,
                AudioConstants.MusicOverworldHurry,
                AudioConstants.MusicUnderworld,
                AudioConstants.MusicUnderworldHurry,
                AudioConstants.MusicStageClear,
                AudioConstants.MusicWarning,
                AudioConstants.MusicStarman
                
            };
            
            foreach (var name in musicNames)
            {
                var song = content.Load<Song>(name);
                music.Add(name, song);
            }
        }

        public float GetMusicLength(string name)
        {
            if (!music.ContainsKey(name)) return 0.0f;
            return (float)music[name].Duration.TotalSeconds;
        }

        public void PlaySound(string sfxName)
        {
            if (!soundEffects.ContainsKey(sfxName)) return;

            soundEffects[sfxName].Play();
        }

        public void PlayMusic(string musicName, bool isRepeating)
        {
            if (!music.ContainsKey(musicName)) return;
            
            MediaPlayer.IsRepeating = isRepeating;
            var song = music[musicName];
            MediaPlayer.Play(song);
            CurrentSong = musicName;
        }

        public static void PauseMusic()
        {
            MediaPlayer.Pause();
        }
        public static void ResumeMusic()
        {
            MediaPlayer.Resume();
        }

        // Music
        public void PlayMusicOverworld()
        {
            PlayMusic(AudioConstants.MusicOverworld, true);
        }
        public void PlayMusicUnderworld()
        {
            PlayMusic(AudioConstants.MusicUnderworld, true);
        }
        public void PlayMusicStageClear()
        {
            PlayMusic(AudioConstants.MusicStageClear, false);
        }
        public void PlayMusicMarioDie()
        {
            PlayMusic(AudioConstants.MusicMarioDie, false);
        }
        public void PlayMusicWarning()
        {
            PlayMusic(AudioConstants.MusicWarning, false);
        }
        public void PlayMusicGameOver()
        {
            PlayMusic(AudioConstants.MusicGameover, false);
        }
        public void PlayMusicOverworldFast()
        {
            PlayMusic(AudioConstants.MusicOverworldHurry, isRepeating: true);
        }
        public void PlayMusicUnderworldFast()
        {
            PlayMusic(AudioConstants.MusicUnderworldHurry, isRepeating: true);
        }
        public void PlayMusicStarman()
        {
            PlayMusic(AudioConstants.MusicStarman, isRepeating: true);
        }
        

        // SFX
        public void PlaySfxBreakBlock()
        {
            PlaySound(AudioConstants.SfxBlockBreak);
        }
        public void PlaySfxBumpBlock()
        {
            PlaySound(AudioConstants.SfxBlockBump);
        }
        public void PlaySfxPowerupAppears()
        {
            PlaySound(AudioConstants.SfxBlockPowerupAppears);
        }
        public void PlaySfxKickEnemy()
        {
            PlaySound(AudioConstants.SfxEnemyKick);
        }
        public void PlaySfxStompEnemy()
        {
            PlaySound(AudioConstants.SfxEnemyStomp);
        }
        public void PlaySfxPause()
        {
            PlaySound(AudioConstants.SfxPause);
        }
        public void PlaySfxOneUp()
        {
            PlaySound(AudioConstants.SfxItemOneUp);
        }
        public void PlaySfxCoin()
        {
            PlaySound(AudioConstants.SfxItemCoin);
        }
        public void PlaySfxFireball()
        {
            PlaySound(AudioConstants.SfxMarioFireball);
        }
        public void PlaySfxJumpSmall()
        {
            PlaySound(AudioConstants.SfxMarioJumpSmall);
        }
        public void PlaySfxJumpBig()
        {
            PlaySound(AudioConstants.SfxMarioJumpBig);
        }
        public void PlaySfxPowerup()
        {
            PlaySound(AudioConstants.SfxMarioPowerup);
        }
        public void PlaySfxPowerdown()
        {
            PlaySound(AudioConstants.SfxWorldPipe);
        }
        public void PlaySfxPipe()
        {
            PlaySound(AudioConstants.SfxWorldPipe);
        }
        public void PlaySfxFlagpole()
        {
            PlaySound(AudioConstants.SfxWorldFlagpole);
        }
        public void PlaySfxCharge()
        {
            PlaySound(AudioConstants.SfxCharge);
        }
    }
}
