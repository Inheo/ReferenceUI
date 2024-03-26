using UnityEngine;
using UnityEngine.UI;

namespace Demo.PlayerProfile
{
    public class PlayerProfileAnimator : MonoBehaviour
    {
        [SerializeField] private Image _lightImage;
        [SerializeField] private RectTransform _playerIcon;

        [Space] 
        [SerializeField, Tooltip("value -1 for infinite loop")] private int _repeat = -1;
        [SerializeField, Min(0.1f)] private float _duration = 1;
        [SerializeField, Min(0f)] private float _delay = 1;

        [Header("Light settings")]
        [SerializeField] private AnimationCurve _lightCurve;
        [SerializeField] private float _lightAlphaA = 0.8f;
        [SerializeField] private float _lightAlphaB = 1;

        [Header("Player icon settings")] 
        [SerializeField] private AnimationCurve _playerIconCurve;
        [SerializeField] private Vector3 _playerIconSizeA = new Vector3(0.9f, 0.9f, 0.9f);
        [SerializeField] private Vector3 _playerIconSizeB = new Vector3(1.1f, 1.1f, 1.1f);

        private void OnEnable()
        {
            this.StartAnimation(_repeat, _duration, _delay, _lightCurve, true, LightAction);
            this.StartAnimation(_repeat, _duration, _delay, _playerIconCurve,true, PlayerIconAction);
        }

        private void LightAction(float time)
        {
            var color = _lightImage.color;
            color.a = Mathf.Lerp(_lightAlphaA, _lightAlphaB, time);
            _lightImage.color = color;
        }
        
        private void PlayerIconAction(float time)
        {
            _playerIcon.localScale = Vector3.Lerp(_playerIconSizeA, _playerIconSizeB, time);
        }
    }
}
