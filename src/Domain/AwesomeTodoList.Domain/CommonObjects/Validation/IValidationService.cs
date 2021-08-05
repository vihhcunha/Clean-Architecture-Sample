using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeTodoList.Domain.CommonObjects.Validation
{
    public interface IValidationService
    {
        IReadOnlyCollection<string> MessagesValidationList { get; }
        bool IsValid { get; }
        void AddValidationMessage(string message);
        void AddValidationMessage(IEnumerable<string> messages);
        void ClearValidationsMessages();
    }
}
