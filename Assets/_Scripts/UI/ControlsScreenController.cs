using UnityEngine;
using Assets._Scripts.Managers;

namespace Assets._Scripts.UI
{
    public class ControlsScreenController : GUIScreen
    {
        public ScreenType NextScreenToShow;

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
