using Application.Commands.Cats.DeleteCat;
using Domain.Models;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class DeleteCatByIdCommandHandlerTest
    {
        private DeleteCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_WithValidCatId_ShouldDeleteCat()
        {
            //Arrange
            var newCat = new Cat { Id = Guid.NewGuid(), Name = "" };
            _mockDatabase.Cats.Add(newCat);

            //Create a sample of DleteCatByIdCommand
            var deleteCatByIdCommand = new DeleteCatByIdCommand(id: newCat.Id);

            //Act
            var result = await _handler.Handle(deleteCatByIdCommand, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Handle_WithNonExistentCatId_ShouldReturnNull()
        {
            //Arrang
            var nonExistentCatId = Guid.NewGuid();
            var deleteCatCommand = new DeleteCatByIdCommand(nonExistentCatId);

            //Act
            var result = await _handler.Handle(deleteCatCommand, CancellationToken.None);

            //Assert
            Assert.Null(result);

        }
    }
}
