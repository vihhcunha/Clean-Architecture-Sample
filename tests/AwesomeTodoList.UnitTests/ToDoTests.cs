using AwesomeTodoList.Domain.CommonObjects;
using AwesomeTodoList.Domain.CommonObjects.Exceptions;
using AwesomeTodoList.Domain.Entities;
using AwesomeTodoList.Domain.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AwesomeTodoList.UnitTests
{
    public class ToDoTests
    {
        [Fact(DisplayName = "Must build object correctly")]
        [Trait("Category","ToDo")]
        public void BuildToDo_MustBuildCorrectly()
        {
            //Arrange
            var faker = new Bogus.Faker();
            var nameToDo = faker.Lorem.Word();
            var description = faker.Lorem.Sentence(5);
            var prevision = faker.Date.Future();

            //Act 
            var toDo = new ToDo(nameToDo, description, prevision);
            var toDo2 = new ToDo(nameToDo, description);

            //Assert
            Assert.IsType<ToDo>(toDo);
            Assert.Equal(nameToDo, toDo.Name);
            Assert.Equal(description, toDo.Description);
            Assert.Equal(prevision, toDo.Prevision);
            Assert.True(toDo.IdToDo != Guid.Empty);

            Assert.Null(toDo2.Prevision);
        }

        [Fact(DisplayName = "Must not build object - Invalid inputs")]
        [Trait("Category", "ToDo")]
        public void BuildToDo_MustNotBuild_InvalidInputs()
        {
            //Arrange & Act & Assert
            Assert.Throws<DomainException>(() => new ToDo("", "Test"));
        }

        [Fact(DisplayName = "Must finish task")]
        [Trait("Category", "ToDo")]
        public void FinishToDo_MustFinishTaskCorrectly()
        {
            //Arrange
            var toDo = new ToDo("Test", "Test description");

            //Act 
            toDo.FinishTask();

            //Assert
            Assert.True(toDo.Done);
            Assert.True(toDo.DateDone.HasValue);
        }

        [Fact(DisplayName = "Must not finish task - already finished")]
        [Trait("Category", "ToDo")]
        public void FinishToDo_MustNotFinishTask_ItsAlreadyFinished()
        {
            //Arrange
            var toDo = new ToDo("Test", "Test description");

            //Act 
            toDo.FinishTask();

            //Assert
            Assert.Throws<DomainException>(() => toDo.FinishTask());
        }

        [Fact(DisplayName = "Must reopen task")]
        [Trait("Category", "ToDo")]
        public void FinishToDo_MustReopenTaskCorrectly()
        {
            //Arrange
            var toDo = new ToDo("Test", "Test description");

            //Act 
            toDo.FinishTask();
            toDo.ReopenTask();

            //Assert
            Assert.False(toDo.Done);
            Assert.False(toDo.DateDone.HasValue);
        }

        [Fact(DisplayName = "Must not reopen task - already opened")]
        [Trait("Category", "ToDo")]
        public void FinishToDo_MustNotOpenTask_ItsAlreadyOpened()
        {
            //Arrange
            var toDo = new ToDo("Test", "Test description");

            //Act & Assert
            Assert.Throws<DomainException>(() => toDo.ReopenTask());
        }

        [Fact(DisplayName = "Must rename")]
        [Trait("Category", "ToDo")]
        public void FinishToDo_MustRenameCorrectly()
        {
            //Arrange
            var toDo = new ToDo("Test", "Test description");
            var faker = new Bogus.Faker();
            var newName = faker.Lorem.Word();

            //Act 
            toDo.Rename(newName);

            //Assert
            Assert.Equal(newName, toDo.Name);
        }

        [Fact(DisplayName = "Must not rename - invalid input")]
        [Trait("Category", "ToDo")]
        public void FinishToDo_MustNotRename_InvalidInput()
        {
            //Arrange
            var toDo = new ToDo("Test", "Test description");

            //Act & Assert
            Assert.Throws<DomainException>(() => toDo.Rename(""));
        }

        [Fact(DisplayName = "Must update description")]
        [Trait("Category", "ToDo")]
        public void FinishToDo_MustUpdateDescriptionCorrectly()
        {
            //Arrange
            var toDo = new ToDo("Test", "Test description");
            var faker = new Bogus.Faker();
            var newDescription = faker.Lorem.Sentence();

            //Act 
            toDo.UpdateDescription(newDescription);

            //Assert
            Assert.Equal(newDescription, toDo.Description);
        }
    }
}
