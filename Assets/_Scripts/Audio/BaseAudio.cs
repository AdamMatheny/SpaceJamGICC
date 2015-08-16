using UnityEngine;

namespace Assets._Scripts.Audio
{
    public enum ShipRedSoundType { ShootBasic, ShootUpgraded, TakeDamage };
    public enum ShipBlueSoundType { ShootBasic, ShootUpgraded, TakeDamage };
    public enum ShipPinkSoundType { ShootBasic, ShootUpgraded, TakeDamage };
    public enum ShipWhiteSoundType { ShootBasic, ShootUpgraded, TakeDamage };
    public enum MenuSoundType { MenuEnter, MenuBack, SetReady };
    public enum BackgroundMusicType { Intro, Menu, Level1, Level2, Level3, Level4, Level5, Credits };
    public enum MegaWeaponType { EnemyDisplacement, SlowMotion, InvertedControls, Deflect, WeaponDisable, VisionHindrance };

    public class BaseAudio : MonoBehaviour
    {
        private AudioSource audioSource;
        private float defaultVolume;

        protected virtual void Awake()
        {
            try
            {
                audioSource = GetComponent<AudioSource>();
                defaultVolume = audioSource.volume;
            }
            catch
            {
                Debug.LogError("Audio Script is attached to object " + gameObject.name + ", but this object has no AudioSource Component!");
            }
        }

        public virtual void Play()
        {
            audioSource.Play();
        }

        public virtual void Stop()
        {
            audioSource.Stop();
        }

        public virtual void SetVolume(float value)
        {
            if (value < 0) value = 0;
            if (value > 1) value = 1;
            audioSource.volume = defaultVolume * value;
        }

        public virtual bool IsPlaying()
        {
            return audioSource.isPlaying;
        }
    }
}
