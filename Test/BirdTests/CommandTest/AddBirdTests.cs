using Application.Commands.Birds.AddBird;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class AddBirdTests
    {
        private MockDatabase _mockDatabase;
        private AddBirdCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            // Initialisera mockdatabasen och hanteraren innan varje test
            _mockDatabase = new MockDatabase();
            _handler = new AddBirdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ValidAddBird_ReturnsTrue()
        {
            // Arrange
            var command = new AddBirdCommand(new BirdDto { Name = "New Bird" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            var newBirdInDB = _mockDatabase.Birds.FirstOrDefault(bird => bird.Name == "New Bird");

            Assert.IsNotNull(newBirdInDB);
            Assert.That(newBirdInDB.Name, Is.EqualTo("New Bird"));
        }

        [Test]
        public async Task Handle_InvalidAddBird_ReturnsTrue()
        {
            // Arrange
            var command = new AddBirdCommand(new BirdDto { Name = "" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}