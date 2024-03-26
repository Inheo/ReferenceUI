using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Demo.Mail
{
    public class MessageInfoPool
    {
        private readonly MessageItem _prefab;
        private readonly RectTransform _messagesContainer;
        private readonly ToggleGroup _toggleGroup;

        private List<MessageItem> _pool;
        
        public MessageInfoPool(MessageItem prefab, RectTransform messagesContainer, ToggleGroup toggleGroup)
        {
            _prefab = prefab;
            _messagesContainer = messagesContainer;
            _toggleGroup = toggleGroup;
            _pool = new List<MessageItem>();
        }

        public MessageItem GetFree()
        {
            var msg = _pool.FirstOrDefault(x => x.gameObject.activeSelf == false);

            if (msg == null)
                msg = CreateItem();
            
            msg.gameObject.SetActive(true);
            return msg;
        }

        private MessageItem CreateItem()
        {
            var msg = Object.Instantiate(_prefab, _messagesContainer);
            var toggle = msg.GetComponent<Toggle>();
            toggle.group = _toggleGroup;
            _pool.Add(msg);
            return msg;
        }

        public void DisableAllItems()
        {
            foreach (var item in _pool)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}