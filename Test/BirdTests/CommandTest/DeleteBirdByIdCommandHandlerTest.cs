using Application.Commands.Birds.DeleteBird;
using Domain.Models;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class DeleteBirdByIdCommandHandlerTest
    {
        private DeleteBirdByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_DeleteBirdById_InDatabase()
        {
            //Arrange
            var newBird = new Bird { Id = Guid.NewGuid() };
            _mockDatabase.Birds.Add(newBird);

            //Create a sample of DleteBirdByIdCommand
            var deleteBirdByIdCommand = new DeleteBirdByIdCommand(id: newBird.Id);

            //Act
            var result = await _handler.Handle(deleteBirdByIdCommand, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(newBird.Id));
        }

        [Test]
        public async Task Handle_InvaliId_DoesNotExist()
        {
            //Arrange
            var invalidBirdId = Guid.NewGuid();
            var invalidBirdIdCommand = new DeleteBirdByIdCommand(invalidBirdId);

            //Act
            var invalidBirdIdResult = await _handler.Handle(invalidBirdIdCommand, CancellationToken.None);

            //Assert
            Assert.IsNull(invalidBirdIdResult);
        }
    }
}
