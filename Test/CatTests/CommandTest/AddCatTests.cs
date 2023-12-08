using Application.Commands.Cats;
using Application.Commands.Cats.AddCat;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatTests
    {
        private MockDatabase _mockDatabase;
        private AddCatCommandHandler _handler;

        [SetUp]
        public void SetUp()
        {
            // Initialisera mockdatabasen och hanteraren innan varje test 
            _mockDatabase = new MockDatabase();
            _handler = new AddCatCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_ValidAddCat_ReturnsTrue()
        {
            // Arrange
            var command = new AddCatCommand(new CatDto { Name = "New Cat" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            var newcatinDB = _mockDatabase.Cats.FirstOrDefault(cat => cat.Name == "New Cat");

            Assert.IsNotNull(newcatinDB);
            Assert.That(newcatinDB.Name, Is.EqualTo("New Cat"));
        }

        [Test]
        public async Task Handle_invalidAddCat_ReturnsTrue()
        {
            // Arrange
            var command = new AddCatCommand(new CatDto { Name = "" });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);

        }

    }
}