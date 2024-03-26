using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Mail
{
    public class MessageDetailPanel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _headerText;
        [SerializeField] private TextMeshProUGUI _messageText;
        [SerializeField] private Button _deleteButton;

        [SerializeField] private GameObject _content;
        [SerializeField] private GameObject _warning;

        private MessageInfo _currentMessage;
        
        public event System.Action OnDeleted;

        private void Awake()
        {
            _deleteButton.onClick.AddListener(DeleteMessage);
        }

        private void OnEnable()
        {
            _headerText.text = string.Empty;
            _messageText.text = string.Empty;
        }

        public void ShowMessage(MessageInfo messageInfo)
        {
            _content.SetActive(messageInfo != null);
            _warning.SetActive(messageInfo == null);
            _currentMessage = messageInfo;
            
            if (messageInfo == null)
                return;
            
            _headerText.text = messageInfo.HeaderText;
            _messageText.text = messageInfo.MessageText;
        }

        private void DeleteMessage()
        {
            _currentMessage.IsDeleted = !_currentMessage.IsDeleted;
            OnDeleted?.Invoke();
        }
    }
}