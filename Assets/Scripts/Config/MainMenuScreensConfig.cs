using UnityEngine;

namespace Demo.MainMenu.Config
{
    [CreateAssetMenu]
    public class MainMenuScreensConfig : ScriptableObject
    {
        [field: SerializeField] public RectTransform HomeScreenPrefab { get; private set; }
        [field: SerializeField] public RectTransform MailScreenPrefab { get; private set; } 
    }
}
