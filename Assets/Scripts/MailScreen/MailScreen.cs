using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Mail
{
    public class MailScreen : MonoBehaviour
    {
        [SerializeField] private MessageInfoStorage _messagesStorage;
        [SerializeField] private MessageDetailPanel _messageDetailPanel;
        [SerializeField] private RectTransform _messagesContainer;
        [SerializeField] private MessageItem _messageItemPrefab;

        [Header("Toggles")] 
        [SerializeField] private ToggleGroup _toggleGroup;
        [SerializeField] private Toggle _inboxToggle;
        [SerializeField] private Toggle _deletedToggle;

        private MessageInfoPool _messageItemPool;
        private MailScreenState _state = MailScreenState.Inbox;

        private void Awake()
        {
            _messageItemPool = new MessageInfoPool(_messageItemPrefab, _messagesContainer, _toggleGroup);
            _inboxToggle.onValueChanged.AddListener(InboxToggleValueChanged);
            _deletedToggle.onValueChanged.AddListener(DeletedToggleValueChanged);
            _messageDetailPanel.OnDeleted += UpdateMessages;
        }
        
        private void OnEnable() => ShowMessages();
        private void UpdateMessages() => ShowMessages();

        private void InboxToggleValueChanged(bool value)
        {
            if (!value)
                return;

            _state = MailScreenState.Inbox;
            ShowMessages();
        }
        
        private void DeletedToggleValueChanged(bool value)
        {
            if (!value)
                return;
            
            _state = MailScreenState.Deleted;
            ShowMessages();
        }
        
        private void ShowMessages()
        {
            var messages = GetCurrentMessages();
            MessageInfo activeMessageInfo = null;
            
            _messageItemPool.DisableAllItems();
            
            foreach (var item in messages)
            {
                var msg = _messageItemPool.GetFree();
                msg.Init(item);
                msg.OnClick += OpenMessage;
                activeMessageInfo = msg.IsSelected ? item : activeMessageInfo;
            }
            
            OpenMessage(activeMessageInfo);
        }

        private List<MessageInfo> GetCurrentMessages()
        {
            return _state == MailScreenState.Deleted
                ? _messagesStorage.GetDeletedMessages()
                : _messagesStorage.GetInboxMessages();
        }

        private void OpenMessage(MessageInfo messageInfo) => 
            _messageDetailPanel.ShowMessage(messageInfo);
    }
}