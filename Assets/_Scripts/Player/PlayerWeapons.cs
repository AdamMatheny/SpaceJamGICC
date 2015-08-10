using UnityEngine;
using Assets._Scripts.Weapons;

namespace Assets._Scripts.Player
{
    public class PlayerWeapons : MonoBehaviour
    {
        public Weapon BaseWeapon;

        public Weapon SuperWeapon1;

        public void ShootBaseWeapon()
        {
            BaseWeapon.Shoot();
        }

        public void ShootSuperWeapon1()
        {
            SuperWeapon1.Shoot();
        }
    }
}
