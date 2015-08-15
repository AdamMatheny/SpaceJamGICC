using UnityEngine.UI;
using UnityEngine;
using Assets._Scripts.Managers;

namespace Assets._Scripts.UI
{
    public class OptionsController : GUIScreen
    {
        [SerializeField]
        private Slider SoundVolumeSlider;
        [SerializeField]
        private Slider MusicVolumeSlider;

        public override void Show()
        {
            base.Show();
            SoundVolumeSlider.value = AudioManager.instance.GetCurrentSoundVolume();
            MusicVolumeSlider.value = AudioManager.instance.GetCurrentMusicVolume();
        }
    }
}
