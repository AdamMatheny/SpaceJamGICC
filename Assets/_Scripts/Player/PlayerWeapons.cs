using UnityEngine;
using Assets._Scripts.Weapons;
using Assets._Scripts.Managers;
using Assets._Scripts.Audio;

namespace Assets._Scripts.Player
{
    public class PlayerWeapons : MonoBehaviour
    {
        public Weapon BaseWeapon;

        public Weapon SuperWeapon1;

        public void ShootBaseWeapon()
        {
            BaseWeapon.Shoot();
            AudioManager.instance.PlayerRedShipSound(ShipRedSoundType.ShootBasic);
        }

        public void ShootSuperWeapon1()
        {
            SuperWeapon1.Shoot();
        }
    }
}
