using UnityEngine;
using Assets._Scripts.Weapons;
using Assets._Scripts.Managers;
using System;
using System.Collections;

namespace Assets._Scripts.Items
{
    public class Collectable : MonoBehaviour
    {
        [Header("Collectable Info")]
        public WeaponType CollectableType;
        private int playerIndex;

        [Header("Collectable Movement")]
        public float movementSpeed;

        [Header("Collectable Probability")]
        public AnimationCurve CollectableProbability;
        
        public void Init(int TargetPlayerIndex)
        {
            playerIndex = TargetPlayerIndex;
            StartCoroutine("DestroySelfCoroutine");
            gameObject.transform.parent = MapManager.instance.CollectablesTransform;
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

        public float GetCurrentProbablitty(float adventage)
        {
            if (adventage < -1) adventage = -1;
            if (adventage > 1) adventage = 1;
            return CollectableProbability.Evaluate(adventage) * 100;
        }

        private IEnumerable DestroySelfCoroutine()
        {
            yield return new WaitForSeconds(10.0f);
            Destroy(gameObject);
        }
    }
}
