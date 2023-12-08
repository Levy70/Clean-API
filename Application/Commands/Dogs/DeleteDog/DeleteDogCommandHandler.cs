using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Commands.Dogs.DeleteDog
{
    public class DeleteDogCommandHandler : IRequestHandler<DeleteDogCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteDogCommandHandler(MockDatabase mockdatabase)
        {
            _mockDatabase = mockdatabase;
        }

        public Task<Dog> Handle(DeleteDogCommand request, CancellationToken cancellationToken)
        {
            // Hitta hunden att ta bort från databasen
            var dogToDelete = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == request.Id);

            _mockDatabase.Dogs.Remove(dogToDelete);

            return Task.FromResult(dogToDelete);

        }


    }

}