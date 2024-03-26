using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Mail
{
    [RequireComponent(typeof(Toggle))]
    public class MessageItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _dateText;
        [SerializeField] private GameObject _readedFlag;

        private MessageInfo _currentInfo;
        private Toggle _toggle;
        public event System.Action<MessageInfo> OnClick;

        public bool IsSelected => _toggle.isOn;
        
        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            _toggle.onValueChanged.AddListener(ToggleValueChanged);
        }

        private void OnDisable() => OnClick = null;

        public void Init(MessageInfo info)
        {
            _currentInfo = info;
            _headerText.text = info.HeaderText;
            _dateText.text = info.Date;
            _readedFlag.gameObject.SetActive(!info.IsReaded);
        }

        private void ToggleValueChanged(bool value)
        {
            if (!value)
                return;

            _currentInfo.IsReaded = true;
            _readedFlag.gameObject.SetActive(false);
            OnClick?.Invoke(_currentInfo);
        }
    }
}