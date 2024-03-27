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
        [SerializeField] private Toggle _playerInfoScreenToggle;
        [SerializeField] private Toggle _sendScreenToggle;
        [SerializeField] private Toggle _shopScreenToggle;
        [SerializeField] private Toggle _mailScreenToggle;

        private RectTransform _currentScreen;
        
        private void Awake()
        {
            TryOpenScreen(true, _screensConfig.HomeScreenPrefab);
            
            _homeScreenToggle.onValueChanged.AddListener(HomeToggleValueChanged);
            _playerInfoScreenToggle.onValueChanged.AddListener(PlayerInfoToggleValueChanged);
            _sendScreenToggle.onValueChanged.AddListener(SendToggleValueChanged);
            _shopScreenToggle.onValueChanged.AddListener(ShopToggleValueChanged);
            _mailScreenToggle.onValueChanged.AddListener(MailToggleValueChanged);
        }
        
        private void HomeToggleValueChanged(bool value) => TryOpenScreen(value, _screensConfig.HomeScreenPrefab);
        private void PlayerInfoToggleValueChanged(bool value) => TryOpenScreen(value, _screensConfig.PlayerInfoScreenPrefab);
        private void SendToggleValueChanged(bool value) => TryOpenScreen(value, _screensConfig.SendScreenPrefab);
        private void ShopToggleValueChanged(bool value) => TryOpenScreen(value, _screensConfig.ShopScreenPrefab);
        private void MailToggleValueChanged(bool value) => TryOpenScreen(value, _screensConfig.MailScreenPrefab);

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