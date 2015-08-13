using UnityEngine;

namespace Assets._Scripts.UI
{
    public enum ScreenType {None = 0, MainMenu = 1 , PlayScreen = 2}

    public class GUIScreen : MonoBehaviour
    {
        private Canvas targetCanvas;

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
