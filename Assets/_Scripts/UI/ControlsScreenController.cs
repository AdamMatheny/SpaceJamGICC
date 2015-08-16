using UnityEngine;
using Assets._Scripts.Managers;
using Assets._Scripts.Audio;

namespace Assets._Scripts.UI
{
    public class ControlsScreenController : GUIScreen
    {
        public ScreenType NextScreenToShow;

        public override void Show()
        {
            base.Show();
            AudioManager.instance.PlayBackgroundMusic(BackgroundMusicType.Menu);
        }

        void Update()
        {
            if (!targetCanvas.enabled) return;

            if (Input.GetKeyDown(ControlsManager.instance.Player1Controls.MegaWeaponFireButton) || Input.GetKeyDown(ControlsManager.instance.Player1Controls.MegaWeaponFireButtonGamePad))
            {
                GUIManager.instance.ShowScreen(NextScreenToShow);
            }
        }
    }
}
