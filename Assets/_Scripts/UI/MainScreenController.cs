using UnityEngine;
using Assets._Scripts.Managers;

namespace Assets._Scripts.UI
{
    public class MainScreenController : GUIScreen
    {
        void Update()
        {
            if (!targetCanvas.enabled) return;

            if (Input.GetKeyDown(ControlsManager.instance.Player1Controls.BasicFireButton) || Input.GetKeyDown(ControlsManager.instance.Player1Controls.BasicFireButton))
            {
                GUIManager.instance.ShowScreen(ScreenType.Intro1);
            }
        }
    }
}
