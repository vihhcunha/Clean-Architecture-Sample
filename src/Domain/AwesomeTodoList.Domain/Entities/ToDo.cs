using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.CommonObjects.Exceptions;
using System;

namespace AwesomeTodoList.Domain.Entities
{
    public class ToDo : Entity
    {
        public Guid IdToDo { get; private set; }
        public string Name {  get; private set; }
        public string Description { get; private set; }
        public DateTime? Prevision {  get; private set; }
        public DateTime Created { get; private set; }
        public bool Done { get; private set; }
        public DateTime? DateDone { get; private set; }

        protected ToDo() { }

        public ToDo(string nameToDo, string description, DateTime? prevision = null)
        {
            Name = nameToDo;
            Description = description;
            Prevision = prevision;
            Created = DateTime.Now;
            IdToDo = Guid.NewGuid();
            Done = false;

            Validate();
        }

        public override void Validate()
        {
            if (String.IsNullOrEmpty(Name))
                throw new DomainException("Defina um nome!");
        }

        public void FinishTask()
        {
            if (Done) throw new DomainException("Não é possível finalizar a tarefa, visto que já está finalizada!");

            Done = true;
            DateDone = DateTime.Now;
        }

        public void ReopenTask()
        {
            if (!Done) throw new DomainException("Não é possível abrir a tarefa novamente, visto que já está aberta!");

            Done = false;
            DateDone = null;
        }

        public void Rename(string newName)
        {
            if (String.IsNullOrEmpty(newName)) throw new DomainException("Troque para um nome válido!");

            Name = newName;
        }

        public void UpdateDescription(string newDescription)
        {
            Description = newDescription;
        }
    }
}
