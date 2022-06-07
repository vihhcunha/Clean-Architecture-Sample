using System.Collections.Generic;

namespace AwesomeTodoList.Domain.CommonObjects.Validation
{
    public class ValidationService : IValidationService
    {
        public IReadOnlyCollection<string> MessagesValidationList => _messagesValidationList;
        public List<string> _messagesValidationList { get; } = new List<string>();

        public bool IsValid
        {
            get
            {
                return MessagesValidationList.Count == 0;
            }
        }

        public void AddValidationMessage(string message)
        {
            _messagesValidationList.Add(message);
        }

        public void AddValidationMessage(IEnumerable<string> messages)
        {
            _messagesValidationList.AddRange(messages);
        }

        public void ClearValidationsMessages()
        {
            _messagesValidationList.Clear();
        }
    }
}
