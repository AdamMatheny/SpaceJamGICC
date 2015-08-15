using UnityEngine;

namespace Assets._Scripts.Managers
{
    [System.Serializable]
    public class PlayerControls
    {
        public string HorizontalAxis;
        public string VerticalAxis;
        public KeyCode BasicFireButton;
        public KeyCode MegaWeaponFireButton;
    }

    public class ControlsManager : Singleton<ControlsManager>
    {
        public PlayerControls Player1Controls;
        public PlayerControls Player2Controls;
    }
}
