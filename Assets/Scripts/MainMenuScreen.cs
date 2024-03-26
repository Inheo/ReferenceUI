using System.Collections;
using System.Collections.Generic;
using Demo.MainMenu.Config;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.MainMenu
{
    public class MainMenuScreen : MonoBehaviour
    {
        [SerializeField] private RectTransform _screenContainer;
        [SerializeField] private MainMenuScreensConfig _screensConfig;
        
        [Header("Toggles")]
        [SerializeField] private Toggle _homeScreenToggle;
        [SerializeField] private Toggle _mailScreenToggle;

        private RectTransform _currentScreen;
        
        private void Awake()
        {
            TryOpenHomeScreen(true);
            _homeScreenToggle.onValueChanged.AddListener(HomeToggleValueChanged);
            _mailScreenToggle.onValueChanged.AddListener(MailToggleValueChanged);
        }
        
        private void HomeToggleValueChanged(bool value)
        {
            TryOpenHomeScreen(value);
        }
        
        private void MailToggleValueChanged(bool value)
        {
            TryOpenMailScreen(value);
        }
        
        private void TryOpenHomeScreen(bool isNeedOpenNewScreen) => 
            TryOpenScreen(isNeedOpenNewScreen, _screensConfig.HomeScreenPrefab);

        private void TryOpenMailScreen(bool isNeedOpenNewScreen) =>
            TryOpenScreen(isNeedOpenNewScreen, _screensConfig.MailScreenPrefab);
        
        private void TryOpenScreen(bool isNeedOpenNewScreen, RectTransform prefab)
        {
            if (!isNeedOpenNewScreen)
                return;
        
            CloseCurrentScreen();
        
            _currentScreen = Object.Instantiate(prefab, _screenContainer);
        }

        private void CloseCurrentScreen()
        {
            if (_currentScreen != null)
                Object.Destroy(_currentScreen.gameObject);
        }
    }
}