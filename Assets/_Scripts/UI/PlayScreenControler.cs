using UnityEngine.UI;
using UnityEngine;
using Assets._Scripts.Managers;
using Assets._Scripts.Audio;

namespace Assets._Scripts.UI
{
    public class PlayScreenControler : GUIScreen
    {
        [SerializeField]
        private Image Player1WeaponImage;
        [SerializeField]
        private Image Player1LightImage;

        [SerializeField]
        private Image Player2WeaponImage;
        [SerializeField]
        private Image Player2LightImage;

        [SerializeField]
        private Sprite NoWeaponSprite;

        public override void Show()
        {
            base.Show();
            AudioManager.instance.PlayMenuSound(MenuSoundType.SetReady);
        }

        public void SetUpWeaponImageForPlayer(int playerIndex, Sprite weaponsSprite)
        {
            switch (playerIndex)
            {
                case 1:
                    Player1WeaponImage.sprite = weaponsSprite;
                    Player1LightImage.enabled = true;
                    break;
                case 2:
                    Player2WeaponImage.sprite = weaponsSprite;
                    Player2LightImage.enabled = true;
                    break;
            }
        }

        public void UnsetUpWeaponImageForPlayer(int playerIndex)
        {
            switch (playerIndex)
            {
                case 1:
                    Player1WeaponImage.sprite = NoWeaponSprite;
                    Player1LightImage.enabled = false;
                    break;
                case 2:
                    Player2WeaponImage.sprite = NoWeaponSprite;
                    Player2LightImage.enabled = false;
                    break;
            }
        }
    }
}
