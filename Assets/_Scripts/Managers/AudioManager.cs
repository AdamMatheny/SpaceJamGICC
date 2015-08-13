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

        public void PlayerRedShipSound(ShipRedSoundType type)
        {
            RedShipSoundList.First(sound => sound.soundType == type).Play();
        }
    }
}
