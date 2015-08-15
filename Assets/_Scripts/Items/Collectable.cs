using UnityEngine;
using Assets._Scripts.Weapons;
using Assets._Scripts.Managers;
using System;

namespace Assets._Scripts.Items
{
    [Serializable]
    public class CollectablePobabilty
    {
        public AnimationCurve Minus2RoundPosibility;
        public AnimationCurve Minus1RoundPosibility;
        public AnimationCurve EvenRoundPosibility;
        public AnimationCurve Plus1RoundPosibility;
        public AnimationCurve Plus2RoundPosibility;
    }

    public class Collectable : MonoBehaviour
    {
        [Header("Collectable Info")]
        public WeaponType CollectableType;
        private int playerIndex;

        [Header("Collectable Movement")]
        public float movementSpeed;

        [Header("Collectable Probability")]
        public CollectablePobabilty CollectableProbability;
        
        public void Init(int TargetPlayerIndex)
        {
            playerIndex = TargetPlayerIndex;
        }

        void Update()
        {
            Move();
            CheckDistanceToPlayer();
        }

        private void Move()
        {
            gameObject.transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);
        }

        private void CheckDistanceToPlayer()
        {
            switch (playerIndex)
            {
                case 1:
                    if (Vector3.Distance(gameObject.transform.position, VehiclesManager.instance.Player1Ship.gameObject.transform.position) < 1.5f)
                    {
                        VehiclesManager.instance.Player1Ship.PlayerWeaponsComponent.UnlockSuperWeapon(CollectableType);
                        Destroy(gameObject);
                    }
                    break;
                case 2:
                    if (Vector3.Distance(gameObject.transform.position, VehiclesManager.instance.Player2Ship.gameObject.transform.position) < 1.5f)
                    {
                        VehiclesManager.instance.Player2Ship.PlayerWeaponsComponent.UnlockSuperWeapon(CollectableType);
                        Destroy(gameObject);
                    }
                    break;
                default:
                    Debug.LogError("Collectable has not Player Index set up!");
                    break;
            }
            
        }
    }
}
