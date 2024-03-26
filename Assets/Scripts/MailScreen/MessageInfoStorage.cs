using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Demo.Mail
{
    [CreateAssetMenu]
    public class MessageInfoStorage : ScriptableObject
    {
        [SerializeField] private List<MessageInfo> _messages;

        public List<MessageInfo> GetInboxMessages() => _messages.Where(x => !x.IsDeleted).ToList();
        public List<MessageInfo> GetDeletedMessages() => _messages.Where(x => x.IsDeleted).ToList();
    }
}