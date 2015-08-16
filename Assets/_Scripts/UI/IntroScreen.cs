using System.Collections;
using UnityEngine;
using Assets._Scripts.Managers;

namespace Assets._Scripts.UI
{
    public class IntroScreen : GUIScreen
    {
        [Header("Intro Components")]
        public float TimeToSwitchScreen;
        public ScreenType NextScreenToShow;
        public Animator ScreenAnimator;
        public string AnimationName;

        public override void Show()
        {
            base.Show();
            StartCoroutine("WaitToShowNextScreen");
            ScreenAnimator.Play(AnimationName);
        }

        void Update()
        {
            if (!targetCanvas.enabled) return;

            if (/*Input.GetKeyDown(ControlsManager.instance.Player1Controls.BasicFireButton) ||
                Input.GetKeyDown(ControlsManager.instance.Player1Controls.BasicFireButtonGamePad) ||*/
                Input.GetKeyDown(ControlsManager.instance.Player1Controls.MegaWeaponFireButton) ||
                Input.GetKeyDown(ControlsManager.instance.Player1Controls.MegaWeaponFireButtonGamePad))
            {
                Skip();
            }
        }

        private void Skip()
        {
            StopCoroutine("WaitToShowNextScreen");
            GUIManager.instance.ShowScreen(NextScreenToShow);
        }

        private IEnumerator WaitToShowNextScreen()
        {
            yield return new WaitForSeconds(TimeToSwitchScreen);
            GUIManager.instance.ShowScreen(NextScreenToShow);
        }
    }
}
