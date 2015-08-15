using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets._Scripts.Items;
using Assets._Scripts.Weapons;

namespace Assets._Scripts.Managers
{
    public class CollectablesManager : Singleton<CollectablesManager>
    {
        [SerializeField]
        private List<Collectable> collectablesList;

        [SerializeField]
        private Transform player1SpwnPoint;
        [SerializeField]
        private float player1SpawnOffset;

        [SerializeField]
        private Transform player2SpwnPoint;
        [SerializeField]
        private float player2SpawnOffset;

        private void RandomlySpawnCollectablesForPlayer(int player)
        {
            float random = Random.Range(0, 10000) / 100.0f;
            float currentPlayerAdventage = 0;

            List<Collectable> collectablesThatCanBeSpawned = new List<Collectable>();

            foreach(var collectables in collectablesList)
            {
                if (collectables.GetCurrentProbablitty(currentPlayerAdventage) >= random)
                {
                    collectablesThatCanBeSpawned.Add(collectables);
                }
            }

            if (collectablesThatCanBeSpawned.Count > 0)
            {
                int randomCollectable = Random.Range(0, collectablesThatCanBeSpawned.Count);
                if (player == 1)
                    (Instantiate(collectablesThatCanBeSpawned[randomCollectable].gameObject, calculateSpawnPointForPlayer1(), player1SpwnPoint.rotation) as GameObject).GetComponent<Collectable>().Init(1);
                if (player == 2)
                    (Instantiate(collectablesThatCanBeSpawned[randomCollectable].gameObject, calculateSpawnPointForPlayer2(), player2SpwnPoint.rotation) as GameObject).GetComponent<Collectable>().Init(2);
            }
        }

        private Vector3 calculateSpawnPointForPlayer1()
        {
            float randomX = Random.Range(-100, 100) * player1SpawnOffset / 100.0f;
            return new Vector3(player1SpwnPoint.position.x + randomX, player1SpwnPoint.position.y, player1SpwnPoint.position.z);
        }

        private Vector3 calculateSpawnPointForPlayer2()
        {
            float randomX = Random.Range(-100, 100) * player2SpawnOffset / 100.0f;
            return new Vector3(player2SpwnPoint.position.x + randomX, player2SpwnPoint.position.y, player2SpwnPoint.position.z);
        }

        private IEnumerator SpawnCollectables()
        {
            while (true)
            {
                yield return new WaitForSeconds(15.0f);
                RandomlySpawnCollectablesForPlayer(1);
                RandomlySpawnCollectablesForPlayer(2);
            }
        }

        public void StartSpawning()
        {
            StartCoroutine("SpawnCollectables");
        }

        public void StopSpawning()
        {
            StopCoroutine("SpawnCollectables");
        }
    }
}
