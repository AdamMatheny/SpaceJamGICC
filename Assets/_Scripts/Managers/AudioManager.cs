using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Assets._Scripts.Audio;

namespace Assets._Scripts.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        public List<ShipRedSound> RedShipSoundList;
        public List<ShipBlueSound> BlueShipSoundList;
        public List<ShipPinkSound> PinkShipSoundList;
        public List<ShipWhiteSound> WhiteShipSoundList;
        public List<MenuSound> MenuSoundList;

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
    }
}
