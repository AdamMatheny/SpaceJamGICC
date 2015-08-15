using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Assets._Scripts.Managers
{
    public class MapManager : Singleton<MapManager>
    {
        public Transform PlayersTransform;
        public Transform ParticlesTransform;
        public Transform CollectablesTransform;
        public Transform EnemiesTransform;

        [SerializeField]
        private List<SpriteRenderer> Player1LevelBackground;
        [SerializeField]
        private List<SpriteRenderer> Player2LevelBackground;

        void Start()
        {
            if (PlayersTransform == null)
            {
                Debug.LogError("PlayerTransform is not set up in Map Manager!");
                PlayersTransform = gameObject.transform;
            }
            if (ParticlesTransform == null)
            {
                Debug.LogError("ParticlesTransform is not set up in Map Manager!");
                ParticlesTransform = gameObject.transform;
            }
            if (CollectablesTransform == null)
            {
                Debug.LogError("CollectablesTransform is not set up in Map Manager!");
                CollectablesTransform = gameObject.transform;
            }
            if (EnemiesTransform == null)
            {
                Debug.LogError("EnemiesTransform is not set up in Map Manager!");
                EnemiesTransform = gameObject.transform;
            }
        }

        public void ShowBackground(int level)
        {
            if (level < 1 || level > 5)
            {
                Debug.LogError("Tried to show Level that does not exits");
                return;
            }
            Player1LevelBackground.ForEach(background => background.enabled = false);
            Player2LevelBackground.ForEach(background => background.enabled = false);
            Player1LevelBackground[level - 1].enabled = true;
            Player2LevelBackground[level - 1].enabled = true;
        }
    }
}
