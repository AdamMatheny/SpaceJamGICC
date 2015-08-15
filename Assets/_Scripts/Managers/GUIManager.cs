using Assets._Scripts.UI;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace Assets._Scripts.Managers
{
    public class GUIManager : Singleton<GUIManager>
    {
        [SerializeField]
        private List<GUIScreen> GUIScreens;

        private ScreenType currentScreen;

        public void ShowScreen(ScreenType type)
        {
            HideCurrentScreen();
            GUIScreens.First(screen => screen.ScreenType == type).Show();
            currentScreen = type;
        }

        public void ShowScreen(int index)
        {
            ScreenType type = (ScreenType)index;
            ShowScreen(type);
        }

        public void ShowScreen(string name)
        {
            ScreenType type = (ScreenType)Enum.Parse(typeof(ScreenType), name);
            ShowScreen(type);
        }

        private void HideCurrentScreen()
        {
            if (currentScreen != ScreenType.None)
                GUIScreens.First(screen => screen.ScreenType == currentScreen).Hide();
        }

        void Start()
        {
            ShowScreen(ScreenType.MainMenu);
        }
    }
}
