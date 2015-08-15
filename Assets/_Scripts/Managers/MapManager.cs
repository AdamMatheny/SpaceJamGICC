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

        [SerializeField]
        private List<SpriteRenderer> Player1LevelBackground;
        [SerializeField]
        private List<SpriteRenderer> Player2LevelBackground;

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
