using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.CommonObjects.Exceptions;
using AwesomeTodoList.Domain.CommonObjects.Validation;
using AwesomeTodoList.Domain.UseCases;
using AwesomeTodoList.Domain.UseCases.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverTest
{
    public class Test
    {
        private readonly IToDoFacade _toDoFacade;
        private readonly IValidationService _validationService;

        public Test(IToDoFacade toDoFacade, IValidationService validationService)
        {
            _toDoFacade = toDoFacade;
            _validationService = validationService;
        }

        public async Task CallCommand()
        {
            try
            {
                var toDo = await _toDoFacade.AddToDo("Teste", "Teste 1");
                var toDoFinished = await _toDoFacade.FinishToDo(toDo.IdToDo);
            }
            catch (DomainException ex)
            {
                if (!_validationService.IsValid)
                {
                    List<string> messages = _validationService.MessagesValidationList.ToList();
                }
            }
        }
    }
}
