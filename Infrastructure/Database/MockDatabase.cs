using Domain.Models;
using System.Runtime.CompilerServices;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        public List<Bird> Birds
        {
            get { return allBirds; }
            set { allBirds = value; }
        }

        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"},
            new Dog { Id = new Guid("87654321-4321-8765-4321-876543210987"), Name = "AnotherTestDogForUnitTests"}
        };

        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Molly"},
            new Cat { Id = Guid.NewGuid(), Name = "Misty"},
            new Cat { Id = Guid.NewGuid(), Name = "Jerry"},
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestCatForUnitTests"},
            new Cat { Id = new Guid("87654321-4321-8765-4321-876543210987"), Name = "AnotherTestCatForUnitTests"}
        };

        private static List<Bird> allBirds = new()
        {
            new Bird { Id = Guid.NewGuid(), Name = "Pigeon"},
            new Bird { Id = Guid.NewGuid(), Name = "Eagle"},
            new Bird { Id = Guid.NewGuid(), Name = "Parrot"},
            new Bird { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestBirdForUnitTests"},
            new Bird { Id = new Guid("87654321-4321-8765-4321-876543210987"), Name = "AnotherTestBirdForUnitTests"}
        };

    }
}
