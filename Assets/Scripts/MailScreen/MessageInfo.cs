using UnityEngine;
using UnityEngine.Serialization;

namespace Demo.Mail
{
    [CreateAssetMenu]
    public class MessageInfo: ScriptableObject
    {
        public bool IsReaded;
        public bool IsDeleted;
        
        [field: SerializeField] public string HeaderText { get; private set; }
        [field: SerializeField, TextArea] public string MessageText { get; private set; }
        [field: SerializeField] public string Date { get; private set; }
    }
}