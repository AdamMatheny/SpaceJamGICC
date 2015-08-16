using UnityEngine;

namespace Assets._Scripts.UI
{
    public enum ScreenType {None = 0, MainMenu = 1 , PlayScreen = 2, SelectVehicle = 3, Options = 4, Intro1 = 5, Intro2 = 6, Intro3 = 7, Credits = 8}

    public class GUIScreen : MonoBehaviour
    {
        protected Canvas targetCanvas;

        public ScreenType ScreenType;

        protected virtual void Awake()
        {
            try
            {
                targetCanvas = GetComponent<Canvas>();
            }
            catch
            {
                Debug.LogError("Gameobject " + gameObject.name + " has GUI script attached but does not have Canvas component!");
            }
        }

        public virtual void Show()
        {
            targetCanvas.enabled = true;
        }

        public virtual void Hide()
        {
            targetCanvas.enabled = false;
        }
    }
}
