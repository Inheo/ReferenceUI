using UnityEngine;

namespace Demo.MainMenu.Config
{
    [CreateAssetMenu]
    public class MainMenuScreensConfig : ScriptableObject
    {
        [field: SerializeField] public RectTransform HomeScreenPrefab { get; private set; }
        [field: SerializeField] public RectTransform PlayerInfoScreenPrefab { get; private set; } 
        [field: SerializeField] public RectTransform SendScreenPrefab { get; private set; } 
        [field: SerializeField] public RectTransform ShopScreenPrefab { get; private set; } 
        [field: SerializeField] public RectTransform MailScreenPrefab { get; private set; } 
    }
}
