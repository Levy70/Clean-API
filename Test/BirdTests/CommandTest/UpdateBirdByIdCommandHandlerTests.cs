using Application.Commands.Birds.UpdateBird;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.BirdTests.CommandHandlers
{
    [TestFixture]
    public class UpdateBirdByIdCommandHandlerTests
    {
        private UpdateBirdByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_UpdatesBirdInDatabase()
        {
            // Arrange
            var initialBird = new Bird { Id = Guid.NewGuid(), Name = "InitialBirdName", CanFly = true };
            _mockDatabase.Birds.Add(initialBird);

            var command = new UpdateBirdByIdCommand(
                updatedBird: new BirdDto { Name = "UpdatedBirdName", CanFly = false },
                id: initialBird.Id
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Bird>());
            Assert.That(result.Name, Is.EqualTo("UpdatedBirdName"));
        }
    }
}
