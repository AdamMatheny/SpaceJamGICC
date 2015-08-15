using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Assets._Scripts.Audio;

namespace Assets._Scripts.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        [Header("Lists of Sounds")]
        [SerializeField]
        private List<ShipRedSound> RedShipSoundList;
        [SerializeField]
        private List<ShipBlueSound> BlueShipSoundList;
        [SerializeField]
        private List<ShipPinkSound> PinkShipSoundList;
        [SerializeField]
        private List<ShipWhiteSound> WhiteShipSoundList;
        [SerializeField]
        private List<MenuSound> MenuSoundList;

        [Header("Lists of Music")]
        [SerializeField]
        private List<BackgroundMusic> BackgroundMusicList;

        private float CurrentSoundVolume = 1;
        private float CurrentMusicVolume = 1;

        void Start()
        {
            if (PlayerPrefs.HasKey("CurrentSoundVolume"))
            {
                CurrentSoundVolume = PlayerPrefs.GetFloat("CurrentSoundVolume");
                SetSoundsVolumeWithoutSample(CurrentSoundVolume);
            }
            if (PlayerPrefs.HasKey("CurrentMusicVolume"))
            {
                CurrentMusicVolume = PlayerPrefs.GetFloat("CurrentMusicVolume");
                SetMusicVolume(CurrentMusicVolume);
            }
        }

        public void PlayRedShipSound(ShipRedSoundType type)
        {
            RedShipSoundList.First(sound => sound.soundType == type).Play();
        }

        public void PlayBlueShipSound(ShipBlueSoundType type)
        {
            BlueShipSoundList.First(sound => sound.soundType == type).Play();
        }

        public void PlayPinkShipSound(ShipPinkSoundType type)
        {
            PinkShipSoundList.First(sound => sound.soundType == type).Play();
        }

        public void PlayWhiteShipSound(ShipWhiteSoundType type)
        {
            WhiteShipSoundList.First(sound => sound.soundType == type).Play();
        }

        public void PlayMenuSound(MenuSoundType type)
        {
            MenuSoundList.First(sound => sound.soundType == type).Play();
        }

        public void PlayBackgroundMusic(BackgroundMusicType type)
        {
            BackgroundMusicList.ForEach(sound => sound.Stop());
            BackgroundMusicList.First(sound => sound.soundType == type).Play();
        }

        public void SetSoundsVolume(float value)
        {
            RedShipSoundList.ForEach(sound => sound.SetVolume(value));
            BlueShipSoundList.ForEach(sound => sound.SetVolume(value));
            PinkShipSoundList.ForEach(sound => sound.SetVolume(value));
            WhiteShipSoundList.ForEach(sound => sound.SetVolume(value));
            MenuSoundList.ForEach(sound => sound.SetVolume(value));

            if (!RedShipSoundList.First(sound => sound.soundType == ShipRedSoundType.ShootBasic).IsPlaying())
                PlayRedShipSound(ShipRedSoundType.ShootBasic);

            CurrentSoundVolume = value;
            PlayerPrefs.SetFloat("CurrentSoundVolume", CurrentSoundVolume);
        }

        public void SetSoundsVolumeWithoutSample(float value)
        {
            RedShipSoundList.ForEach(sound => sound.SetVolume(value));
            BlueShipSoundList.ForEach(sound => sound.SetVolume(value));
            PinkShipSoundList.ForEach(sound => sound.SetVolume(value));
            WhiteShipSoundList.ForEach(sound => sound.SetVolume(value));
            MenuSoundList.ForEach(sound => sound.SetVolume(value));

            CurrentSoundVolume = value;
            PlayerPrefs.SetFloat("CurrentSoundVolume", CurrentSoundVolume);
        }

        public void SetMusicVolume(float value)
        {
            BackgroundMusicList.ForEach(sound => sound.SetVolume(value));

            CurrentMusicVolume = value;
            PlayerPrefs.SetFloat("CurrentMusicVolume", CurrentMusicVolume);
        }

        public float GetCurrentSoundVolume()
        {
            return CurrentSoundVolume;
        }

        public float GetCurrentMusicVolume()
        {
            return CurrentMusicVolume;
        }
    }
}
