using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.ApplicationTests.CatTests.CommandHandlers
{
    [TestFixture]
    public class UpdateCatByIdCommandHandlerTests
    {
        private UpdateCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_UpdatesCatInDatabase()
        {
            // Arrange
            var initialCat = new Cat { Id = Guid.NewGuid(), Name = "InitialCatName", LikesToPlay = true };
            _mockDatabase.Cats.Add(initialCat);

            var command = new UpdateCatByIdCommand(
                updatedCat: new CatDto { Name = "UpdatedCatName", LikesToPlay = false },
                id: initialCat.Id
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<Cat>());
            Assert.That(result.Name, Is.EqualTo("UpdatedCatName"));
        }
    }
}